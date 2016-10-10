namespace StartWiFi
{
    partial class StartWiFi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWiFi));
            this.host_title = new System.Windows.Forms.Label();
            this.login_title = new System.Windows.Forms.Label();
            this.passwd_title = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.TextBox();
            this.upload = new System.Windows.Forms.Button();
            this.rm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // host_title
            // 
            this.host_title.AutoSize = true;
            this.host_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.host_title.Location = new System.Drawing.Point(14, 5);
            this.host_title.Name = "host_title";
            this.host_title.Size = new System.Drawing.Size(37, 16);
            this.host_title.TabIndex = 0;
            this.host_title.Text = "host";
            // 
            // login_title
            // 
            this.login_title.AutoSize = true;
            this.login_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_title.Location = new System.Drawing.Point(12, 31);
            this.login_title.Name = "login_title";
            this.login_title.Size = new System.Drawing.Size(42, 16);
            this.login_title.TabIndex = 1;
            this.login_title.Text = "login";
            // 
            // passwd_title
            // 
            this.passwd_title.AutoSize = true;
            this.passwd_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwd_title.Location = new System.Drawing.Point(0, 57);
            this.passwd_title.Name = "passwd_title";
            this.passwd_title.Size = new System.Drawing.Size(75, 16);
            this.passwd_title.TabIndex = 5;
            this.passwd_title.Text = "password";
            // 
            // host
            // 
            this.host.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.host.Location = new System.Drawing.Point(72, 2);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(119, 22);
            this.host.TabIndex = 2;
            this.host.Text = "192.168.88.1";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(72, 28);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(119, 20);
            this.login.TabIndex = 3;
            this.login.Text = "admin";
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(72, 54);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(119, 20);
            this.passwd.TabIndex = 4;
            this.passwd.UseSystemPasswordChar = true;
            // 
            // upload
            // 
            this.upload.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.upload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.upload.Location = new System.Drawing.Point(133, 80);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(58, 30);
            this.upload.TabIndex = 6;
            this.upload.Text = "upload";
            this.upload.UseVisualStyleBackColor = false;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // rm
            // 
            this.rm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rm.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.rm.Location = new System.Drawing.Point(72, 80);
            this.rm.Name = "rm";
            this.rm.Size = new System.Drawing.Size(55, 30);
            this.rm.TabIndex = 7;
            this.rm.Text = "remove";
            this.rm.UseVisualStyleBackColor = false;
            this.rm.Click += new System.EventHandler(this.remove_Click);
            // 
            // StartWiFi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(202, 117);
            this.Controls.Add(this.rm);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.login);
            this.Controls.Add(this.host);
            this.Controls.Add(this.passwd_title);
            this.Controls.Add(this.login_title);
            this.Controls.Add(this.host_title);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(570, 320);
            this.MaximumSize = new System.Drawing.Size(480, 640);
            this.MinimumSize = new System.Drawing.Size(210, 144);
            this.Name = "StartWiFi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartWiFi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label host_title;
        private System.Windows.Forms.Label login_title;
        private System.Windows.Forms.Label passwd_title;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button rm;
    }
}

