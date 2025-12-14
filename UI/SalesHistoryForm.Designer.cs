namespace POS.UI
{
    partial class SalesHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvInvoices = new DataGridView();
            lblTitle = new Label();
            btnClose = new Button();
            panel1 = new Panel();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInvoices.BackgroundColor = SystemColors.ControlLight;
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Location = new Point(12, 60);
            dgvInvoices.MultiSelect = false;
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersWidth = 51;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(958, 440);
            dgvInvoices.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(278, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "NHẬT KÝ GIAO DỊCH";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(854, 13);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(116, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(lblSummary);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 506);
            panel1.Name = "panel1";
            panel1.Size = new Size(982, 60);
            panel1.TabIndex = 3;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummary.Location = new Point(12, 19);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(200, 23);
            lblSummary.TabIndex = 3;
            lblSummary.Text = "Tổng số hóa đơn: 0 | ...";
            // 
            // SalesHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 566);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Controls.Add(dgvInvoices);
            Name = "SalesHistoryForm";
            Text = "Lịch Sử Bán Hàng";
            Load += SalesHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvInvoices;
        private Label lblTitle;
        private Button btnClose;
        private Panel panel1;
        private Label lblSummary;
    }
}