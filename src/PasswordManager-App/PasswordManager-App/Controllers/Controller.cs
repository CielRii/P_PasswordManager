///ETML
///Author : Sarah Dongmo
///Creation date : 12.05.25
///Last modification : 
///Description : this page links the model with the views.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
        private string masterPassword;
        private byte[] salt;
        private int nbData;
        private Button btn;
        private int index;
        private int x = 135;
        private int y = 468;

        private Label taskLbl;
        private TextBox taskTodoTxt;
        private Panel tasksPnl;

        private string previousName;
        private string previousUsername;
        private string previousPassword;
        private string newName;

        private List<string> helpMessage = new List<string>()
        {
             "Bonjour et bienvenu ! Le but de cette application est de vous permettre de gérer vos différents mots de passe au sein de l'entreprise.",
             "Sur cette page vous pouvez créer un mot de passe si vous n'avez pas encore de compte.",
             "Cette page vous permet de générer des mots de passe sécurisés, car la sécurité passe avant tout.",
             "Sur cette page, vous pouvez enregistrer vos données d'identification des différents comptes créés en ligne ou via des applications.",
             "Grâce à cette page, vous pouvez consulter et modifier vos données d'identification enregistrées. Pour que votre mot de passe, soit affiché en clair, vous pouvez cliquer sur le bouton «Afficher», et le re-masquer en passant par ce même bouton."
        };

        public class WebSite
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

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
        public UserCreationPage UserCreationPage { get; set; }

        // Event methods
        private EventHandler showPasswordDataBtn_Click { get; set; }
        private EventHandler updateBtn_Click { get; set; }
        private EventHandler deleteBtn_Click { get; set; }

        public void AssignPasswordVaultEvents(EventHandler showPasswordDataBtn, EventHandler updateBtn, EventHandler deleteBtn)
        {
            showPasswordDataBtn_Click = showPasswordDataBtn;
            updateBtn_Click = updateBtn;
            deleteBtn_Click = deleteBtn;
        }

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
        public void Redirection(string formName = "") //Optional parameter 
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
                default:
                    _home.Show();
                    break;
            }
        }

        // Show help for understanding a page
        public void HelpMessage(int index)
        {
            MessageBox.Show(helpMessage[index]);
        }

        public void MenuData()
        {
            ListView optionsMenu = new ListView();
            optionsMenu.Location = new Point(12, 12);
            optionsMenu.Name = "optionsMenu";
            optionsMenu.Size = new Size(245, 200);
            optionsMenu.BackColor = Color.AntiqueWhite;
            optionsMenu.ForeColor = Color.BurlyWood;
            //Controls.Add(optionsMenu);
        }

        // Check login data
        public bool CheckLogin(string username, string masterPassword)
        {
            this.username = username;
            if (username != string.Empty && masterPassword != string.Empty)
            {
                if (_model.CheckLogin(username, HashPassword(masterPassword, true)))
                {
                    Redirection("PasswordVaultPage"); //Redirection to access the app
                    this.masterPassword = masterPassword;
                    return true;
                }
                else
                {
                    MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vos identifiants ne sont pas reconnus. Veuillez les re-vérifier ou créer un nouveau compte.");
                return false;
            }
        }


        // Hash password before adding or comparing it to what is in the database... source
        public string HashPassword(string password, bool created)
        {
            // Control the need for the salt
            if (created)
            {
                if (masterPassword != null)
                    salt = Encoding.Default.GetBytes(masterPassword); //
                else
                    salt = _model.GetSalt(username); //Get salt in bytes
            }
            else
            {
                salt = GenerateSalt(); //Generate a salt
            }

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

        // Generate the salt for the password... source
        public static byte[] GenerateSalt(int size = 20)
        {
            using (var rng = new RNGCryptoServiceProvider()) //Secure random generator 
            {
                byte[] salt = new byte[size]; //Definition of the salt size
                rng.GetBytes(salt); //Random bytes
                return salt;
            }
        }

        // Check 
        public bool CheckUserInsert(string username, string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                return true;
            }
            else 
            {
                MessageBox.Show("Veuillez remplir chacun des champs pour créer un compte.");
                return false;
            }
        }

        // Check if the user is available
        public bool CheckUserAvailable(string username)
        {
            if (_model.CheckUserAvailable(username)) //Check it by consulting the database
            { 
                this.username = username;
                return true; 
            }
            else
            {
                MessageBox.Show("Ce nom d'utilisateur n'est pas disponible, veuillez choisir un autre.");
                return false; 
            }
        }

        //
        public bool CheckPassword(string masterPassword, string confirmPassword)
        {
            Regex upperCase = new Regex("([A-Z])");
            Regex lowerCase = new Regex("([a-z])");
            Regex digit = new Regex("([0-9])");
            Regex specials = new Regex("([-/#~%*!?])");

            if (masterPassword.Length >= 14 && upperCase.Matches(masterPassword).Count >= 1 && lowerCase.Matches(masterPassword).Count >= 1 &&
                digit.Matches(masterPassword).Count >= 1 && specials.Matches(masterPassword).Count >= 1) // Controls the password is enough secure
            {
                if (masterPassword == confirmPassword)
                { 
                    _model.CreateUser(username, HashPassword(masterPassword, false), salt); 
                    Redirection("PasswordBackupPage");
                    this.masterPassword = masterPassword;
                    return true;
                } //
                else
                { 
                    MessageBox.Show("Vos deux entrées de mots de passe ne se correpondent pas."); 
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Votre mot de passe n'est pas conforme. Il doit contenir au moins 15 caractères, un chiffre, " +
                "un lettre majuscule, une lettre miniscule et un caractère spécial.");
                return false;
            }
        }

        // Generate a password depending on the user needs
        public string GeneratePassword(int nbOfCharacters, bool nb, bool capitalLetter, bool specialCharacter)
        {
            string characters = "abcdefghijklmnopqrstuvwxyz";

            if (nb)
                characters += "0123456789";
            if (capitalLetter)
                characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (specialCharacter)
                characters += "-/#~%*!?";

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
            // Display of options
            if (passwordStrength)
            {
                PasswordGenerationPage.passwordStrengthLbl.Visible = true;
                PasswordGenerationPage.passwordStrengthPic.Visible = true;
                PasswordGenerationPage.passwordStrengthCursor.Visible = true;
            }
            else
            {
                PasswordGenerationPage.passwordStrengthLbl.Visible = false;
                PasswordGenerationPage.passwordStrengthPic.Visible = false;
                PasswordGenerationPage.passwordStrengthCursor.Visible = false;
            }
            //PasswordGenerationPage.passwordStrengthCursor.Position(x, y);
        }

        // To back up website and data related to it
        public bool WebsiteDataBackup(string username, string password, string website)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(website)) //Check that none field is empty
            {
                _model.AddWebsiteData(username, HashPassword(password, true), website); //Specify 
                MessageBox.Show("Vos données ont bien été enregistrées."); //Message to confirm data backup
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez s'il-vous-plaît remplir chacun des champs."); //Message displayed if at least one field is empty 
                return false;
            }
        }

        // Textboxes cleared
        public void EmptyUserInsert(TextBox username, TextBox password, TextBox website)
        {
            username.Text = null;
            password.Text = null;
            website.Text = null;
        }

        // Display password data registered
        public void DisplayPasswordData()
        {
            List<WebSite> webSites = new List<WebSite>();
            string [] data = _model.DisplayPasswordData(_model.RetrieveUserID()); //Retrieve data based on id of the current user
            nbData = _model.NumberOfData();

            for (int i = 0; i < nbData; i++)
            {
                webSites.Add(new WebSite //
                {
                    Name = data[i],
                    Username = data[i + 1],
                    Password = data[i + 2]
                });
                i += 2; //Increment of two as 2 other columns are filled
            }

            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            PasswordVaultPage.Controls.Add(dataGridView); //Add of the array on the "PasswordVaultPage"
            dataGridView.DataSource = webSites;

            // Customized headers
            dataGridView.Columns["Name"].HeaderText = "Site";
            dataGridView.Columns["Username"].HeaderText = "Nom d'utilisateur";
            dataGridView.Columns["Password"].HeaderText = "Mot de passe";
        }

        // Display of buttons and icons to manage password data
        public void DisplayMeansToManagePasswordData()
        {
            index = 0;
            for (int i = 0; i < nbData/3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    btn = new Button();
                    //btn.BackColor = randomSolution[m];
                    btn.FlatStyle = FlatStyle.Popup;
                    if (j == 0)
                    {
                        btn.Name = "showPassword" + "Btn" + index;
                        btn.Text = "Afficher";
                        btn.Click += new EventHandler(showPasswordDataBtn_Click); //
                    }
                    else
                    {
                        btn.Name =  "updateData" + "Btn" + index;
                        btn.Text = "Update";
                        btn.Click += new EventHandler(updateBtn_Click);
                        index++; //Increment of index for both type of buttons
                    }

                    PasswordVaultPage.Controls.Add(btn);
                    btn.Height = 28;
                    btn.Width = 58;
                    btn.Location = new Point(x, y);
                    x += 58;
                }
                
                PictureBox deleteBtn = new PictureBox()
                {
                    Name = "deleteBtn" + index,
                    Size = new Size(26, 24),
                    Location = new Point(x, y),
                    Image = Image.FromFile(@"C:\Users\sardongmo\Desktop\P_PasswordManager\resources\images\deleteBtn.png"),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                deleteBtn.Click += new EventHandler(deleteBtn_Click); //Add of an event to handle further operations
                PasswordVaultPage.Controls.Add(deleteBtn);
                y += 28;
                x = 14;
            }            
        }
        //AssignEvents(EventHandler updateBtn, EventHandler deleteBtn)

        // Edition of registered password data
        public void EditPasswordData (string newName, string previousName,
        string newUsername, string previousUsername,
        string newPassword, string previousPassword)
        {
            if (newName != previousName || newUsername != previousUsername || newPassword != previousPassword)
                _model.EditPasswordData(newName, previousName, newUsername, newPassword);
        }

        //public void EditPasswordData()
        //{
        //    previousName = taskLbl.Text;
        //    previousUsername =;
        //    previousPassword =;
        //    taskTodoTxt = new TextBox();
        //    taskTodoTxt.Text = taskLbl.Text;
        //    taskTodoTxt.Location = taskLbl.Location;
        //    taskTodoTxt.Visible = true;
        //    taskLbl.Visible = false;
        //    taskTodoTxt.KeyDown += taskTodoTxt_KeyDown;

        //    tasksPnl.Controls.Add(taskTodoTxt);
        //}
        public void EditPasswordData()
        {
            //Se répérer grâce à un index

            //previousName = taskLbl.Text;
            //previousUsername =;
            //previousPassword =;
            //taskTodoTxt = new TextBox();
            //taskTodoTxt.Text = taskLbl.Text;
            //taskTodoTxt.Location = taskLbl.Location;
            //taskTodoTxt.Visible = true;
            //taskLbl.Visible = false;
            //taskTodoTxt.KeyDown += taskTodoTxt_KeyDown;

            //tasksPnl.Controls.Add(taskTodoTxt);
        }

        // Deletion of registered password data
        public void ErasePasswordData (string name)
        {
            _model.ErasePasswordData(name);
        }
    }
}