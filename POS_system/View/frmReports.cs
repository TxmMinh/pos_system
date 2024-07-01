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

namespace POS_system.View
{
    public partial class frmReports : Sample
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private DataTable dTable(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            da.Fill(dt);



            return dt;
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {

        }
    }
}
