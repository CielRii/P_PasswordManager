///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page allows the user to connect to the app.

using System;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public partial class HomePage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Controller.ShareAppID(); //Share of app identity 
            passwordInsert.UseSystemPasswordChar = true; //Hide password when typing
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(0); //Display help message
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            if (Controller.CheckLogin(userNameInsert.Text, passwordInsert.Text)) //Check login
                Hide(); //Hide the actual page if login validated
        }

        private void createAccountRedirection_Click(object sender, EventArgs e)
        {
            Controller.Redirection("UserCreationPage"); //Redirection to create an user
            Hide(); //Hide the actual page because of the change of active page
        }
    }
}