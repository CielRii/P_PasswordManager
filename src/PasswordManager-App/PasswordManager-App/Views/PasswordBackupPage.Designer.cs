namespace PasswordManager_App
{
    partial class PasswordBackupPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordBackupPage));
            this.helpBtn = new System.Windows.Forms.PictureBox();
            this.webSiteLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.passwordBackupPageTitle = new System.Windows.Forms.Label();
            this.webSiteInsert = new System.Windows.Forms.TextBox();
            this.userPasswordInsert = new System.Windows.Forms.TextBox();
            this.userNameInsert = new System.Windows.Forms.TextBox();
            this.passwordBackupBtn = new System.Windows.Forms.Button();
            this.optionsBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // helpBtn
            // 
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(590, 28);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 38);
            this.helpBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.helpBtn.TabIndex = 39;
            this.helpBtn.TabStop = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // webSiteLbl
            // 
            this.webSiteLbl.AutoSize = true;
            this.webSiteLbl.Location = new System.Drawing.Point(233, 235);
            this.webSiteLbl.Name = "webSiteLbl";
            this.webSiteLbl.Size = new System.Drawing.Size(31, 13);
            this.webSiteLbl.TabIndex = 38;
            this.webSiteLbl.Text = "Site :";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(187, 197);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(77, 13);
            this.passwordLbl.TabIndex = 37;
            this.passwordLbl.Text = "Mot de passe :";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(205, 152);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(59, 13);
            this.userNameLbl.TabIndex = 36;
            this.userNameLbl.Text = "Utilisateur :";
            // 
            // passwordBackupPageTitle
            // 
            this.passwordBackupPageTitle.AutoSize = true;
            this.passwordBackupPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBackupPageTitle.Location = new System.Drawing.Point(175, 93);
            this.passwordBackupPageTitle.Name = "passwordBackupPageTitle";
            this.passwordBackupPageTitle.Size = new System.Drawing.Size(300, 25);
            this.passwordBackupPageTitle.TabIndex = 35;
            this.passwordBackupPageTitle.Text = "Sauvegarder un mot de passe";
            // 
            // webSiteInsert
            // 
            this.webSiteInsert.Location = new System.Drawing.Point(283, 232);
            this.webSiteInsert.Name = "webSiteInsert";
            this.webSiteInsert.Size = new System.Drawing.Size(181, 20);
            this.webSiteInsert.TabIndex = 34;
            // 
            // userPasswordInsert
            // 
            this.userPasswordInsert.Location = new System.Drawing.Point(283, 194);
            this.userPasswordInsert.Name = "userPasswordInsert";
            this.userPasswordInsert.Size = new System.Drawing.Size(181, 20);
            this.userPasswordInsert.TabIndex = 33;
            // 
            // userNameInsert
            // 
            this.userNameInsert.Location = new System.Drawing.Point(283, 149);
            this.userNameInsert.Name = "userNameInsert";
            this.userNameInsert.Size = new System.Drawing.Size(181, 20);
            this.userNameInsert.TabIndex = 32;
            // 
            // passwordBackupBtn
            // 
            this.passwordBackupBtn.Location = new System.Drawing.Point(262, 302);
            this.passwordBackupBtn.Name = "passwordBackupBtn";
            this.passwordBackupBtn.Size = new System.Drawing.Size(113, 50);
            this.passwordBackupBtn.TabIndex = 30;
            this.passwordBackupBtn.Text = "Sauvegarder le mot de passe";
            this.passwordBackupBtn.UseVisualStyleBackColor = true;
            this.passwordBackupBtn.Click += new System.EventHandler(this.passwordBackupBtn_Click);
            // 
            // optionsBtn
            // 
            this.optionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("optionsBtn.Image")));
            this.optionsBtn.Location = new System.Drawing.Point(558, 28);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(26, 41);
            this.optionsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionsBtn.TabIndex = 40;
            this.optionsBtn.TabStop = false;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // PasswordBackupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 461);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.webSiteLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.passwordBackupPageTitle);
            this.Controls.Add(this.webSiteInsert);
            this.Controls.Add(this.userPasswordInsert);
            this.Controls.Add(this.userNameInsert);
            this.Controls.Add(this.passwordBackupBtn);
            this.Name = "PasswordBackupPage";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox helpBtn;
        private System.Windows.Forms.Label webSiteLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label passwordBackupPageTitle;
        private System.Windows.Forms.TextBox webSiteInsert;
        private System.Windows.Forms.TextBox userPasswordInsert;
        private System.Windows.Forms.TextBox userNameInsert;
        private System.Windows.Forms.Button passwordBackupBtn;
        private System.Windows.Forms.PictureBox optionsBtn;
    }
}