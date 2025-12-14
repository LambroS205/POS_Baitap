namespace POS.UI
{
    partial class SalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            btnClearCart = new Button();
            btnCheckout = new Button();
            lblTotal = new Label();
            label3 = new Label();
            txtCustomerName = new TextBox();
            label2 = new Label();
            lblStaffName = new Label();
            label1 = new Label();
            dgvCart = new DataGridView();
            groupBox2 = new GroupBox();
            dgvSearchResults = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1262, 673);
            splitContainer1.SplitterDistance = 629;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClearCart);
            groupBox1.Controls.Add(btnCheckout);
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCustomerName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblStaffName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvCart);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(629, 673);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giỏ hàng";
            // 
            // btnClearCart
            // 
            btnClearCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearCart.Font = new Font("Segoe UI", 10F);
            btnClearCart.Location = new Point(341, 620);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(129, 41);
            btnClearCart.TabIndex = 8;
            btnClearCart.Text = "Hủy Đơn";
            btnClearCart.UseVisualStyleBackColor = true;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.Location = new Point(476, 620);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(137, 41);
            btnCheckout.TabIndex = 7;
            btnCheckout.Text = "Thanh Toán";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(341, 563);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(272, 41);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "0 VND";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(499, 535);
            label3.Name = "label3";
            label3.Size = new Size(114, 28);
            label3.TabIndex = 5;
            label3.Text = "TỔNG CỘNG:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtCustomerName.Location = new Point(135, 574);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(244, 27);
            txtCustomerName.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 577);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Tên khách hàng:";
            // 
            // lblStaffName
            // 
            lblStaffName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStaffName.AutoSize = true;
            lblStaffName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStaffName.Location = new Point(99, 542);
            lblStaffName.Name = "lblStaffName";
            lblStaffName.Size = new Size(88, 20);
            lblStaffName.TabIndex = 2;
            lblStaffName.Text = "(StaffName)";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 542);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "Nhân viên:";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(6, 26);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(617, 497);
            dgvCart.TabIndex = 0;
            dgvCart.CellEndEdit += dgvCart_CellEndEdit;
            dgvCart.KeyDown += dgvCart_KeyDown;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvSearchResults);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(txtSearch);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(629, 673);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm sản phẩm";
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.AllowUserToAddRows = false;
            dgvSearchResults.AllowUserToDeleteRows = false;
            dgvSearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchResults.Location = new Point(6, 73);
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.RowHeadersWidth = 51;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchResults.Size = new Size(617, 594);
            dgvSearchResults.TabIndex = 2;
            dgvSearchResults.CellDoubleClick += dgvSearchResults_CellDoubleClick;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(529, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(6, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(517, 27);
            txtSearch.TabIndex = 0;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(splitContainer1);
            Name = "SalesForm";
            Text = "Bán hàng (POS)";
            WindowState = FormWindowState.Maximized;
            Load += SalesForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvCart;
        private Label label1;
        private Label lblStaffName;
        private TextBox txtCustomerName;
        private Label label2;
        private Label lblTotal;
        private Label label3;
        private Button btnCheckout;
        private Button btnClearCart;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvSearchResults;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}