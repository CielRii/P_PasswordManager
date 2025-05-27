///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page allows the user to create an account for using the app.

using System;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public partial class UserCreationPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public UserCreationPage()
        {
            InitializeComponent();
        }

        private void UserCreationPage_Load(object sender, EventArgs e)
        {
            // Hide passwords when typing
            Controller.HidePassword(newUserPasswordInsert);
            Controller.HidePassword(newUserConfirmPasswordInsert);
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(1); //Display help message
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            if (Controller.CheckUserInsert(newUserNameInsert.Text, newUserPasswordInsert.Text, newUserConfirmPasswordInsert.Text)) //Check textboxes state
            {
                if (Controller.CheckUserAvailable(newUserNameInsert.Text)) //Check if the user is available
                {
                    if (Controller.CheckPassword(newUserPasswordInsert.Text, newUserConfirmPasswordInsert.Text)) //Check if passwords are alike
                    {
                        Hide(); //Hide the actual page if logni validated
                    }
                }
            }
        }

        private void logInRedirection_Click(object sender, EventArgs e)
        {
            Controller.Redirection(); //Redirection to the homepage
            Hide(); //Hide the actual page because of the change of active page
        }
    }
}