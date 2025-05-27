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
        private int nbOfData;
        private int indexData;
        private Button btn;
        private int index;
        private int x = 14;
        private int y = 14;
        //private int x = 135;
        //private int y = 468;

        private string[] titles = { "Site", "Nom d'utilisateur", "Mot de passe" };
        private string[] data;

        private int nbOfColumns;
        private const int NB_OF_BTNS = 2;
        private Label lbl;
        private List<Label> lblList;
        private string[] passwords;
        private List<string> passwordList;
        private List<Label> passwordLblList;
        private List<Label> websiteLblList;
        private List<WebSite> websiteData;
        private List<WebSiteUpdate> websiteUpdateData;
        private bool hidden = true;

        private TextBox txt;
        private List<TextBox> txtList;
        private string previousName;
        private string previousUsername;
        private string previousPassword;
        private string newName;
        private string newUsername;
        private string newPassword;
        private WebSite website;
        private bool updating = false;


        private string characters;
        private Char[] Charsarr;
        private Random random;

        // Management of regex
        private Regex upperCase = new Regex("([A-Z])");
        private Regex lowerCase = new Regex("([a-z])");
        private Regex digit = new Regex("([0-9])");
        private Regex specials = new Regex("([-/#~%*!?])");

        // List containing help message for all app pages
        private List<string> helpMessage = new List<string>()
        {
             "Bonjour et bienvenu ! Le but de cette application est de vous permettre de gérer vos différents mots de passe au sein de l'entreprise.",
             "Sur cette page vous pouvez créer un mot de passe si vous n'avez pas encore de compte.",
             "Cette page vous permet de générer des mots de passe sécurisés, car la sécurité passe avant tout.",
             "Sur cette page, vous pouvez enregistrer vos données d'identification des différents comptes créés en ligne ou via des applications.",
             "Grâce à cette page, vous pouvez consulter et modifier vos données d'identification enregistrées. " +
            "Pour que votre mot de passe, soit affiché en clair, vous pouvez cliquer sur le bouton «Afficher», et le re-masquer en passant par ce même bouton."
        };

        public class WebSite
        {
            public Label Name { get; set; }
            public Label Username { get; set; }
            public Label Password { get; set; }
        }

        public class WebSiteUpdate
        {
            public TextBox Name { get; set; }
            public TextBox Username { get; set; }
            public TextBox Password { get; set; }
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
        private EventHandler showPasswordBtn_Click { get; set; }
        private EventHandler updateBtn_Click { get; set; }
        private EventHandler deleteBtn_Click { get; set; }

        // Assign event methods for password vault automatically saltCreated elements
        public void AssignPasswordVaultEvents(EventHandler showPasswordBtn, EventHandler updateBtn, EventHandler deleteBtn)
        {
            showPasswordBtn_Click = showPasswordBtn;
            updateBtn_Click = updateBtn;
            deleteBtn_Click = deleteBtn;
        }

        // Share of app identity through all app pages
        public void ShareAppID(String appName, Icon appIcon)
        {
            // Share app name
            PasswordBackupPage.Text = appName;
            PasswordGenerationPage.Text = appName;
            PasswordVaultPage.Text = appName;
            UserCreationPage.Text = appName;

            // Share app icon 
            PasswordBackupPage.Icon = appIcon;
            PasswordGenerationPage.Icon = appIcon;
            PasswordVaultPage.Icon = appIcon;
            UserCreationPage.Icon = appIcon;
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

        // Hide password when typing
        public void HidePassword(TextBox passwordTxt)
        {
            passwordTxt.UseSystemPasswordChar = true; 
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
        public string HashPassword(string password, bool saltCreated)
        {
            // Control the need for the salt
            if (saltCreated)
            {
                if (masterPassword != null)
                    salt = Encoding.Default.GetBytes(masterPassword); //Get masterPassword bytes
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

        // Check new user password 
        public bool CheckPassword(string masterPassword, string confirmPassword)
        {
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
            characters = "abcdefghijklmnopqrstuvwxyz"; //Add default characters

            if (nb)
                characters += "0123456789"; //Add numbers
            if (capitalLetter)
                characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Add capital letters
            if (specialCharacter)
                characters += "-/#~%*!?"; //Add special characters

            Charsarr = new char[nbOfCharacters]; //Define the length
            random = new Random();

            for (int i = 0; i < Charsarr.Length; i++) //
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

        // Back up website and data related to it
        public bool WebsiteDataBackup(string username, string password, string website)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(website)) //Check that none field is empty
            {
                if (password != masterPassword)
                {
                    if (CheckSecurity(password))
                    {
                        _model.AddWebsiteData(username, HashPassword(password, true), website); //Specify data to register
                        MessageBox.Show("Vos données ont bien été enregistrées."); //Message to confirm data backup
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Pour des raisons de sécurité, nous ne pouvons pas enregistrer ce mot de passe." +
                        "Veuillez choisir un mot de passe différent de celui de votre login sur cette application.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Veuillez s'il-vous-plaît remplir chacun des champs."); //Message displayed if at least one field is empty 
                return false;
            }
        }

        // Handle level of security of password in backing up
        public bool CheckSecurity(string password)
        {
            if (!(masterPassword.Length >= 14 && upperCase.Matches(masterPassword).Count >= 1 && lowerCase.Matches(masterPassword).Count >= 1 &&
            digit.Matches(masterPassword).Count >= 1 && specials.Matches(masterPassword).Count >= 1))
            {
                DialogResult confirmUnsecurePasswordBackup = MessageBox.Show("Ce mot de passe ne répond pas aux normes de sécurité, êtes-vous sûr de vouloir l'enregistrer ?",
                "Confirmation avant sauvegarde", MessageBoxButtons.YesNo);
                switch (confirmUnsecurePasswordBackup)
                {
                    case DialogResult.Yes:
                        return true;
                    case DialogResult.No:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }

        }

        // Textboxes cleared
        public void EmptyUserInsert(TextBox password, TextBox username = null, TextBox website = null)
        {
            password.Text = null;
            username.Text = null;
            website.Text = null;
        }

        // Display password data registered plus buttons and icons to manage those data
        public void DisplayPasswordData()
        {
            data = _model.DisplayPasswordData(_model.RetrieveUserID()); //Retrieve data based on id of the current user

            nbOfData = data.Length;
            x = 12;
            y = 153;

            nbOfColumns = titles.Length;
            for (int i = 0; i < titles.Length; i++)
            {
                lbl = new Label();
                lbl.Text = titles[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Width = 158;
                lbl.Height = 28;
                lbl.Location = new Point(x, y);
                PasswordVaultPage.Controls.Add(lbl);
                x += 158;
            }
            y += 28; //Consider the heigth of the textbox for incrementation
            x = 12; //Reinitialisation of the position

            index = 0;
            indexData = 0; //To mangage the different user data
            lblList = new List<Label>();
            passwordList = new List<string>();
            passwordLblList = new List<Label>();
            websiteLblList = new List<Label>();
            websiteData = new List<WebSite>();
            for (int i = 0; i < nbOfData / nbOfColumns; i++) //As we intialize the variable to 1 instead of 0
            {
                website = new WebSite();
                for (int j = 0; j < nbOfColumns; j++)
                {
                    lbl = new Label();
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Width = 158;
                    lbl.Height = 28;
                    lbl.Location = new Point(x, y); //128, 300

                    switch (i)
                    {
                        case 0 :
                            lbl.Name = "websiteLbl" + index; //Define label name
                            break;
                        case 1:
                            lbl.Name = "usernameLbl" + index;
                            break;
                        case 2 :
                            lbl.Name = "passwordLbl" + index;
                            break;
                    }

                    // Hide password
                    if (j == nbOfColumns - 1)
                    {
                        for (int k = 0; k < data[indexData].Length; k++)//
                        {
                            lbl.Text += "*";
                        }
                        passwordList.Add(data[indexData]); //Add password to password list
                        passwordLblList.Add(lbl); //Add password label to password label list
                        website.Password = lbl; //Add password to Website constructor
                        websiteData.Add(website);
                    }
                    else
                    {
                        lbl.Text = data[indexData];
                        if (j == 0)
                        {
                            websiteLblList.Add(lbl);
                            website.Name = lbl; //Add website name to Website constructor
                        }
                        else
                        {
                            website.Username = lbl; //Add username to Website constructor
                        }
                    }

                    lblList.Add(lbl);
                    PasswordVaultPage.Controls.Add(lbl);
                    indexData ++; //Increase data index
                    x += 158; //Consider the width of the textbox for incrementation
                }

                for (int k = 0; k < NB_OF_BTNS; k++) //...
                {
                    btn = new Button();
                    //btn.BackColor = randomSolution[m];
                    btn.FlatStyle = FlatStyle.Popup;
                    if (k == 0)
                    {
                        btn.Name = "btn" + "ShowPassword" + index;
                        btn.Click += new EventHandler(showPasswordBtn_Click); //Add of an event to handle further operations
                        btn.Text = "Afficher";
                    }
                    else
                    {
                        btn.Name = "btn" + "UpdateData" + index;
                        btn.Click += new EventHandler(updateBtn_Click); //Add of an event to handle further operations
                        btn.Text = "Update";
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
                    SizeMode = PictureBoxSizeMode.Zoom //PictureBoxSizeMode.CenterImage
                };
                deleteBtn.Click += new EventHandler(deleteBtn_Click); //Add of an event to handle further operations
                PasswordVaultPage.Controls.Add(deleteBtn);
                index++; //Increment of index for all element on the line
                //indexData += 3;
                y += 28;
                x = 12;
            }
        }

        // Manage password visibility
        public void ManagePasswordVisibility(string currentData)
        {
            string[] index = Regex.Split(currentData, @"\D+");
            foreach (string currentIndex in index)
            {
                int i;
                if (int.TryParse(currentIndex, out i))
                {
                    lbl = passwordLblList[i]; //Password to manage

                    //lbl.Name = "passwordLbl" + index;
                    //passwords = passwordList.ToArray(); //Convert

                    if (hidden)
                    {
                        lbl.Text = passwordList[i];
                        hidden = false;
                    }
                    else
                    {
                        lbl.Text = null; //Clear the label text before adding on char at time
                        for (int k = 0; k < passwordList[i].Length; k++) //Refer to the length of the current password
                        {
                            lbl.Text += "*"; //Add one char at time
                        }
                        hidden = true;
                    }
                }
            }
        }

        // Edition of registered password data
        public void EditPasswordData (string newName, string newUsername, string newPassword)
        {
            if (newName != previousName || newUsername != previousUsername || newPassword != previousPassword)
                _model.EditPasswordData(newName, previousName, newUsername, newPassword);
        }


        //public bool EditPasswordData(string newName, string previousName, string newUsername, string newPassword)
        public void EditPasswordData(string currentData)
        {
            string index = currentData.Substring(13, currentData.Length - 13); //Help from 
            int i = Convert.ToInt32(index);

            previousName = websiteData[i].Name.Text;
            previousUsername = websiteData[i].Username.Text;
            previousPassword = websiteData[i].Password.Text; //???????????
            websiteData.Add(website);
            websiteUpdateData = new List<WebSiteUpdate>();
            txtList = new List<TextBox>();

            for (int j = 0; j < nbOfColumns; j++)
            {
                if (j == 0)
                   lbl = websiteData[i].Name;
                if (j == 1)
                    lbl = websiteData[i].Username;
                if (j == 2)
                    lbl = websiteData[i].Password;
               
                txt = new TextBox();
                txt.Text = lbl.Text;
                txt.Location = lbl.Location;
                txt.Size = lbl.Size;
                txt.Visible = true;
                lbl.Visible = false;
                txtList.Add(txt);
                PasswordVaultPage.Controls.Add(txt); //Add textbox to password vault page
            }

            if (updating == false) //Data 
            { 
                updating = true; 
            }
            else
            { 
                ControlUserInput(i); 
                updating = false; 
            }
        }

        //
        public void ControlUserInput(int i)
        {
            if (txt != null)
            {
                for (int j = 0; j < nbOfColumns; j++)
                {
                    if (j == 0)
                    {
                        txtList[j] = txt;
                        txt = txtList[j]; //
                        newName = txt.Text;
                        lbl = websiteData[i].Name; //
                    }
                    if (j == 1)
                    {
                        txt = txtList[j];
                        newUsername = txt.Text;
                        lbl = websiteData[i].Username;
                    }
                    if (j == 2)
                    {
                        txt = txtList[j];
                        newPassword = txt.Text;
                        lbl = websiteData[i].Password;
                    }

                    lbl.Text = newName;
                    lbl.Visible = true;
                    txt.Visible = false;
                }
                EditPasswordData(newName, newUsername, newPassword);
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champs ne sont pas remplis. Veuillez les remplir avant de continuer");
                updating = true;
            }
        }

        // Deletion of registered password data
        public void ErasePasswordData (string currentData)
        {
            string[] index = Regex.Split(currentData, @"\D+");
            foreach (string currentIndex in index)
            {
                int i;
                if (int.TryParse(currentIndex, out i))
                {
                    lbl = websiteLblList[i];
                }
            }

            // Confirmation before deletion
            DialogResult confirmErasePasswordData = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les données de ce site internet ?",
            "Confirmation avant suppression", MessageBoxButtons.YesNo);
            if (confirmErasePasswordData == DialogResult.Yes)
            {
                MessageBox.Show("Vos données vont être supprimées.");
                _model.ErasePasswordData(lbl.Text); //Erase the entire line
                DisplayPasswordData(); //Refreshing of screen data 
            }
        }
    }
}