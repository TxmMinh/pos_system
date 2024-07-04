using POS_system.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace POS_system.User
{
    public partial class frmUserReceipt : Sample
    {
        public frmUserReceipt()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cusID = MainClass.USERID;
        public DateTime date;
        public string email;

        private void frmUserReceipt_Load(object sender, EventArgs e)
        {
            if (cusID > 0)
            {
                LoadForUserInfo();
                LoadForReceipt();
                GrandTotal();
                txtDate.Text = date.ToString();
            }             
        }

        private void GrandTotal()
        {
            double total = 0;
            labelTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }

            labelTotal.Text = total.ToString("N2");
        }

        private void LoadForReceipt()
        {
            string query = "select * from tblDetails inner join product on proID = productID where dMainID = " + id + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                int sr;
                string did;
                string pid;
                string pname;
                string quantity;
                string price;
                string cost;
                string amt;

                count++;
                sr = count;
                did = row["detailID"].ToString();
                pname = row["pName"].ToString();
                pid = row["productID"].ToString();
                quantity = row["quantity"].ToString();
                price = row["price"].ToString();
                amt = row["amount"].ToString();
                cost = row["cost"].ToString();

                // 0 for serial and ID
                guna2DataGridView1.Rows.Add(sr, did, pid, pname, quantity, price, amt, cost);
            }
             
        }
 

        private void LoadForUserInfo()
        {
            string query = "select * from users where userID = " + cusID + "";
            SqlCommand cmd = new SqlCommand(query, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                txtUsername.Text = row["uUsername"].ToString();
                txtPhone.Text = row["uPhoneNumber"].ToString();
                txtAddress.Text = row["uAddress"].ToString();
                email = row["uEmail"].ToString();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPath = GenerateReceiptPdf();
                SendEmail(txtUsername.Text, email, pdfPath);
                MessageBox.Show("Receipt sent successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending receipt: " + ex.Message);
            }
        }

        private string GenerateReceiptPdf()
        {
            string fileName = $"Receipt_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Thêm tiêu đề
            var titleFont = FontFactory.GetFont("HELVETICA", 18, iTextSharp.text.Font.BOLD);
            document.Add(new Paragraph("Receipt", titleFont));
            document.Add(new Paragraph($"Date: {date:yyyy-MM-dd}"));
            document.Add(new Paragraph($"Customer: {txtUsername.Text}"));
            document.Add(new Paragraph($"Phone number: {txtPhone.Text}"));
            document.Add(new Paragraph($"Address: {txtAddress.Text}"));
            document.Add(new Paragraph("\n"));

            // Thêm bảng dữ liệu
            PdfPTable table = new PdfPTable(guna2DataGridView1.Columns.Count);
            // Thêm tiêu đề bảng
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                table.AddCell(new Phrase(column.HeaderText));
            }

            // Thêm dữ liệu bảng
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new Phrase(cell.Value?.ToString()));
                }
            }

            document.Add(table);
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph($"Total: {labelTotal.Text}"));

            document.Close();

            return filePath;
        }

        private void SendEmail(string customerName, string toEmail, string filePath)
        {
            string from = "21520352@gm.uit.edu.vn";
            string pass = "rkuu ninf qfta queu"; // Tốt hơn nên lưu mật khẩu trong biến môi trường hoặc tệp cấu hình
            string subject = "Your Receipt from POS System";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = "Please find your receipt attached.",
                IsBodyHtml = true
            };
            message.To.Add(toEmail);
            message.Attachments.Add(new Attachment(filePath));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            smtp.Send(message);
        }
    }
}
