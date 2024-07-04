using POS_system.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.User
{
    public partial class frmUserReceipt : Sample
    {
        public frmUserReceipt()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cusID = MainClass.USERID;
        public DateTime date;

        private void frmUserReceipt_Load(object sender, EventArgs e)
        {
            if (cusID > 0)
            {
                LoadForUserInfo();
                LoadForReceipt();
                GrandTotal();
                txtDate.Text = date.ToString();
            }
             
        }

        private void GrandTotal()
        {
            double total = 0;
            labelTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }

            labelTotal.Text = total.ToString("N2");
        }

        private void LoadForReceipt()
        {
            string query = "select * from tblDetails inner join product on proID = productID where dMainID = " + id + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                int sr;
                string did;
                string pid;
                string pname;
                string quantity;
                string price;
                string cost;
                string amt;

                count++;
                sr = count;
                did = row["detailID"].ToString();
                pname = row["pName"].ToString();
                pid = row["productID"].ToString();
                quantity = row["quantity"].ToString();
                price = row["price"].ToString();
                amt = row["amount"].ToString();
                cost = row["cost"].ToString();

                // 0 for serial and ID
                guna2DataGridView1.Rows.Add(sr, did, pid, pname, quantity, price, amt, cost);
            }
             
        }
 

        private void LoadForUserInfo()
        {
            string query = "select * from users where userID = " + cusID + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                txtUsername.Text = row["uUsername"].ToString();
                txtPhone.Text = row["uPhoneNumber"].ToString();
                txtAddress.Text = row["uAddress"].ToString();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
