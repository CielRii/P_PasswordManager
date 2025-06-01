using PasswordManager_App; //
using System.Windows.Forms;

namespace BankTests
{
    [TestClass]
    public class UnitTest1
    {
        //Initialization of the MCD model 
        private Model model = new Model();
        private HomePage home = new HomePage();
        private Controller controller;

        /* FOR AUTHENTIFICATION */

        [TestMethod]
        public void CheckLogin_NameCorrect_masterPasswordIncorrect()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "alice";
            string masterPassword = "notTheRightmasterPassword";

            //Act
            bool result = controller.CheckLogin(username, masterPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckLogin aurait dû échouer avec un mauvais mot de passe.");
        }

        [TestMethod]
        public void Login_NameIncorrect_masterPasswordCorrect()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "notTheRightUser";
            string masterPassword = "hashpass1";

            //Act
            bool result = controller.CheckLogin(username, masterPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckLogin aurait dû échouer avec un mauvais nom d'utilisateur.");
        }

        [TestMethod]
        public void Login_NameIncorrect_masterPasswordIncorrect()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "notTheRightUser";
            string masterPassword = "notTheRightmasterPassword";

            //Act
            bool result = controller.CheckLogin(username, masterPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckLogin aurait dû échouer avec un mauvais nom d'utilisateur et un mauvais mot de passe.");
        }

        [TestMethod]
        public void Login_NameCorrect_masterPasswordCorrect()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "alice";
            string masterPassword = "hashpass1";

            //Act
            bool result = controller.CheckLogin(username, masterPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckLogin aurait dû réussir avec un nom d'utilisateur reconnu et un mot de passe reconnu.");
        }






        /* FOR USER ACCOUNT CREATION */
        [TestMethod]
        public void AccountCreation_NameUnAvailable()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "alice";

            //Act
            bool result = controller.CheckUserAvailable(username);

            //Assert
            Assert.IsFalse(result, "La méthode CheckUserAvailable aurait dû échouer avec un nom d'utilisateur déjà utilisé.");
        }

        [TestMethod]
        public void AccountCreation_DifferentPasswords()
        {
            // Arrange
            controller = new Controller(model, home);
            string password = "randomPassword1";
            string confirmPassword = "randomPassword2";

            //Act
            bool result = controller.CheckPassword(password, confirmPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckPassword aurait dû échouer avec des mots de passe différents.");
        }

        [TestMethod]
        public void AccountCreation_PasswordNonCompliant()
        {
            // Arrange
            controller = new Controller(model, home);
            string password = "simplePassword";
            string confirmPassword = "simplePassword";

            //Act
            bool result = controller.CheckPassword(password, confirmPassword);

            //Assert
            Assert.IsFalse(result, "La méthode CheckPassword aurait dû échouer avec un mot de passe ne respectant pas la politique de sécurité de l'entreprise.");
        }







        /* FOR PASSWORD GENERATION */
        [TestMethod]
        public void PasswordGeneration_NumberOfCharactersNonCompliant()
        {
            // Arrange
            controller = new Controller(model, home);
            int nbOfCharacters = 0 ;
            bool numberOption = true;
            bool capitalLetterOption = true;
            bool specialCharacterOption = true;


            //Act
            string result = controller.GeneratePassword(nbOfCharacters, numberOption, capitalLetterOption, specialCharacterOption);

            //Assert
            Assert.AreEqual(null, result, "La méthode GeneratePassword aurait dû échouer avec un mot de passe ne respectant pas le minimun requis.");
        }







        /* FOR BACKING PASSWORD UP */
        [TestMethod]
        public void PasswordBackup_EmptyField()
        {
            // Arrange
            controller = new Controller(model, home);
            string username = "";
            string password = "randomPassword";
            string website = "randomWebsite";

            //Act
            bool result = controller.WebsiteDataBackup(username, password, website);

            //Assert
            Assert.IsFalse(result, "La méthode WebsiteDataBackup aurait dû échouer car une valeur est manquante.");
        }
    }
}