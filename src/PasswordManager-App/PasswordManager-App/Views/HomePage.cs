using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            passwordInsert.UseSystemPasswordChar = true; //Hide password when taping
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(0);
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            Controller.CheckLogin(userNameInsert.Text, passwordInsert.Text);
            Controller.Redirection("PasswordGenerationPage"); //Redirection to access the app
            Hide();
        }

        private void createAccountRedirection_Click(object sender, EventArgs e)
        {
            Controller.Redirection("UserCreationPage"); //Redirection to create an user
            Hide();
        }
    }
}