namespace POS.UI
{
    partial class ReportForm
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
            panelFilter = new Panel();
            btnRunReport = new Button();
            dtpEndDate = new DateTimePicker();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            panelSummary = new Panel();
            lblTotalInvoices = new Label();
            label5 = new Label();
            lblTotalRevenue = new Label();
            label3 = new Label();
            dgvReport = new DataGridView();
            panelFilter.SuspendLayout();
            panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(btnRunReport);
            panelFilter.Controls.Add(dtpEndDate);
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(dtpStartDate);
            panelFilter.Controls.Add(label1);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(982, 69);
            panelFilter.TabIndex = 0;
            // 
            // btnRunReport
            // 
            btnRunReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRunReport.Location = new Point(576, 19);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(134, 31);
            btnRunReport.TabIndex = 4;
            btnRunReport.Text = "Xem Báo Cáo";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(377, 22);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(160, 27);
            dtpEndDate.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 25);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(106, 22);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(160, 27);
            dtpStartDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // panelSummary
            // 
            panelSummary.Controls.Add(lblTotalInvoices);
            panelSummary.Controls.Add(label5);
            panelSummary.Controls.Add(lblTotalRevenue);
            panelSummary.Controls.Add(label3);
            panelSummary.Dock = DockStyle.Bottom;
            panelSummary.Location = new Point(0, 484);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(982, 69);
            panelSummary.TabIndex = 1;
            // 
            // lblTotalInvoices
            // 
            lblTotalInvoices.AutoSize = true;
            lblTotalInvoices.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalInvoices.Location = new Point(177, 21);
            lblTotalInvoices.Name = "lblTotalInvoices";
            lblTotalInvoices.Size = new Size(24, 28);
            lblTotalInvoices.TabIndex = 3;
            lblTotalInvoices.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 27);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 2;
            label5.Text = "Tổng số hóa đơn:";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalRevenue.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.ForeColor = Color.Red;
            lblTotalRevenue.Location = new Point(640, 18);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(318, 31);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 VND";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(471, 21);
            label3.Name = "label3";
            label3.Size = new Size(163, 28);
            label3.TabIndex = 0;
            label3.Text = "Tổng doanh thu:";
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(0, 69);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(982, 415);
            dgvReport.TabIndex = 2;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(dgvReport);
            Controls.Add(panelSummary);
            Controls.Add(panelFilter);
            Name = "ReportForm";
            Text = "Báo cáo Doanh thu";
            Load += ReportForm_Load;
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFilter;
        private Label label1;
        private DateTimePicker dtpStartDate;
        private Label label2;
        private DateTimePicker dtpEndDate;
        private Button btnRunReport;
        private Panel panelSummary;
        private Label label3;
        private Label lblTotalRevenue;
        private Label label5;
        private Label lblTotalInvoices;
        private DataGridView dgvReport;
    }
}