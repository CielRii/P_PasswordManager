namespace PasswordManager_App
{
    partial class HomePage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.connexionBtn = new System.Windows.Forms.Button();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.homePageTitle = new System.Windows.Forms.Label();
            this.createAccountRedirection = new System.Windows.Forms.Label();
            this.userNameInsert = new System.Windows.Forms.TextBox();
            this.passwordInsert = new System.Windows.Forms.TextBox();
            this.helpBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // connexionBtn
            // 
            this.connexionBtn.Location = new System.Drawing.Point(254, 309);
            this.connexionBtn.Name = "connexionBtn";
            this.connexionBtn.Size = new System.Drawing.Size(134, 47);
            this.connexionBtn.TabIndex = 1;
            this.connexionBtn.Text = "Se connecter";
            this.connexionBtn.UseVisualStyleBackColor = true;
            this.connexionBtn.Click += new System.EventHandler(this.connexionBtn_Click);
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Location = new System.Drawing.Point(186, 183);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(90, 13);
            this.userNameLbl.TabIndex = 2;
            this.userNameLbl.Text = "Nom d\'utilisateur :";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(186, 238);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(77, 13);
            this.passwordLbl.TabIndex = 3;
            this.passwordLbl.Text = "Mot de passe :";
            // 
            // homePageTitle
            // 
            this.homePageTitle.AutoSize = true;
            this.homePageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePageTitle.Location = new System.Drawing.Point(166, 107);
            this.homePageTitle.Name = "homePageTitle";
            this.homePageTitle.Size = new System.Drawing.Size(310, 25);
            this.homePageTitle.TabIndex = 4;
            this.homePageTitle.Text = "Gestionnaire de mots de passe";
            // 
            // createAccountRedirection
            // 
            this.createAccountRedirection.AutoSize = true;
            this.createAccountRedirection.Location = new System.Drawing.Point(513, 421);
            this.createAccountRedirection.Name = "createAccountRedirection";
            this.createAccountRedirection.Size = new System.Drawing.Size(130, 13);
            this.createAccountRedirection.TabIndex = 0;
            this.createAccountRedirection.Text = "Créer un nouveau compte";
            this.createAccountRedirection.Click += new System.EventHandler(this.createAccountRedirection_Click);
            // 
            // userNameInsert
            // 
            this.userNameInsert.Location = new System.Drawing.Point(295, 183);
            this.userNameInsert.Name = "userNameInsert";
            this.userNameInsert.Size = new System.Drawing.Size(181, 20);
            this.userNameInsert.TabIndex = 5;
            // 
            // passwordInsert
            // 
            this.passwordInsert.Location = new System.Drawing.Point(295, 238);
            this.passwordInsert.Name = "passwordInsert";
            this.passwordInsert.Size = new System.Drawing.Size(181, 20);
            this.passwordInsert.TabIndex = 6;
            // 
            // helpBtn
            // 
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(598, 34);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 38);
            this.helpBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.helpBtn.TabIndex = 7;
            this.helpBtn.TabStop = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 461);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.passwordInsert);
            this.Controls.Add(this.userNameInsert);
            this.Controls.Add(this.homePageTitle);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.connexionBtn);
            this.Controls.Add(this.createAccountRedirection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button connexionBtn;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label homePageTitle;
        private System.Windows.Forms.Label createAccountRedirection;
        private System.Windows.Forms.TextBox userNameInsert;
        private System.Windows.Forms.TextBox passwordInsert;
        private System.Windows.Forms.PictureBox helpBtn;
    }
}

