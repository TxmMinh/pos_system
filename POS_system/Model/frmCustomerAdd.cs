using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system
{
    public partial class frmCustomerAdd : SampleAdd
    {
        public frmCustomerAdd()
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
                    query = @"insert into customer values (@name, @email, @phone)";
                }
                else // update
                {
                    query = @"update customer set cusName=@name,
                              cusEmail=@email,
                              cusPhone=@phone
                              where cusID=@id";
                }

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@email", txtEmail.Text);
                ht.Add("@phone", txtPhone.Text);

                Console.WriteLine(query);
                Console.WriteLine("Phone: " + txtPhone.Text);
                Console.WriteLine("Email: " + txtEmail.Text);

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
