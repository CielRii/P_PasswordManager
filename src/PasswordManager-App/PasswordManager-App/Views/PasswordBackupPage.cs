///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page allows the user to save passwords related to accounts created online.

using System;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public partial class PasswordBackupPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public PasswordBackupPage()
        {
            InitializeComponent();
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Controller.MenuData(); //Display the menu
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(3); //Display help message
        }

        private void passwordBackupBtn_Click(object sender, EventArgs e)
        {
            if (Controller.WebsiteDataBackup(userNameInsert.Text, userPasswordInsert.Text, webSiteInsert.Text)) //Back up website data
                Controller.EmptyUserInsert(userNameInsert, userPasswordInsert, webSiteInsert); //Clear textboxes if data have been backed up
        }
    }
}
