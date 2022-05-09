namespace SimpleMinecraftLauncher
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.btnInvalidate = new System.Windows.Forms.Button();
            this.btnDeleteToken = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gMojangLogin = new System.Windows.Forms.GroupBox();
            this.btnAutoLoginMojangLauncher = new System.Windows.Forms.Button();
            this.btnAutoLogin = new System.Windows.Forms.Button();
            this.gOfflineLogin = new System.Windows.Forms.GroupBox();
            this.btnOfflineLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gXboxLogin = new System.Windows.Forms.GroupBox();
            this.btnSignoutXbox = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXboxLogin = new System.Windows.Forms.Button();
            this.gMojangLogin.SuspendLayout();
            this.gOfflineLogin.SuspendLayout();
            this.gXboxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password : ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(78, 88);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 114);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(245, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(326, 87);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 51);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignout
            // 
            this.btnSignout.Location = new System.Drawing.Point(78, 155);
            this.btnSignout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(64, 25);
            this.btnSignout.TabIndex = 10;
            this.btnSignout.Text = "Signout";
            this.btnSignout.UseVisualStyleBackColor = true;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // btnInvalidate
            // 
            this.btnInvalidate.Location = new System.Drawing.Point(148, 155);
            this.btnInvalidate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInvalidate.Name = "btnInvalidate";
            this.btnInvalidate.Size = new System.Drawing.Size(64, 25);
            this.btnInvalidate.TabIndex = 11;
            this.btnInvalidate.Text = "Invalidate";
            this.btnInvalidate.UseVisualStyleBackColor = true;
            this.btnInvalidate.Click += new System.EventHandler(this.btnInvalidate_Click);
            // 
            // btnDeleteToken
            // 
            this.btnDeleteToken.Location = new System.Drawing.Point(217, 155);
            this.btnDeleteToken.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteToken.Name = "btnDeleteToken";
            this.btnDeleteToken.Size = new System.Drawing.Size(84, 25);
            this.btnDeleteToken.TabIndex = 12;
            this.btnDeleteToken.Text = "Delete Token";
            this.btnDeleteToken.UseVisualStyleBackColor = true;
            this.btnDeleteToken.Click += new System.EventHandler(this.btnDeleteToken_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Logout : ";
            // 
            // gMojangLogin
            // 
            this.gMojangLogin.Controls.Add(this.btnAutoLoginMojangLauncher);
            this.gMojangLogin.Controls.Add(this.btnAutoLogin);
            this.gMojangLogin.Controls.Add(this.btnLogin);
            this.gMojangLogin.Controls.Add(this.label7);
            this.gMojangLogin.Controls.Add(this.label5);
            this.gMojangLogin.Controls.Add(this.btnDeleteToken);
            this.gMojangLogin.Controls.Add(this.label6);
            this.gMojangLogin.Controls.Add(this.btnInvalidate);
            this.gMojangLogin.Controls.Add(this.txtEmail);
            this.gMojangLogin.Controls.Add(this.btnSignout);
            this.gMojangLogin.Controls.Add(this.txtPassword);
            this.gMojangLogin.Location = new System.Drawing.Point(9, 56);
            this.gMojangLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gMojangLogin.Name = "gMojangLogin";
            this.gMojangLogin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gMojangLogin.Size = new System.Drawing.Size(395, 191);
            this.gMojangLogin.TabIndex = 14;
            this.gMojangLogin.TabStop = false;
            this.gMojangLogin.Text = "Mojang Login";
            // 
            // btnAutoLoginMojangLauncher
            // 
            this.btnAutoLoginMojangLauncher.Location = new System.Drawing.Point(78, 55);
            this.btnAutoLoginMojangLauncher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAutoLoginMojangLauncher.Name = "btnAutoLoginMojangLauncher";
            this.btnAutoLoginMojangLauncher.Size = new System.Drawing.Size(242, 25);
            this.btnAutoLoginMojangLauncher.TabIndex = 15;
            this.btnAutoLoginMojangLauncher.Text = "TryAutoLogin (launcher_accounts.json)";
            this.btnAutoLoginMojangLauncher.UseVisualStyleBackColor = true;
            this.btnAutoLoginMojangLauncher.Click += new System.EventHandler(this.btnAutoLoginMojangLauncher_Click);
            // 
            // btnAutoLogin
            // 
            this.btnAutoLogin.Location = new System.Drawing.Point(78, 23);
            this.btnAutoLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAutoLogin.Name = "btnAutoLogin";
            this.btnAutoLogin.Size = new System.Drawing.Size(242, 25);
            this.btnAutoLogin.TabIndex = 14;
            this.btnAutoLogin.Text = "TryAutoLogin (cache file)";
            this.btnAutoLogin.UseVisualStyleBackColor = true;
            this.btnAutoLogin.Click += new System.EventHandler(this.btnAutoLogin_Click);
            // 
            // gOfflineLogin
            // 
            this.gOfflineLogin.Controls.Add(this.btnOfflineLogin);
            this.gOfflineLogin.Controls.Add(this.txtUsername);
            this.gOfflineLogin.Controls.Add(this.label8);
            this.gOfflineLogin.Location = new System.Drawing.Point(9, 338);
            this.gOfflineLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gOfflineLogin.Name = "gOfflineLogin";
            this.gOfflineLogin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gOfflineLogin.Size = new System.Drawing.Size(395, 62);
            this.gOfflineLogin.TabIndex = 15;
            this.gOfflineLogin.TabStop = false;
            this.gOfflineLogin.Text = "Offline Login";
            // 
            // btnOfflineLogin
            // 
            this.btnOfflineLogin.Location = new System.Drawing.Point(326, 22);
            this.btnOfflineLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOfflineLogin.Name = "btnOfflineLogin";
            this.btnOfflineLogin.Size = new System.Drawing.Size(64, 23);
            this.btnOfflineLogin.TabIndex = 14;
            this.btnOfflineLogin.Text = "Login";
            this.btnOfflineLogin.UseVisualStyleBackColor = true;
            this.btnOfflineLogin.Click += new System.EventHandler(this.btnOfflineLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(78, 22);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(242, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Username : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Simple Minecraft Launcher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Please log in: ";
            // 
            // gXboxLogin
            // 
            this.gXboxLogin.Controls.Add(this.btnSignoutXbox);
            this.gXboxLogin.Controls.Add(this.label3);
            this.gXboxLogin.Controls.Add(this.btnXboxLogin);
            this.gXboxLogin.Location = new System.Drawing.Point(9, 254);
            this.gXboxLogin.Name = "gXboxLogin";
            this.gXboxLogin.Size = new System.Drawing.Size(395, 78);
            this.gXboxLogin.TabIndex = 19;
            this.gXboxLogin.TabStop = false;
            this.gXboxLogin.Text = "Xbox";
            // 
            // btnSignoutXbox
            // 
            this.btnSignoutXbox.Location = new System.Drawing.Point(67, 48);
            this.btnSignoutXbox.Name = "btnSignoutXbox";
            this.btnSignoutXbox.Size = new System.Drawing.Size(75, 23);
            this.btnSignoutXbox.TabIndex = 2;
            this.btnSignoutXbox.Text = "Signout";
            this.btnSignoutXbox.UseVisualStyleBackColor = true;
            this.btnSignoutXbox.Click += new System.EventHandler(this.btnSignoutXbox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Logout: ";
            // 
            // btnXboxLogin
            // 
            this.btnXboxLogin.Location = new System.Drawing.Point(6, 19);
            this.btnXboxLogin.Name = "btnXboxLogin";
            this.btnXboxLogin.Size = new System.Drawing.Size(383, 23);
            this.btnXboxLogin.TabIndex = 0;
            this.btnXboxLogin.Text = "Login via Xbox Live";
            this.btnXboxLogin.UseVisualStyleBackColor = true;
            this.btnXboxLogin.Click += new System.EventHandler(this.btnXboxLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 406);
            this.Controls.Add(this.gXboxLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gOfflineLogin);
            this.Controls.Add(this.gMojangLogin);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.gMojangLogin.ResumeLayout(false);
            this.gMojangLogin.PerformLayout();
            this.gOfflineLogin.ResumeLayout(false);
            this.gOfflineLogin.PerformLayout();
            this.gXboxLogin.ResumeLayout(false);
            this.gXboxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Button btnInvalidate;
        private System.Windows.Forms.Button btnDeleteToken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gMojangLogin;
        private System.Windows.Forms.Button btnAutoLogin;
        private System.Windows.Forms.GroupBox gOfflineLogin;
        private System.Windows.Forms.Button btnOfflineLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAutoLoginMojangLauncher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gXboxLogin;
        private System.Windows.Forms.Button btnXboxLogin;
        private System.Windows.Forms.Button btnSignoutXbox;
        private System.Windows.Forms.Label label3;
    }
}