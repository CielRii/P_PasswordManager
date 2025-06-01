namespace PasswordManager_App
{
    partial class UserCreationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCreationPage));
            this.newUserConfirmPasswordLbl = new System.Windows.Forms.Label();
            this.newUserPasswordLbl = new System.Windows.Forms.Label();
            this.newUserNameLbl = new System.Windows.Forms.Label();
            this.userCreationPageTitle = new System.Windows.Forms.Label();
            this.newUserConfirmPasswordInsert = new System.Windows.Forms.TextBox();
            this.newUserPasswordInsert = new System.Windows.Forms.TextBox();
            this.newUserNameInsert = new System.Windows.Forms.TextBox();
            this.logInRedirection = new System.Windows.Forms.Label();
            this.createAccountBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // newUserConfirmPasswordLbl
            // 
            this.newUserConfirmPasswordLbl.AutoSize = true;
            this.newUserConfirmPasswordLbl.Location = new System.Drawing.Point(130, 231);
            this.newUserConfirmPasswordLbl.Name = "newUserConfirmPasswordLbl";
            this.newUserConfirmPasswordLbl.Size = new System.Drawing.Size(152, 13);
            this.newUserConfirmPasswordLbl.TabIndex = 28;
            this.newUserConfirmPasswordLbl.Text = "Confirmation du mot de passe :";
            // 
            // newUserPasswordLbl
            // 
            this.newUserPasswordLbl.AutoSize = true;
            this.newUserPasswordLbl.Location = new System.Drawing.Point(205, 193);
            this.newUserPasswordLbl.Name = "newUserPasswordLbl";
            this.newUserPasswordLbl.Size = new System.Drawing.Size(77, 13);
            this.newUserPasswordLbl.TabIndex = 27;
            this.newUserPasswordLbl.Text = "Mot de passe :";
            // 
            // newUserNameLbl
            // 
            this.newUserNameLbl.AutoSize = true;
            this.newUserNameLbl.Location = new System.Drawing.Point(192, 148);
            this.newUserNameLbl.Name = "newUserNameLbl";
            this.newUserNameLbl.Size = new System.Drawing.Size(90, 13);
            this.newUserNameLbl.TabIndex = 26;
            this.newUserNameLbl.Text = "Nom d\'utilisateur :";
            // 
            // userCreationPageTitle
            // 
            this.userCreationPageTitle.AutoSize = true;
            this.userCreationPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCreationPageTitle.Location = new System.Drawing.Point(180, 93);
            this.userCreationPageTitle.Name = "userCreationPageTitle";
            this.userCreationPageTitle.Size = new System.Drawing.Size(310, 25);
            this.userCreationPageTitle.TabIndex = 25;
            this.userCreationPageTitle.Text = "Gestionnaire de mots de passe";
            // 
            // newUserConfirmPasswordInsert
            // 
            this.newUserConfirmPasswordInsert.Location = new System.Drawing.Point(298, 231);
            this.newUserConfirmPasswordInsert.Name = "newUserConfirmPasswordInsert";
            this.newUserConfirmPasswordInsert.Size = new System.Drawing.Size(181, 20);
            this.newUserConfirmPasswordInsert.TabIndex = 24;
            // 
            // newUserPasswordInsert
            // 
            this.newUserPasswordInsert.Location = new System.Drawing.Point(298, 193);
            this.newUserPasswordInsert.Name = "newUserPasswordInsert";
            this.newUserPasswordInsert.Size = new System.Drawing.Size(181, 20);
            this.newUserPasswordInsert.TabIndex = 23;
            // 
            // newUserNameInsert
            // 
            this.newUserNameInsert.Location = new System.Drawing.Point(298, 148);
            this.newUserNameInsert.Name = "newUserNameInsert";
            this.newUserNameInsert.Size = new System.Drawing.Size(181, 20);
            this.newUserNameInsert.TabIndex = 22;
            // 
            // logInRedirection
            // 
            this.logInRedirection.AutoSize = true;
            this.logInRedirection.Location = new System.Drawing.Point(545, 410);
            this.logInRedirection.Name = "logInRedirection";
            this.logInRedirection.Size = new System.Drawing.Size(91, 13);
            this.logInRedirection.TabIndex = 21;
            this.logInRedirection.Text = "Déjà un compte ?";
            this.logInRedirection.Click += new System.EventHandler(this.logInRedirection_Click);
            // 
            // createAccountBtn
            // 
            this.createAccountBtn.Location = new System.Drawing.Point(277, 301);
            this.createAccountBtn.Name = "createAccountBtn";
            this.createAccountBtn.Size = new System.Drawing.Size(113, 50);
            this.createAccountBtn.TabIndex = 20;
            this.createAccountBtn.Text = "Créer un compte";
            this.createAccountBtn.UseVisualStyleBackColor = true;
            this.createAccountBtn.Click += new System.EventHandler(this.createAccountBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(605, 27);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 38);
            this.helpBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.helpBtn.TabIndex = 29;
            this.helpBtn.TabStop = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // UserCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 461);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.newUserConfirmPasswordLbl);
            this.Controls.Add(this.newUserPasswordLbl);
            this.Controls.Add(this.newUserNameLbl);
            this.Controls.Add(this.userCreationPageTitle);
            this.Controls.Add(this.newUserConfirmPasswordInsert);
            this.Controls.Add(this.newUserPasswordInsert);
            this.Controls.Add(this.newUserNameInsert);
            this.Controls.Add(this.logInRedirection);
            this.Controls.Add(this.createAccountBtn);
            this.Name = "UserCreationPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UserCreationPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newUserConfirmPasswordLbl;
        private System.Windows.Forms.Label newUserPasswordLbl;
        private System.Windows.Forms.Label newUserNameLbl;
        private System.Windows.Forms.Label userCreationPageTitle;
        private System.Windows.Forms.TextBox newUserConfirmPasswordInsert;
        private System.Windows.Forms.TextBox newUserPasswordInsert;
        private System.Windows.Forms.TextBox newUserNameInsert;
        private System.Windows.Forms.Label logInRedirection;
        private System.Windows.Forms.Button createAccountBtn;
        private System.Windows.Forms.PictureBox helpBtn;
    }
}