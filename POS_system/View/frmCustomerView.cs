﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.View
{
    public partial class frmCustomerView : SampleView
    {
        public frmCustomerView()
        {
            InitializeComponent();
        }

        private void frmCustomerView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBlackground(new frmCustomerAdd());
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
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvEmail);
            lb.Items.Add(dgvPhone);

            string query = @"select * from customer 
                            where cusName like '%" + txtSearch.Text + "%' order by cusID desc";
            MainClass.LoadData(query, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmCustomerAdd frm = new frmCustomerAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtEmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvEmail"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                MainClass.BlurBlackground(frm);
                LoadData();
            }

            // Delete
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string query = "Delete from customer where cusID = " + id + "";
                    Hashtable ht = new Hashtable();
                    if (MainClass.SQL(query, ht) > 0)
                    {
                        MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }
    }
}
