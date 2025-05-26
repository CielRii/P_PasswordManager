///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page allows the user to see data she/he registered in the app.

using System;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public partial class PasswordVaultPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public PasswordVaultPage()
        {
            InitializeComponent();
        }

        private void PasswordVaultPage_Load(object sender, EventArgs e)
        {
            Controller.AssignPasswordVaultEvents(showPasswordBtn_Click, updateBtn_Click, deleteBtn_Click); //
            Controller.DisplayPasswordData();

            //Controller.DisplayButtons();
            //Controller.DisplayMeansToManagePasswordData();
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Controller.MenuData(); //Display the menu
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(4); //Display help message
        }

        private void showPasswordBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                Controller.ManagePasswordVisibility(btn.Name); //Manage password visibility according to the index
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                Controller.EditPasswordData(btn.Name);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox picture)
            {
                Controller.ErasePasswordData(picture.Name);
            }
        }
    }
}