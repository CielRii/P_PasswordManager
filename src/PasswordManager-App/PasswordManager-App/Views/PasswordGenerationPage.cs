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

        }

        private void helpBtn_Click(object sender, EventArgs e)
        {

        }

        private void passwordGenerationBtn_Click(object sender, EventArgs e)
        {
            Controller.GeneratePassword(Convert.ToInt32(nbOfCharactersInsert.Text), numberOption.Checked, capitalLetterOption.Checked,
            specialCharacterOption.Checked);
            Controller.CheckPasswordStrength(passwordStrengthOption.Checked);
        }
    }
}
