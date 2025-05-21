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
<<<<<<< HEAD
            Controller.DisplayButtons();
=======
            Controller.DisplayMeansToManagePasswordData();
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Controller.MenuData();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(4);
        }

        public void showPasswordDataBtn_Click(object sender, EventArgs e)
        {

        }

        public void updateBtn_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
           // Controller.EditPasswordData();
=======
            Controller.EditPasswordData();
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
            //(string newName, string previousName, string username, string password)
        }

        public void deleteBtn_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //Controller.ErasePasswordData();
=======
            Controller.ErasePasswordData();
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        }
    }
}
