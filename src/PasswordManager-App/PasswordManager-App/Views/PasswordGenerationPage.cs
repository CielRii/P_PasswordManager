///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page allows the user to generate a pasword with the possibility to check its strength.

using System;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public partial class PasswordGenerationPage : Form
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public PasswordGenerationPage()
        {
            InitializeComponent();
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Controller.MenuData(); //Display the menu
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(2); //Display help message
        }

        private void passwordGenerationBtn_Click(object sender, EventArgs e)
        {
            Controller.EmptyUserInsert(passwordInsert); //Clear password textbox before adding new data
            passwordInsert.AppendText(Controller.GeneratePassword
            (Convert.ToInt32(nbOfCharactersInsert.Text), numberOption.Checked, capitalLetterOption.Checked, specialCharacterOption.Checked)); //Display of the generated password
        }

        private void passwordInsert_TextChanged(object sender, EventArgs e)
        {
            Controller.CheckPasswordStrength(passwordStrengthOption.Checked); //Check password strength
        }
    }
}