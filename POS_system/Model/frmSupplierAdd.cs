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

namespace POS_system.Model
{
    public partial class frmSupplierAdd : SampleAdd
    {
        public frmSupplierAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                MessageBox.Show("Please remove errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "";
                if (id == 0) //insert 
                {
                    query = @"insert into supplier values (@name, @email, @phone)";
                }
                else // update
                {
                    query = @"update supplier set supName=@name,
                              supEmail=@email,
                              supPhone=@phone
                              where supID=@id";
                }

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@email", txtEmail.Text);
                ht.Add("@phone", txtPhone.Text);

                if (MainClass.SQL(query, ht) > 0)
                {
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtName.Focus();
                }
            }
        }
    }
}
