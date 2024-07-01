namespace POS_system.View
{
    partial class frmReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnProductList = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reports";
            // 
            // btnProductList
            // 
            this.btnProductList.CheckedState.Parent = this.btnProductList;
            this.btnProductList.CustomImages.Parent = this.btnProductList;
            this.btnProductList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btnProductList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.HoverState.Parent = this.btnProductList;
            this.btnProductList.Location = new System.Drawing.Point(147, 252);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.ShadowDecoration.Parent = this.btnProductList;
            this.btnProductList.Size = new System.Drawing.Size(180, 45);
            this.btnProductList.TabIndex = 1;
            this.btnProductList.Text = "Product List";
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProductList);
            this.Controls.Add(this.label1);
            this.Name = "frmReports";
            this.Text = "frmReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnProductList;
    }
}