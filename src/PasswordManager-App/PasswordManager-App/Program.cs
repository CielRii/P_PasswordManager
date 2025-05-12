using System;
using System.Windows.Forms;


///ETML
///Author: Sarah Dongmo
///Creation date: 12.05.25
///Last modification: 
///Description : application's entry point

namespace PasswordManager_App
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialization of the MCD model 
            Model model = new Model();
            HomePage home = new HomePage();
            Controller controller = new Controller(model, home);

            //Initialization of all the page
            PasswordBackupPage passwordBackupPage = new PasswordBackupPage();
            PasswordGenerationPage passwordGeneration = new PasswordGenerationPage();
            PasswordVaultPage passwordVault = new PasswordVaultPage();
            UserCreationPage userCreation = new UserCreationPage();

            //Controller's initialization of all page depending on it
            home.Controller = controller;
            passwordBackupPage.Controller = controller;
            passwordGeneration.Controller = controller;
            passwordVault.Controller = controller;
            userCreation.Controller = controller;

            //Initialization of classes in Controller.cs 
            controller.PasswordBackupPage = tasksTodo;
            controller.PasswordGenerationPage = addTask;
            controller.PasswordVaultPage = tasksDone;
            controller.UserCreationPage = userCreation;

            Application.Run(new HomePage());
        }
    }
}
