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
            Controller.AssignPasswordVaultEvents(showPasswordBtn_Click, updateBtn_Click, txt_TextChanged, deleteBtn_Click); //Link event methods to object dynamically created
            Controller.DisplayPasswordData(); //Display data relate to the websites registered
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
            if (sender is Button btn) //Allow us to access the object property
            {
                Controller.ManagePasswordVisibility(btn.Name); //Manage password visibility according to the index
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn) //Allow us to access the object property
            {
                Controller.EditPasswordData(btn.Name); //Edit password data
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txt) //Allow us to access the object property
            {
                Controller.EditPasswordData(txt.Name); //Edit password data
                Controller.CurrentTextBox(txt); //Specify the textBox changing
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox picture) //Allow us to access the object property
            {
                Controller.ErasePasswordData(picture.Name); //Erase password data
            }
        }
    }
}