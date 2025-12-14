namespace POS.UI
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuSales = new ToolStripMenuItem();
            mnuPOS = new ToolStripMenuItem();
            // Thêm mục menu mới
            mnuSalesHistory = new ToolStripMenuItem();
            mnuManagement = new ToolStripMenuItem();
            mnuProductManagement = new ToolStripMenuItem();
            mnuCategoryManagement = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuUserManagement = new ToolStripMenuItem();
            mnuReports = new ToolStripMenuItem();
            mnuReportByStaff = new ToolStripMenuItem();
            mnuReportOverall = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabelUser = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuSales, mnuManagement, mnuReports });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(85, 24);
            mnuSystem.Text = "Hệ thống";
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(160, 26);
            mnuLogout.Text = "Đăng xuất";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(160, 26);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuSales
            // 
            // Thêm mnuSalesHistory vào đây
            mnuSales.DropDownItems.AddRange(new ToolStripItem[] { mnuPOS, mnuSalesHistory });
            mnuSales.Name = "mnuSales";
            mnuSales.Size = new Size(89, 24);
            mnuSales.Text = "Bán hàng";
            // 
            // mnuPOS
            // 
            mnuPOS.Name = "mnuPOS";
            mnuPOS.Size = new Size(224, 26);
            mnuPOS.Text = "Bán hàng (POS)";
            mnuPOS.Click += mnuPOS_Click;
            // 
            // mnuSalesHistory
            // 
            mnuSalesHistory.Name = "mnuSalesHistory";
            mnuSalesHistory.Size = new Size(224, 26);
            mnuSalesHistory.Text = "Lịch sử bán hàng";
            mnuSalesHistory.Click += mnuSalesHistory_Click;
            // 
            // mnuManagement
            // 
            mnuManagement.DropDownItems.AddRange(new ToolStripItem[] { mnuProductManagement, mnuCategoryManagement, toolStripSeparator1, mnuUserManagement });
            mnuManagement.Name = "mnuManagement";
            mnuManagement.Size = new Size(73, 24);
            mnuManagement.Text = "Quản lý";
            // 
            // mnuProductManagement
            // 
            mnuProductManagement.Name = "mnuProductManagement";
            mnuProductManagement.Size = new Size(224, 26);
            mnuProductManagement.Text = "Quản lý Sản phẩm";
            mnuProductManagement.Click += mnuProductManagement_Click;
            // 
            // mnuCategoryManagement
            // 
            mnuCategoryManagement.Name = "mnuCategoryManagement";
            mnuCategoryManagement.Size = new Size(224, 26);
            mnuCategoryManagement.Text = "Quản lý Danh mục";
            mnuCategoryManagement.Click += mnuCategoryManagement_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // mnuUserManagement
            // 
            mnuUserManagement.Name = "mnuUserManagement";
            mnuUserManagement.Size = new Size(224, 26);
            mnuUserManagement.Text = "Quản lý Người dùng";
            // 
            // mnuReports
            // 
            mnuReports.DropDownItems.AddRange(new ToolStripItem[] { mnuReportByStaff, mnuReportOverall });
            mnuReports.Name = "mnuReports";
            mnuReports.Size = new Size(77, 24);
            mnuReports.Text = "Báo cáo";
            // 
            // mnuReportByStaff
            // 
            mnuReportByStaff.Name = "mnuReportByStaff";
            mnuReportByStaff.Size = new Size(242, 26);
            mnuReportByStaff.Text = "Báo cáo theo nhân viên";
            // 
            // mnuReportOverall
            // 
            mnuReportOverall.Name = "mnuReportOverall";
            mnuReportOverall.Size = new Size(242, 26);
            mnuReportOverall.Text = "Báo cáo tổng thể";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelUser });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelUser
            // 
            statusLabelUser.Name = "statusLabelUser";
            statusLabelUser.Size = new Size(181, 20);
            statusLabelUser.Text = "Đang tải thông tin user...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Hệ thống Quản lý Bán hàng (POS)";
            WindowState = FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuSales;
        private ToolStripMenuItem mnuPOS;
        private ToolStripMenuItem mnuSalesHistory; // Thêm biến này
        private ToolStripMenuItem mnuManagement;
        private ToolStripMenuItem mnuProductManagement;
        private ToolStripMenuItem mnuCategoryManagement;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuUserManagement;
        private ToolStripMenuItem mnuReports;
        private ToolStripMenuItem mnuReportByStaff;
        private ToolStripMenuItem mnuReportOverall;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelUser;
    }
}