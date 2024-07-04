namespace POS_system.View
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProductWareH = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaleReport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1091, 91);
            this.guna2Panel2.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Report";
            // 
            // btnProductWareH
            // 
            this.btnProductWareH.Animated = true;
            this.btnProductWareH.AutoRoundedCorners = true;
            this.btnProductWareH.BackColor = System.Drawing.Color.Transparent;
            this.btnProductWareH.BorderRadius = 31;
            this.btnProductWareH.CheckedState.Parent = this.btnProductWareH;
            this.btnProductWareH.CustomImages.Parent = this.btnProductWareH;
            this.btnProductWareH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btnProductWareH.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnProductWareH.ForeColor = System.Drawing.Color.White;
            this.btnProductWareH.HoverState.Parent = this.btnProductWareH;
            this.btnProductWareH.Location = new System.Drawing.Point(279, 231);
            this.btnProductWareH.Name = "btnProductWareH";
            this.btnProductWareH.ShadowDecoration.Parent = this.btnProductWareH;
            this.btnProductWareH.Size = new System.Drawing.Size(221, 64);
            this.btnProductWareH.TabIndex = 47;
            this.btnProductWareH.Text = "Product warehouse ";
            this.btnProductWareH.Click += new System.EventHandler(this.btnProductWareH_Click);
            // 
            // btnSaleReport
            // 
            this.btnSaleReport.Animated = true;
            this.btnSaleReport.AutoRoundedCorners = true;
            this.btnSaleReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSaleReport.BorderRadius = 31;
            this.btnSaleReport.CheckedState.Parent = this.btnSaleReport;
            this.btnSaleReport.CustomImages.Parent = this.btnSaleReport;
            this.btnSaleReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btnSaleReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSaleReport.ForeColor = System.Drawing.Color.White;
            this.btnSaleReport.HoverState.Parent = this.btnSaleReport;
            this.btnSaleReport.Location = new System.Drawing.Point(570, 231);
            this.btnSaleReport.Name = "btnSaleReport";
            this.btnSaleReport.ShadowDecoration.Parent = this.btnSaleReport;
            this.btnSaleReport.Size = new System.Drawing.Size(221, 64);
            this.btnSaleReport.TabIndex = 48;
            this.btnSaleReport.Text = "Sales Report";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnSaleReport);
            this.guna2Panel1.Controls.Add(this.btnProductWareH);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 97);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1067, 615);
            this.guna2Panel1.TabIndex = 49;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 724);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel2);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnProductWareH;
        private Guna.UI2.WinForms.Guna2Button btnSaleReport;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}