using System;
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
    public partial class frmSaleReport : SampleView
    {
        public frmSaleReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void frmSaleReport_Load(object sender, EventArgs e)
        {
        }

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Clear();
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvCustomerOrUser);
            lb.Items.Add(dgvQuantity);
            lb.Items.Add(dgvCost);
            lb.Items.Add(dgvSale);
            lb.Items.Add(dgvProfit);

            string query = @"
                            -- Bảng tạm thời cho báo cáo chính
                            WITH ReportData AS (
                                SELECT 
                                    d.detailID,
                                    d.dMainID,
                                    d.productID,
                                    p.pName AS productName,
                                    m.mdate AS Date,
                                    CASE 
                                        WHEN m.mSupCusID IS NOT NULL THEN c.cusName
                                        WHEN m.mUserID IS NOT NULL THEN u.uName
                                        ELSE 'Unknown' 
                                    END AS CustomerOrUser,
                                    d.quantity,
                                    p.pPrice AS price,
                                    p.pCost AS cost,
                                    (p.pPrice - p.pCost) * d.quantity AS profit
                                FROM 
                                    tblDetails d
                                INNER JOIN 
                                    Product p ON d.productID = p.proID
                                INNER JOIN 
                                    tblMain m ON d.dMainID = m.MainID
                                LEFT JOIN 
                                    users u ON m.mUserID = u.userID
                                LEFT JOIN 
                                    customer c ON m.mSupCusID = c.cusID 
                            )

                            -- Truy vấn chính để lấy dữ liệu
                            SELECT 
                                productName,
                                Date,
                                CustomerOrUser,
                                quantity,
                                cost,
                                price,
                                profit
                            FROM 
                                ReportData                            
                            where Date BETWEEN '" + Convert.ToDateTime(txtFromDate.Text) + "' AND '" + Convert.ToDateTime(txtToDate.Text) +
                            "' ORDER BY Date, productName, CustomerOrUser";
             
            MainClass.LoadData(query, guna2DataGridView1, lb);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadData();
            GrandTotal();
        }

        private void GrandTotal()
        {
            double total = 0;
            labelTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvProfit"].Value.ToString());
            }

            labelTotal.Text = total.ToString("N2");
        }
    }
}
