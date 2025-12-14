namespace POS.UI
{
    partial class ProductForm
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
            groupBox1 = new GroupBox();
            cboFilterCategory = new ComboBox();
            txtFilterName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dgvProducts = new DataGridView();
            groupBox2 = new GroupBox();
            numAddStock = new NumericUpDown();
            labelAddStock = new Label();
            btnClose = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            numQuantity = new NumericUpDown();
            numSellingPrice = new NumericUpDown();
            numCostPrice = new NumericUpDown();
            cboCategory = new ComboBox();
            txtUnit = new TextBox();
            txtProductName = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAddStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCostPrice).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cboFilterCategory);
            groupBox1.Controls.Add(txtFilterName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1158, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bộ lọc";
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(570, 31);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(244, 28);
            cboFilterCategory.TabIndex = 3;
            cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;
            // 
            // txtFilterName
            // 
            txtFilterName.Location = new Point(135, 31);
            txtFilterName.Name = "txtFilterName";
            txtFilterName.Size = new Size(301, 27);
            txtFilterName.TabIndex = 2;
            txtFilterName.TextChanged += txtFilterName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 34);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên sản phẩm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(483, 34);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 1;
            label2.Text = "Danh mục:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 95);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1158, 301);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(numAddStock);
            groupBox2.Controls.Add(labelAddStock);
            groupBox2.Controls.Add(btnClose);
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(numQuantity);
            groupBox2.Controls.Add(numSellingPrice);
            groupBox2.Controls.Add(numCostPrice);
            groupBox2.Controls.Add(cboCategory);
            groupBox2.Controls.Add(txtUnit);
            groupBox2.Controls.Add(txtProductName);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 402);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1158, 224);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết";
            // 
            // numAddStock
            // 
            numAddStock.Location = new Point(626, 173);
            numAddStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAddStock.Name = "numAddStock";
            numAddStock.Size = new Size(160, 27);
            numAddStock.TabIndex = 18;
            numAddStock.Visible = false;
            // 
            // labelAddStock
            // 
            labelAddStock.AutoSize = true;
            labelAddStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAddStock.Location = new Point(526, 175);
            labelAddStock.Name = "labelAddStock";
            labelAddStock.Size = new Size(88, 20);
            labelAddStock.TabIndex = 17;
            labelAddStock.Text = "Nhập thêm:";
            labelAddStock.Visible = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(1025, 175);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(106, 34);
            btnClose.TabIndex = 16;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(1025, 126);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(106, 34);
            btnClear.TabIndex = 15;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(1025, 78);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 34);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(1025, 31);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 34);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu (Thêm)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(626, 126);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(160, 27);
            numQuantity.TabIndex = 12;
            // 
            // numSellingPrice
            // 
            numSellingPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numSellingPrice.Location = new Point(626, 78);
            numSellingPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numSellingPrice.Name = "numSellingPrice";
            numSellingPrice.Size = new Size(160, 27);
            numSellingPrice.TabIndex = 11;
            // 
            // numCostPrice
            // 
            numCostPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numCostPrice.Location = new Point(626, 31);
            numCostPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numCostPrice.Name = "numCostPrice";
            numCostPrice.Size = new Size(160, 27);
            numCostPrice.TabIndex = 10;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(135, 78);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(301, 28);
            cboCategory.TabIndex = 9;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(135, 126);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(301, 27);
            txtUnit.TabIndex = 8;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(135, 31);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(301, 27);
            txtProductName.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(526, 128);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 6;
            label9.Text = "Số lượng tồn:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 129);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 5;
            label8.Text = "Đơn vị tính:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(818, 80);
            label7.Name = "label7";
            label7.Size = new Size(40, 20);
            label7.TabIndex = 4;
            label7.Text = "VND";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(818, 33);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 3;
            label6.Text = "VND";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(526, 80);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 2;
            label5.Text = "Giá bán:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(526, 33);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 1;
            label4.Text = "Giá nhập:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 34);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 0;
            label3.Text = "Tên sản phẩm:";
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 638);
            Controls.Add(groupBox2);
            Controls.Add(dgvProducts);
            Controls.Add(groupBox1);
            Name = "ProductForm";
            Text = "Quản lý Sản phẩm";
            Load += ProductForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAddStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCostPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private ComboBox cboFilterCategory;
        private TextBox txtFilterName;
        private DataGridView dgvProducts;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtProductName;
        private TextBox txtUnit;
        private ComboBox cboCategory;
        private NumericUpDown numCostPrice;
        private NumericUpDown numSellingPrice;
        private NumericUpDown numQuantity;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
        private Label labelAddStock;
        private NumericUpDown numAddStock;
    }
}