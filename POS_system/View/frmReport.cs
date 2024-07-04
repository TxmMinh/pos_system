﻿using System;
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
    public partial class frmReport : Sample
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnProductWareH_Click(object sender, EventArgs e)
        {
            frmReportStock frm = new frmReportStock();
            frm.ShowDialog();
        }

        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            frmSaleReport frm = new frmSaleReport();
            frm.ShowDialog();
        }
    }
}
