using System;
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

namespace POS_system
{
    public partial class frmSignup : Sample
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void btnSignup_Click(object sender, EventArgs e)
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
                    query = @"insert into users values (@name, @username, @pass, @phone, @image, @role, @address, @email)";
                }
                else // update
                {
                    query = @"update users set uName=@name,
                              uUsername=@username,
                              uPass=@pass,
                              uPhoneNumber=@phone,
                              uImage=@image,
                              uRole=@role,
                              uAddress=@address,
                              uEmail=@email
                              where userID=@id";
                }

                Image temp = new Bitmap(txtPic.Image);
                MemoryStream ms = new MemoryStream();
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@username", txtUser.Text);
                ht.Add("@pass", txtPass.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@role", cbRole.SelectedItem.ToString());
                ht.Add("@address", txtAddress.Text);
                ht.Add("@email", txtEmail.Text);
                ht.Add("@image", imageByteArray);

                if (MainClass.SQL(query, ht) > 0)
                {
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtPhone.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    cbRole.SelectedItem = 1;
                    txtPic.Image = Properties.Resources._1564535_customer_user_userphoto_account_person_icon;
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

        private void frmSignup_Load(object sender, EventArgs e)
        {
            cbRole.Items.Add("USER");
            cbRole.SelectedIndex = 0;             
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
