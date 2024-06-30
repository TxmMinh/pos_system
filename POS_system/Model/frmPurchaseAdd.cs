using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.Model
{
    public partial class frmPurchaseAdd : SampleAdd
    {
        public frmPurchaseAdd()
        {
            InitializeComponent();
        }

        public int mainID = 0;
        public int supID = 0;

        private void frmPurchaseAdd_Load(object sender, EventArgs e)
        {
            cbProduct.SelectedIndexChanged -= new EventHandler(cbProduct_SelectedIndexChanged);
            string query1 = "select proID 'id', pName 'name' from product";
            string query2 = "select supID 'id', supName 'name' from supplier";

            MainClass.CBFill(query1, cbProduct);
            MainClass.CBFill(query2, cbSupplier);

            if (supID > 0)
            {
                cbSupplier.SelectedValue = supID;
                LoadForEdit();
            }

            // stop product selection change event
            cbProduct.SelectedIndexChanged += new EventHandler(cbProduct_SelectedIndexChanged);

        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex != -1)
            {
                txtQuantity.Text = "";
                GetDetails();
            }
        }

        private void GetDetails()
        {
            string query = "select * from product where proID = " + Convert.ToInt32(cbProduct.SelectedValue) + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtCost.Text = dt.Rows[0]["pCost"].ToString();
                Calculate();
            }
        }

        private void Calculate()
        {
            double qty = 0;
            double cost = 0;
            double amt = 0;
            double.TryParse(txtQuantity.Text, out qty);
            double.TryParse(txtCost.Text, out cost);

            amt = qty * cost;
            txtAmount.Text = amt.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Calculate();
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
                    cbProduct.SelectedValue = Convert.ToInt32(dt.Rows[0]["proID"].ToString());
                    Calculate();
                    txtBarcode.Text = "";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pid;
            string pname;
            string quantity;
            string cost;
            string amt;

            if (MainClass.Validation(this) == false)
            {
                MessageBox.Show("Please remove errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                pname = cbProduct.Text;
                pid = cbProduct.SelectedValue.ToString();
                quantity = txtQuantity.Text;
                cost = txtCost.Text;
                amt = txtAmount.Text;

                // 0 for serial and ID
                guna2DataGridView1.Rows.Add(0, 0, pid, pname, quantity, cost, amt);
                cbProduct.SelectedIndex = 0;
                cbProduct.SelectedIndex = -1;
                txtQuantity.Text = "";
                txtCost.Text = "";
                txtAmount.Text = "";
                cbSupplier.Enabled = false;
                txtDate.Enabled = false;
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        public override void btnClose_Click(object sender, EventArgs e)
        {
            cbSupplier.Enabled = true;
            txtDate.Enabled = true;
            this.Close();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.RowCount <= 0)
            {
                MessageBox.Show("Please add data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query1 = ""; // for main table
            string query2 = ""; // for details table
            int record = 0;

            if (mainID == 0) //insert
            {
                query1 = @"insert into tblMain values(@date, @type, @supID);
                            select SCOPE_IDENTITY()";
            } else
            {
                query1 = @"UPDATE tblMain set mdate=@date, mType=@type, mSupCusID=@supID where MainID=@id";
            }

            SqlCommand cmd1 = new SqlCommand(query1, MainClass.con);
            cmd1.Parameters.AddWithValue("@id", mainID);
            cmd1.Parameters.AddWithValue("@date", Convert.ToDateTime(txtDate.Value).Date);
            cmd1.Parameters.AddWithValue("@type", "PUR");
            cmd1.Parameters.AddWithValue("@supID", Convert.ToInt32(cbSupplier.SelectedValue));
            if (MainClass.con.State == ConnectionState.Closed)
            {
                MainClass.con.Open();
            }

            if (mainID == 0)
            {
                mainID = Convert.ToInt32(cmd1.ExecuteScalar());
            } else
            {
                cmd1.ExecuteNonQuery();
            }

            // insert details table
            foreach(DataGridViewRow row in guna2DataGridView1.Rows)
            {
                int did = Convert.ToInt32(row.Cells["dgvId"].Value);

                if (did == 0)
                {
                    query2 = @"insert into tblDetails values (@mID, @proID, @qty, @price, @amount, @cost)";
                } else
                {
                    query2 = @"update tblDetails set dMainID=@mID, productID=@proID, quantity=@qty, price=@price, amount=@amount, cost=@cost
                             where detailID=@id";
                }

                SqlCommand cmd2 = new SqlCommand(query2, MainClass.con);
                cmd2.Parameters.AddWithValue("@id", did);
                cmd2.Parameters.AddWithValue("@mID", mainID);
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

                mainID = 0;
                supID = 0;
                txtDate.Value = DateTime.Now;
                cbSupplier.SelectedIndex = 0;
                cbSupplier.SelectedIndex = -1;
                guna2DataGridView1.Rows.Clear();
                cbSupplier.Enabled = true;
                txtDate.Enabled = true;
            }
        }
    
        private void LoadForEdit()
        {
            string query = "select * from tblDetails inner join product on proID = productID where dMainID = " + mainID + "";
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
                string cost;
                string amt;

                did = row["detailID"].ToString();
                pname = row["pName"].ToString();
                pid = row["productID"].ToString();
                quantity = row["quantity"].ToString();
                cost = row["cost"].ToString();
                amt = row["amount"].ToString();

                // 0 for serial and ID
                guna2DataGridView1.Rows.Add(0, did, pid, pname, quantity, cost, amt);
            }
        }

    }
}
