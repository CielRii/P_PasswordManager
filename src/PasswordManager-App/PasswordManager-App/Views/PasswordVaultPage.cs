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
            Controller.DisplayPasswordData();
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Controller.MenuData();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(4);
        }
    }
}
