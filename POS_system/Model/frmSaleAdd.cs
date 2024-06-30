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

namespace POS_system.Model
{
    public partial class frmSaleAdd : Sample
    {
        public frmSaleAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cusID = 0;

        private void frmSaleAdd_Load(object sender, EventArgs e)
        {
            string query = @"select cusID 'id', cusName 'name' from customer";
            MainClass.CBFill(query, cbCustomer);

            if (cusID > 0)
            {
                cbCustomer.SelectedValue = cusID;
                LoadForEdit();
                GrandTotal();
            }

            LoadProductsFromDatebase();
        }

        public void AddItems(String id, string name, string price, Image pImage, string cost)
        {
            var w = new ucProduct()
            {
                PName = name,
                Price = price,
                PImage = pImage,
                PCost = cost,
                id = Convert.ToInt32(id)
            };

            flowLayoutPanel1.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvproid"].Value) == wdg.id)
                    {
                        item.Cells["dgvQuantity"].Value = int.Parse(item.Cells["dgvQuantity"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQuantity"].Value.ToString()) *
                                                        int.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GrandTotal();
                        return;
                    }
                }

                // if not find the product in gv
                guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.Price, wdg.Price, wdg.PCost });
                GrandTotal();
            };
        }

        private void GrandTotal()
        {
            double total = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }

            lblTotal.Text = total.ToString("N2");
        }

        private void LoadProductsFromDatebase()
        {
            string query = "select * from product";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Byte[] ImageArray = (byte[])row["PImage"];
                    byte[] imageByteArray = ImageArray;

                    AddItems(row["proID"].ToString(), row["pName"].ToString(), row["pPrice"].ToString(),
                            Image.FromStream(new MemoryStream(imageByteArray)), row["pCost"].ToString());
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            txtDate.Value = DateTime.Now;
            cbCustomer.SelectedIndex = 0;
            cbCustomer.SelectedIndex = -1;
            lblTotal.Text = "0.00";
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in flowLayoutPanel1.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSeach.Text.Trim().ToLower());
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query = "select * from product where pBarcode like '" + txtBarcode.Text + "'";
                SqlCommand cmd = new SqlCommand(query, MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (Convert.ToInt32(item.Cells["dgvproid"].Value) == int.Parse(row["proID"].ToString()))
                        {
                            item.Cells["dgvQuantity"].Value = int.Parse(item.Cells["dgvQuantity"].Value.ToString()) + 1;
                            item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQuantity"].Value.ToString()) *
                                                            int.Parse(item.Cells["dgvPrice"].Value.ToString());
                            GrandTotal();
                            txtBarcode.Text = "";

                            return;
                        }
                    }

                    // if not find the product in gv
                    guna2DataGridView1.Rows.Add(new object[] { 0, row["proID"].ToString(),
                                                row["pName"].ToString(), 1, row["pPrice"].ToString(),
                                                row["pPrice"].ToString(), row["pCost"].ToString() });
                    txtBarcode.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                MessageBox.Show("Please remove errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query1 = ""; // for main table
            string query2 = ""; // for details table
            int record = 0;

            if (id == 0) //insert
            {
                query1 = @"insert into tblMain values(@date, @type, @cusID);
                            select SCOPE_IDENTITY()";
            }
            else
            {
                query1 = @"UPDATE tblMain set mdate=@date, mType=@type, mSupCusID=@cusID where MainID=@id";
            }

            SqlCommand cmd1 = new SqlCommand(query1, MainClass.con);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.Parameters.AddWithValue("@date", Convert.ToDateTime(txtDate.Value).Date);
            cmd1.Parameters.AddWithValue("@type", "SAL");
            cmd1.Parameters.AddWithValue("@cusID", Convert.ToInt32(cbCustomer.SelectedValue));
            if (MainClass.con.State == ConnectionState.Closed)
            {
                MainClass.con.Open();
            }

            if (id == 0)
            {
                id = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            else
            {
                cmd1.ExecuteNonQuery();
            }

            // insert details table
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                int did = Convert.ToInt32(row.Cells["dgvId"].Value);

                if (did == 0)
                {
                    query2 = @"insert into tblDetails values (@mID, @proID, @qty, @price, @amount, @cost)";
                }
                else
                {
                    query2 = @"update tblDetails set dMainID=@mID, productID=@proID, quantity=@qty, price=@price, amount=@amount, cost=@cost
                             where detailID=@id";
                }

                SqlCommand cmd2 = new SqlCommand(query2, MainClass.con);
                cmd2.Parameters.AddWithValue("@id", did);
                cmd2.Parameters.AddWithValue("@mID", id);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvProID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQuantity"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToInt32(row.Cells["dgvCost"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToInt32(row.Cells["dgvAmount"].Value));
                cmd2.Parameters.AddWithValue("@cost", Convert.ToInt32(row.Cells["dgvCost"].Value));

                record += cmd2.ExecuteNonQuery();
            }

            if (record > 0)
            {
                MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                id = 0;
                cusID = 0;
                txtDate.Value = DateTime.Now;
                cbCustomer.SelectedIndex = 0;
                cbCustomer.SelectedIndex = -1;
                guna2DataGridView1.Rows.Clear();
                cbCustomer.Enabled = true;
                txtDate.Enabled = true;
                lblTotal.Text = "0.00";
            }
        }

        private void LoadForEdit()
        {
            string query = "select * from tblDetails inner join product on proID = productID where dMainID = " + id + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string did;
                string pid;
                string pname;
                string quantity;
                string price;
                string cost;
                string amt;

                did = row["detailID"].ToString();
                pname = row["pName"].ToString();
                pid = row["productID"].ToString();
                quantity = row["quantity"].ToString();
                price = row["price"].ToString();
                amt = row["amount"].ToString();
                cost = row["cost"].ToString();

                // 0 for serial and ID
                guna2DataGridView1.Rows.Add(did, pid, pname, quantity, price, amt, cost);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = guna2DataGridView1.CurrentCell.RowIndex;
                    guna2DataGridView1.Rows.RemoveAt(rowIndex);

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string query1 = "Delete from tblMain where MainID = " + id + "";
                    string query2 = "Delete from tblDetails where dMainID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(query1, ht);
                    if (MainClass.SQL(query2, ht) > 0)
                    {
                        // MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    GrandTotal();

                }
            }
        }
    }
}
