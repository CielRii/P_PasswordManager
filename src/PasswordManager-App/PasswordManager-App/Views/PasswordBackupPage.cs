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
            Controller.MenuData();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Controller.HelpMessage(3);
        }

        private void passwordBackupBtn_Click(object sender, EventArgs e)
        {
            Controller.PasswordBackup(userNameInsert.Text, userPasswordInsert.Text, webSiteInsert.Text);
            Controller.EmptyUserInsert(userNameInsert, userPasswordInsert, webSiteInsert);
        }
    }
}
