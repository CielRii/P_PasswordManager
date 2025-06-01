namespace PasswordManager_App
{
    partial class PasswordVaultPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordVaultPage));
            this.PasswordVaultTitle = new System.Windows.Forms.Label();
            this.optionsBtn = new System.Windows.Forms.PictureBox();
            this.helpBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordVaultTitle
            // 
            this.PasswordVaultTitle.AutoSize = true;
            this.PasswordVaultTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordVaultTitle.Location = new System.Drawing.Point(273, 113);
            this.PasswordVaultTitle.Name = "PasswordVaultTitle";
            this.PasswordVaultTitle.Size = new System.Drawing.Size(114, 25);
            this.PasswordVaultTitle.TabIndex = 25;
            this.PasswordVaultTitle.Text = "Mon coffre";
            // 
            // optionsBtn
            // 
            this.optionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("optionsBtn.Image")));
            this.optionsBtn.Location = new System.Drawing.Point(558, 36);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(26, 41);
            this.optionsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionsBtn.TabIndex = 24;
            this.optionsBtn.TabStop = false;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(590, 36);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(31, 38);
            this.helpBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.helpBtn.TabIndex = 23;
            this.helpBtn.TabStop = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // PasswordVaultPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 461);
            this.Controls.Add(this.PasswordVaultTitle);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.helpBtn);
            this.Name = "PasswordVaultPage";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.PasswordVaultPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optionsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PasswordVaultTitle;
        private System.Windows.Forms.PictureBox optionsBtn;
        private System.Windows.Forms.PictureBox helpBtn;
    }
}