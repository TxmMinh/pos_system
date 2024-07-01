using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS_system
{
    public partial class frmLogin : Sample
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = "";
            string query = @"SELECT userID, uName, uUsername, uPass, uPhoneNumber, uImage, uRole FROM users 
                     WHERE uUsername = @username AND uPass = @password";

            try
            {
                using (SqlConnection connection = new SqlConnection(MainClass.con_string))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@password", txtPass.Text);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            role = dt.Rows[0]["uRole"].ToString();
                            Byte[] imageArray = (byte[])dt.Rows[0]["uImage"];
                            byte[] imageByteArray = imageArray;
                            MainClass.setImage(Image.FromStream(new MemoryStream(imageArray)));
                            MainClass.setUser(dt.Rows[0]["uUsername"].ToString());
<<<<<<< HEAD
                            MainClass.setUserID(Convert.ToInt32(dt.Rows[0]["userID"]));
=======
>>>>>>> 83685b7cbf8a050060ebe52b1bba3f15cf886993
                        }
                    }
                }

                if (role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else if (role.Equals("USER", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    frmUserMain frm = new frmUserMain();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
