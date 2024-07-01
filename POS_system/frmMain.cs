using POS_system.Model;
using POS_system.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system
{
    public partial class frmMain : Sample
    {
        static frmMain _obj;
        public static frmMain Instance
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; } 
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();

            lblUser.Text = MainClass.USER;
            guna2CirclePictureBox1.Image = MainClass.IMG;
            btnHome.PerformClick();
        }

        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddControls(new frmUserView());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AddControls(new frmSupplierView());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AddControls(new frmCustomerView());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchaseView());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            AddControls(new frmSaleView());
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            AddControls(new frmDashboard());
        }

        private void btnLogout_Click(object sender, EventArgs e)
=======
            AddControls(new frmDashBoard());
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
>>>>>>> 83685b7cbf8a050060ebe52b1bba3f15cf886993
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
