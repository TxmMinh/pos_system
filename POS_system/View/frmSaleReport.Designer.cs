namespace POS_system.View
{
    partial class frmSaleReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCustomerOrUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.txtToDate);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.txtFromDate);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1218, 217);
            this.guna2Panel1.Controls.SetChildIndex(this.label1, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.label2, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.btnAdd, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.txtSearch, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.btnClose, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.label4, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.txtFromDate, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.label3, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.txtToDate, 0);
            this.guna2Panel1.Controls.SetChildIndex(this.guna2Button1, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.btnAdd.CheckedState.Parent = this.btnAdd;
            this.btnAdd.CustomImages.Parent = this.btnAdd;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.HoverState.Parent = this.btnAdd;
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnAdd.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.btnAdd.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 18;
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.Location = new System.Drawing.Point(1639, 154);
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(456, 38);
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1707, 108);
            this.label2.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 26;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Crimson;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(1026, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(153, 54);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 35;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSr,
            this.dgvName,
            this.dgvDate,
            this.dgvCustomerOrUser,
            this.dgvQuantity,
            this.dgvCost,
            this.dgvSale,
            this.dgvProfit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(36, 235);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 35;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1143, 533);
            this.guna2DataGridView1.TabIndex = 8;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 35;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvSr
            // 
            this.dgvSr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSr.FillWeight = 70F;
            this.dgvSr.HeaderText = "Sr #";
            this.dgvSr.MinimumWidth = 70;
            this.dgvSr.Name = "dgvSr";
            this.dgvSr.ReadOnly = true;
            this.dgvSr.Width = 70;
            // 
            // dgvName
            // 
            this.dgvName.HeaderText = "Product Name";
            this.dgvName.MinimumWidth = 6;
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvDate
            // 
            this.dgvDate.HeaderText = "Date";
            this.dgvDate.MinimumWidth = 6;
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            // 
            // dgvCustomerOrUser
            // 
            this.dgvCustomerOrUser.HeaderText = "Customer";
            this.dgvCustomerOrUser.MinimumWidth = 6;
            this.dgvCustomerOrUser.Name = "dgvCustomerOrUser";
            this.dgvCustomerOrUser.ReadOnly = true;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.HeaderText = "Quantity";
            this.dgvQuantity.MinimumWidth = 6;
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.ReadOnly = true;
            // 
            // dgvCost
            // 
            this.dgvCost.HeaderText = "Cost";
            this.dgvCost.MinimumWidth = 6;
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.ReadOnly = true;
            // 
            // dgvSale
            // 
            this.dgvSale.HeaderText = "Sale price";
            this.dgvSale.MinimumWidth = 6;
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.ReadOnly = true;
            // 
            // dgvProfit
            // 
            this.dgvProfit.HeaderText = "Profit";
            this.dgvProfit.MinimumWidth = 6;
            this.dgvProfit.Name = "dgvProfit";
            this.dgvProfit.ReadOnly = true;
            // 
            // txtFromDate
            // 
            this.txtFromDate.AutoRoundedCorners = true;
            this.txtFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtFromDate.BorderRadius = 16;
            this.txtFromDate.BorderThickness = 1;
            this.txtFromDate.CheckedState.Parent = this.txtFromDate;
            this.txtFromDate.FillColor = System.Drawing.Color.White;
            this.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFromDate.HoverState.Parent = this.txtFromDate;
            this.txtFromDate.Location = new System.Drawing.Point(46, 137);
            this.txtFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ShadowDecoration.Parent = this.txtFromDate;
            this.txtFromDate.Size = new System.Drawing.Size(247, 34);
            this.txtFromDate.TabIndex = 27;
            this.txtFromDate.Value = new System.DateTime(2024, 6, 30, 16, 57, 42, 251);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "From Date";
            // 
            // txtToDate
            // 
            this.txtToDate.AutoRoundedCorners = true;
            this.txtToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtToDate.BorderRadius = 16;
            this.txtToDate.BorderThickness = 1;
            this.txtToDate.CheckedState.Parent = this.txtToDate;
            this.txtToDate.FillColor = System.Drawing.Color.White;
            this.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtToDate.HoverState.Parent = this.txtToDate;
            this.txtToDate.Location = new System.Drawing.Point(342, 137);
            this.txtToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ShadowDecoration.Parent = this.txtToDate;
            this.txtToDate.Size = new System.Drawing.Size(247, 34);
            this.txtToDate.TabIndex = 29;
            this.txtToDate.Value = new System.DateTime(2024, 6, 30, 16, 57, 42, 251);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "To Date";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.Animated = true;
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 26;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(675, 117);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(153, 54);
            this.guna2Button1.TabIndex = 30;
            this.guna2Button1.Text = "Search";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.Controls.Add(this.labelTotal);
            this.guna2Panel3.Controls.Add(this.label5);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel3.Location = new System.Drawing.Point(675, 774);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(504, 70);
            this.guna2Panel3.TabIndex = 48;
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.White;
            this.labelTotal.Location = new System.Drawing.Point(196, 16);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(136, 32);
            this.labelTotal.TabIndex = 1;
            this.labelTotal.Text = "0.00";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Grand Total";
            // 
            // frmSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1218, 855);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2DataGridView1);
            this.Name = "frmSaleReport";
            this.Text = "frmSaleReport";
            this.Load += new System.EventHandler(this.frmSaleReport_Load);
            this.Controls.SetChildIndex(this.guna2DataGridView1, 0);
            this.Controls.SetChildIndex(this.guna2Panel3, 0);
            this.Controls.SetChildIndex(this.guna2Panel1, 0);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtToDate;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtFromDate;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCustomerOrUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProfit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label5;
    }
}