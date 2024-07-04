using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system.User
{
    public partial class frmDetailProduct : Sample
    {
        public int productId { get; set; }

        public string price { get; set; }

        public frmDetailProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetailProduct_Load(object sender, EventArgs e)
        {
            LoadData();
            MessageChat();
            LoadDataQuantity(productId);
        }


        private void LoadData()
        {
            string query = @"select pName, pPrice, pImage from product where proID = " + productId;

            using (SqlConnection connection = new SqlConnection(MainClass.con_string))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lblPName.Text = reader["pName"] as string;
                            lblPrice.Text = decimal.Parse(price).ToString("N2");
                            if (reader["pImage"] != DBNull.Value)
                            {
                                byte[] imageArray = (byte[])reader["pImage"];
                                using (MemoryStream ms = new MemoryStream(imageArray))
                                {
                                    txtPic.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void LoadDataQuantity(int productId)
        {
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
        WHERE
            p.proID = @productId
        ORDER BY
            proID DESC";

            using (SqlConnection connection = new SqlConnection(MainClass.con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Sử dụng SqlParameter để ngăn chặn SQL Injection
                    command.Parameters.AddWithValue("@productId", productId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                { 
                                    lblQuantity.Text = reader["Quantity"].ToString(); 
 
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


        private void btnSendMs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter Name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Please enter message!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(MainClass.con_string);
                con.Open();
                string sql;

                sql = "insert into chats(name, message, date_created, product_id) values " +
                    "(@name, @message, @date_created, @product_id)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@message", txtMessage.Text);
                cmd.Parameters.AddWithValue("@date_created", DateTime.Now);
                cmd.Parameters.AddWithValue("@product_id", productId);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageChat();
                txtName.Clear();
                txtMessage.Clear();

            }
        }

        private void MessageChat()
        {
            string query = "select * from chats where product_id = @product_id order by date_created";
            using (SqlConnection connection = new SqlConnection(MainClass.con_string))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@product_id", productId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            ChatControl chatControl = new ChatControl
                            {
                                Name = reader["name"].ToString(),
                                Title = reader["message"].ToString(),
                                DateCreated = reader["date_created"].ToString(),
                                Dock = DockStyle.Top
                            };
                            flowLayoutPanel1.Controls.Add(chatControl);
                            flowLayoutPanel1.ScrollControlIntoView(chatControl);
                        }
                    }
                }
                connection.Close();
            }
        }

    }
}
