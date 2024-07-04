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
    public partial class frmReportStock : SampleView
    {
        public frmReportStock()
        {
            InitializeComponent();
        }

        private void frmReportStock_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Clear();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvCost);
            lb.Items.Add(dgvSale);

            string query = @"
            -- Tạo một bảng tạm để lưu trữ số lượng nhập kho và bán ra
            WITH InventoryMovement AS(
                SELECT
            d.productID,
                    SUM(CASE WHEN d.price IS NULL THEN d.quantity ELSE 0 END) AS QuantityIn,
                    SUM(CASE WHEN d.cost IS NULL THEN d.quantity ELSE 0 END) AS QuantityOut
                FROM
                    tblDetails d
                GROUP BY
                    d.productID
            )
               
            -- Truy vấn chính để tính tồn kho
            SELECT
                p.proID,
                p.pName,
                p.pCost,
                p.pPrice,
                ISNULL(im.QuantityIn, 0) - ISNULL(im.QuantityOut, 0) AS Quantity
            FROM
                Product p
            LEFT JOIN
                InventoryMovement im ON p.proID = im.productID
            where pName like '%" + txtSearch2.Text + "%' order by proID desc";


            MainClass.LoadData(query, guna2DataGridView1, lb);
        }

    }
}
