using Guna.UI2.WinForms;
using POS_system.User;
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
    public partial class frmUserMain : Sample
    {

        static frmUserMain _obj;
        public static frmUserMain Instance
        {
            get { if (_obj == null) { _obj = new frmUserMain(); } return _obj; }
        }

        public frmUserMain()
        {
            InitializeComponent();
        }

        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnShopping_Click_1(object sender, EventArgs e)
        {
            AddControls(new frmUserSaleAdd());
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            AddControls(new frmUserViewSale());
        }

        private void frmUserMain_Load_1(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();

            lblUser.Text = MainClass.USER;
            guna2CirclePictureBox1.Image = MainClass.IMG;
            btnHome.PerformClick();
        }
    }
}
