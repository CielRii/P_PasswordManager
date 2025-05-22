using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager_App; //

namespace BankTests
{
    [TestClass]
    public class UnitTest1
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        /* FOR AUTHENTIFICATION */
        [TestMethod]
        public void Login_NameCorrect_PasswordIncorrect()
        {
            //Arrange
            Controller.CheckLogin("alice", "notTheRightPassword");

            //Act
            string enteredPassword = "notTheRightPassword";

            //Assert
            string actualPassword = _model.UserPassword("alice");
            Assert.AreEqual(enteredPassword, actualPassword, "Le mot de passe n'est pas correct");

        }

        [TestMethod]
        public void Login_NameIncorrect_PasswordCorrect()
        {
            //Arrange
            Controller.CheckLogin("notTheRightUser", "hashpass1");

            //Act
            string enteredUsername = "notTheRightPassword";

            //Assert
            string actualPassword = _model.UserPassword();
            Assert.AreEqual(enteredUsername, actualPassword, "Le nom d'utilisateur n'est pas reconnu");

        }

        [TestMethod]
        public void Login_NameIncorrect_PasswordIncorrect()
        {
            //Arrange
            Controller.CheckLogin("notTheRightUser", "notTheRightPassword");

            //Act
            string enteredUsername = "notTheRightUser";
            string enteredPassword = "notTheRightPassword";

            //Assert
            string actualUsername = _model.CheckLogin();
            Assert.AreEqual(enteredPassword, actualPassword, "Le nom d'utilisateur n'est pas reconnu");

        }

        /* FOR USER ACCOUNT CREATION */
        public void AccountCreation_NameUnavaible()
        {
            //Arrange
            Controller.CheckLogin("notTheRightUser", "notTheRightPassword");

            //Act
            string enteredUsername = "notTheRightUser";
            string enteredPassword = "notTheRightPassword";

            //Assert
            string actualUsername = _model.Username();
            string actualPassword = _model.UserPassword("alice");
            Assert.AreEqual(enteredPassword, actualPassword, "Le login n'est pas correct");

        }
        public void AccountCreation_DifferentPasswords()
        {
            //Arrange
            Controller.CheckLogin("notTheRightUser", "notTheRightPassword");

            //Act
            string enteredUsername = "notTheRightUser";
            string enteredPassword = "notTheRightPassword";

            //Assert
            string actualUsername = _model.Username();
            string actualPassword = _model.UserPassword("alice");
            Assert.AreEqual(enteredPassword, actualPassword, "Le login n'est pas correct");

        }
        public void AccountCreation_PasswordNonCompliant()
        {
            //Arrange
            Controller.CheckLogin("notTheRightUser", "notTheRightPassword");

            //Act
            string enteredUsername = "notTheRightUser";
            string enteredPassword = "notTheRightPassword";

            //Assert
            string actualUsername = _model.Username();
            string actualPassword = _model.UserPassword("alice");
            Assert.AreEqual(enteredPassword, actualPassword, "Le login n'est pas correct");

        }
    }
}