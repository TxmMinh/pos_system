using Guna.UI2.WinForms;
using POS_system.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.User
{
    public partial class frmUserViewSale : SampleView
    {
        public frmUserViewSale()
        {
            InitializeComponent();
        }

        private void frmUserViewSale_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBlackground(new frmSaleAdd());
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Clear();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvCusID);
            lb.Items.Add(dgvCustomer);
            lb.Items.Add(dgvAmount);

            string query = @"select dmainID, mdate, m.mUserID, c.uUsername, SUM(d.amount) as amount
                            from tblMain m
                            inner join tblDetails d on d.dMainID = m.MainID
                            inner join users c on c.userID = m.mUserID
                            where m.mType = 'SAL' and uUsername like '%" + txtSearch.Text + "%'" +
                            " group by dMainID, mDate, m.mUserID, c.uUsername";

            MainClass.LoadData(query, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmUserReceipt frm = new frmUserReceipt();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.cusID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvCusID"].Value);
                frm.date = Convert.ToDateTime(guna2DataGridView1.CurrentRow.Cells["dgvDate"].Value);
                MainClass.BlurBlackground(frm);
                LoadData();
            }

            // Delete
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string query1 = "Delete from tblMain where MainID = " + id + "";
                    string query2 = "Delete from tblDetails where dMainID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(query1, ht);
                    if (MainClass.SQL(query2, ht) > 0)
                    {
                        MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
