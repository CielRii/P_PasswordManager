﻿namespace PasswordManager_App
{
    partial class PasswordGenerationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGenerationPage));
            this.helpBtn = new System.Windows.Forms.PictureBox();
            this.optionsBtn = new System.Windows.Forms.PictureBox();
            this.passwordGenerationBtn = new System.Windows.Forms.Button();
            this.passwordInsert = new System.Windows.Forms.TextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.passwordGenerationTitle = new System.Windows.Forms.Label();
            this.capitalLetterOption = new System.Windows.Forms.CheckBox();
            this.numberOption = new System.Windows.Forms.CheckBox();
            this.passwordStrengthOption = new System.Windows.Forms.CheckBox();
            this.specialCharacterOption = new System.Windows.Forms.CheckBox();
            this.nbOfCharactersLbl = new System.Windows.Forms.Label();
            this.nbOfCharactersInsert = new System.Windows.Forms.TextBox();
            this.passwordStrengthLbl = new System.Windows.Forms.Label();
            this.passwordStrengthPic = new System.Windows.Forms.PictureBox();
            this.passwordStrengthCursor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStrengthPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStrengthCursor)).BeginInit();
            this.SuspendLayout();
            // 
            // helpBtn
            // 
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(602, 34);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 38);
            this.helpBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.helpBtn.TabIndex = 8;
            this.helpBtn.TabStop = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // optionsBtn
            // 
            this.optionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("optionsBtn.Image")));
            this.optionsBtn.Location = new System.Drawing.Point(570, 34);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(26, 41);
            this.optionsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionsBtn.TabIndex = 9;
            this.optionsBtn.TabStop = false;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // passwordGenerationBtn
            // 
            this.passwordGenerationBtn.Location = new System.Drawing.Point(282, 318);
            this.passwordGenerationBtn.Name = "passwordGenerationBtn";
            this.passwordGenerationBtn.Size = new System.Drawing.Size(87, 47);
            this.passwordGenerationBtn.TabIndex = 10;
            this.passwordGenerationBtn.Text = "Générer un mot de passe";
            this.passwordGenerationBtn.UseVisualStyleBackColor = true;
            this.passwordGenerationBtn.Click += new System.EventHandler(this.passwordGenerationBtn_Click);
            // 
            // passwordInsert
            // 
            this.passwordInsert.Location = new System.Drawing.Point(269, 254);
            this.passwordInsert.Name = "passwordInsert";
            this.passwordInsert.Size = new System.Drawing.Size(181, 20);
            this.passwordInsert.TabIndex = 11;
            this.passwordInsert.TextChanged += new System.EventHandler(this.passwordInsert_TextChanged);
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(172, 257);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(77, 13);
            this.passwordLbl.TabIndex = 17;
            this.passwordLbl.Text = "Mot de passe :";
            // 
            // passwordGenerationTitle
            // 
            this.passwordGenerationTitle.AutoSize = true;
            this.passwordGenerationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordGenerationTitle.Location = new System.Drawing.Point(186, 87);
            this.passwordGenerationTitle.Name = "passwordGenerationTitle";
            this.passwordGenerationTitle.Size = new System.Drawing.Size(292, 25);
            this.passwordGenerationTitle.TabIndex = 22;
            this.passwordGenerationTitle.Text = "Générer un mot de passe fort";
            // 
            // capitalLetterOption
            // 
            this.capitalLetterOption.AutoSize = true;
            this.capitalLetterOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.capitalLetterOption.Location = new System.Drawing.Point(458, 144);
            this.capitalLetterOption.Name = "capitalLetterOption";
            this.capitalLetterOption.Size = new System.Drawing.Size(113, 17);
            this.capitalLetterOption.TabIndex = 24;
            this.capitalLetterOption.Text = "Lettres majuscules";
            this.capitalLetterOption.UseVisualStyleBackColor = true;
            // 
            // numberOption
            // 
            this.numberOption.AutoSize = true;
            this.numberOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.numberOption.Location = new System.Drawing.Point(313, 144);
            this.numberOption.Name = "numberOption";
            this.numberOption.Size = new System.Drawing.Size(74, 17);
            this.numberOption.TabIndex = 25;
            this.numberOption.Text = "Nombres :";
            this.numberOption.UseVisualStyleBackColor = true;
            // 
            // passwordStrengthOption
            // 
            this.passwordStrengthOption.AutoSize = true;
            this.passwordStrengthOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.passwordStrengthOption.Location = new System.Drawing.Point(337, 198);
            this.passwordStrengthOption.Name = "passwordStrengthOption";
            this.passwordStrengthOption.Size = new System.Drawing.Size(183, 17);
            this.passwordStrengthOption.TabIndex = 26;
            this.passwordStrengthOption.Text = "Vérifier la force du mot de passe :";
            this.passwordStrengthOption.UseVisualStyleBackColor = true;
            // 
            // specialCharacterOption
            // 
            this.specialCharacterOption.AutoSize = true;
            this.specialCharacterOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.specialCharacterOption.Location = new System.Drawing.Point(130, 198);
            this.specialCharacterOption.Name = "specialCharacterOption";
            this.specialCharacterOption.Size = new System.Drawing.Size(128, 17);
            this.specialCharacterOption.TabIndex = 27;
            this.specialCharacterOption.Text = "Caractères spéciaux :";
            this.specialCharacterOption.UseVisualStyleBackColor = true;
            // 
            // nbOfCharactersLbl
            // 
            this.nbOfCharactersLbl.AutoSize = true;
            this.nbOfCharactersLbl.Location = new System.Drawing.Point(121, 145);
            this.nbOfCharactersLbl.Name = "nbOfCharactersLbl";
            this.nbOfCharactersLbl.Size = new System.Drawing.Size(118, 13);
            this.nbOfCharactersLbl.TabIndex = 29;
            this.nbOfCharactersLbl.Text = "Nombre de caractères :";
            // 
            // nbOfCharactersInsert
            // 
            this.nbOfCharactersInsert.Location = new System.Drawing.Point(245, 141);
            this.nbOfCharactersInsert.Name = "nbOfCharactersInsert";
            this.nbOfCharactersInsert.Size = new System.Drawing.Size(43, 20);
            this.nbOfCharactersInsert.TabIndex = 28;
            // 
            // passwordStrengthLbl
            // 
            this.passwordStrengthLbl.AutoSize = true;
            this.passwordStrengthLbl.Location = new System.Drawing.Point(128, 291);
            this.passwordStrengthLbl.Name = "passwordStrengthLbl";
            this.passwordStrengthLbl.Size = new System.Drawing.Size(121, 13);
            this.passwordStrengthLbl.TabIndex = 30;
            this.passwordStrengthLbl.Text = "Force du mot de passe :";
            this.passwordStrengthLbl.Visible = false;
            // 
            // passwordStrengthPic
            // 
            this.passwordStrengthPic.Image = ((System.Drawing.Image)(resources.GetObject("passwordStrengthPic.Image")));
            this.passwordStrengthPic.Location = new System.Drawing.Point(269, 280);
            this.passwordStrengthPic.Name = "passwordStrengthPic";
            this.passwordStrengthPic.Size = new System.Drawing.Size(181, 41);
            this.passwordStrengthPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.passwordStrengthPic.TabIndex = 31;
            this.passwordStrengthPic.TabStop = false;
            this.passwordStrengthPic.Visible = false;
            // 
            // passwordStrengthCursor
            // 
            this.passwordStrengthCursor.BackColor = System.Drawing.Color.Transparent;
            this.passwordStrengthCursor.Image = ((System.Drawing.Image)(resources.GetObject("passwordStrengthCursor.Image")));
            this.passwordStrengthCursor.Location = new System.Drawing.Point(430, 291);
            this.passwordStrengthCursor.Name = "passwordStrengthCursor";
            this.passwordStrengthCursor.Size = new System.Drawing.Size(20, 21);
            this.passwordStrengthCursor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.passwordStrengthCursor.TabIndex = 32;
            this.passwordStrengthCursor.TabStop = false;
            this.passwordStrengthCursor.Visible = false;
            // 
            // PasswordGenerationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 461);
            this.Controls.Add(this.passwordStrengthCursor);
            this.Controls.Add(this.passwordStrengthPic);
            this.Controls.Add(this.passwordStrengthLbl);
            this.Controls.Add(this.nbOfCharactersLbl);
            this.Controls.Add(this.nbOfCharactersInsert);
            this.Controls.Add(this.specialCharacterOption);
            this.Controls.Add(this.passwordStrengthOption);
            this.Controls.Add(this.numberOption);
            this.Controls.Add(this.capitalLetterOption);
            this.Controls.Add(this.passwordGenerationTitle);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.passwordInsert);
            this.Controls.Add(this.passwordGenerationBtn);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.helpBtn);
            this.Name = "PasswordGenerationPage";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStrengthPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStrengthCursor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox helpBtn;
        private System.Windows.Forms.PictureBox optionsBtn;
        private System.Windows.Forms.Button passwordGenerationBtn;
        private System.Windows.Forms.TextBox passwordInsert;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label passwordGenerationTitle;
        private System.Windows.Forms.CheckBox capitalLetterOption;
        private System.Windows.Forms.CheckBox numberOption;
        private System.Windows.Forms.CheckBox passwordStrengthOption;
        private System.Windows.Forms.CheckBox specialCharacterOption;
        private System.Windows.Forms.Label nbOfCharactersLbl;
        private System.Windows.Forms.TextBox nbOfCharactersInsert;
        public System.Windows.Forms.Label passwordStrengthLbl;
        public System.Windows.Forms.PictureBox passwordStrengthPic;
        public System.Windows.Forms.PictureBox passwordStrengthCursor;
    }
}