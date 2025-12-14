namespace POS.UI
{
    partial class LoginForm
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
            cmdLogin = new Button();
            cmdCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // cmdLogin
            // 
            cmdLogin.Font = new Font("Segoe UI", 10F);
            cmdLogin.Location = new Point(186, 256);
            cmdLogin.Margin = new Padding(3, 2, 3, 2);
            cmdLogin.Name = "cmdLogin";
            cmdLogin.Size = new Size(117, 30);
            cmdLogin.TabIndex = 0;
            cmdLogin.Text = "Đăng nhập";
            cmdLogin.UseVisualStyleBackColor = true;
            cmdLogin.Click += cmdLogin_Click;
            // 
            // cmdCancel
            // 
            cmdCancel.Font = new Font("Segoe UI", 10F);
            cmdCancel.Location = new Point(405, 256);
            cmdCancel.Margin = new Padding(3, 2, 3, 2);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(117, 30);
            cmdCancel.TabIndex = 1;
            cmdCancel.Text = "Hủy bỏ";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(102, 145);
            label1.Name = "label1";
            label1.Size = new Size(84, 19);
            label1.TabIndex = 2;
            label1.Text = "Tên truy cập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(102, 188);
            label2.Name = "label2";
            label2.Size = new Size(68, 19);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(219, 142);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(269, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(219, 183);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(269, 23);
            txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.Location = new Point(277, 56);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 2;
            label3.Text = "ĐĂNG NHẬP";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 338);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cmdCancel);
            Controls.Add(cmdLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdLogin;
        private Button cmdCancel;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label3;
    }
}