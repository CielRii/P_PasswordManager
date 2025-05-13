///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public class Controller
    {
        // Connexion to main page of MCD model 
        private Model _model;
        private HomePage _home;

        // To save new user username after checking avaibility
        private string username;
        private byte[] salt;

        public Controller(Model model, HomePage home)
        {
            _model = model; //Initialization of the model
            _home = home; //Initialization of the main view

            _model.Controller = this;
            _home.Controller = this;
        }

        // Reference to all the app page excluding those of MVC model
        public PasswordBackupPage PasswordBackupPage { get; set; }
        public PasswordGenerationPage PasswordGenerationPage { get; set; }
        public PasswordVaultPage PasswordVaultPage { get; set; }
        public UserCreceationPage UserCreationPage { get; set; }

        // Share of app identity through all app pages
        public void ShareAppID()
        {
            PasswordBackupPage.Text = _home.Text;
            PasswordGenerationPage.Text = _home.Text;
            PasswordVaultPage.Text = _home.Text;
            UserCreationPage.Text = _home.Text;

            PasswordBackupPage.Icon = _home.Icon;
            PasswordGenerationPage.Icon = _home.Icon;
            PasswordVaultPage.Icon = _home.Icon;
            UserCreationPage.Icon = _home.Icon;
        }

        // Redirections management
        public void Redirection(string formName)
        {
            switch (formName)
            {
                case "PasswordBackupPage":
                    PasswordBackupPage.Show();
                    break;
                case "PasswordGenerationPage":
                    PasswordGenerationPage.Show();
                    break;
                case "PasswordVaultPage":
                    PasswordVaultPage.Show();
                    break;
                case "UserCreationPage":
                    UserCreationPage.Show();
                    break;
                //default: _home.Show();
            }
        }

        // Check 
        public void CheckLogin(string username, string password)
        {
            this.username = username;
            if (username != string.Empty && password != string.Empty)
            {
                if (_model.CheckLogin(username, HashPassword(password, true)))
                {
                    Redirection("TasksTodoPage");
                }
                else
                {
                    MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
                }
            }
            else
            {
                MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
            }
        }


        public string HashPassword(string password, bool created)
        {
            // Control the need for the salt
            if (created)
                salt = _model.GetSalt(username); //Get salt in bytes
            else
                salt = GenerateSalt(); //Generate a salt


            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password); //Array with the password convert in bytes
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length]; //Definition of the length of the array that will contains the password and the salt

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length); //Add the password in bytes in the array for salted password
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length); //Add the salt in bytes in the array for salted password

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[salt.Length + hashedBytes.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

        public static byte[] GenerateSalt(int size = 20)
        {
            using (var rng = new RNGCryptoServiceProvider()) //Secure random generator 
            {
                byte[] salt = new byte[size]; //Definition of the salt size
                rng.GetBytes(salt); //Random bytes
                return salt;
            }
        }

        public string GeneratePassword(int nbOfCharacters, bool nb, bool capitalLetter, bool specialCharacter)
        {
            string characters = "abcdefghijklmnopqrstuvwxyz";

            if (nb)
                characters += "0123456789";
            if (capitalLetter)
                characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (specialCharacter)
                characters += "$!?#-_";

            var Charsarr = new char[nbOfCharacters];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            return new String(Charsarr);
        }

        public void CheckPasswordStrength(bool passwordStrength)
        {
            if (passwordStrength)
                ;
        }

    }
}
