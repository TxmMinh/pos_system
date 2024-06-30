﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.Model
{
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int catID = 0;

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            string query = "select catID 'id', catName 'name' from category";
            MainClass.CBFill(query, cbCategory);

            if (id > 0)
            {
                cbCategory.SelectedValue = catID;
                LoadImage();
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                MessageBox.Show("Please remove errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "";
                if (id == 0) //insert 
                {
                    query = @"insert into product values (@name, @pCatID, @barcode, @cost, @salePrice, @image)";
                }
                else // update
                {
                    query = @"update product set pName=@name, 
                              pCatID=@pCatID,
                              pBarcode=@barcode,
                              pCost=@cost,
                              pPrice=@salePrice,
                              pImage=@image
                              where proID=@id";
                }

                Image temp = new Bitmap(txtPic.Image);
                MemoryStream ms = new MemoryStream();
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@pCatID", Convert.ToInt32(cbCategory.SelectedValue));
                ht.Add("@barcode", txtBarcode.Text);
                ht.Add("@cost", Convert.ToDouble(txtCost.Text));
                ht.Add("@salePrice", Convert.ToDouble(txtPrice.Text));
                ht.Add("@image", imageByteArray);

                if (MainClass.SQL(query, ht) > 0)
                {
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtBarcode.Text = "";
                    cbCategory.SelectedIndex = 0;
                    cbCategory.SelectedIndex = -1;
                    txtCost.Text = "";
                    txtPrice.Text = "";
                    txtPic.Image = POS_system.Properties.Resources._1075425_case_accessory_woman_bag_pouch_icon;
                    txtName.Focus();
                }
            }
        }

        public string filePath = "";
        Byte[] imageByteArray;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|*.png; *jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtPic.Image = new Bitmap(filePath);
            }
        }

        private void LoadImage()
        {
            string query = @"select pImage from product where proID = " + id + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Byte[] imageArray = (byte[])dt.Rows[0]["pImage"];
                byte[] imageByteArray = imageArray;
                txtPic.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }
    }
}
