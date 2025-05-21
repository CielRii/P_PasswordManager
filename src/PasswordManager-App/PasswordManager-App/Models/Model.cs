///ETML
///Author: Sarah Dongmo
///Creation date: 20.0.25
///Last modification: 02.04.25
///Description : this page helps for the management of the data include in the app.
///              It also helps for the connexion between the app and the database.

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager_App
{
    public class Model
    {
        // Reference to the controller
        public Controller Controller { get; set; }

        public MySqlConnection Connection { get; set; }

        private MySqlCommand cmd;
        private MySqlDataReader dataReader;
        private int userID;
        public byte[] salt;

<<<<<<< HEAD
        //private string dataQuery = "SELECT w.name, w.username, w.password " +
        //        "FROM `t_website` w JOIN `manage` m ON w.website_id = m.website_id " +
        //        "JOIN `t_user` u ON u.user_id = m.user_id " +
        //        "WHERE u.user_id =  @userID; ";


=======
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        // Connection to the database
        public bool IsConnect()
        {
            if (Connection == null)
            {
                string connstring = "server='localhost'; port='6033'; database='setup_database'; UID='root'; password='root'";

                try
                {
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return true;
        }

        // Disconnection from the database
        public void DisConnect()
        {
            Connection.Close();
        }

        // Check login data validity
        public bool CheckLogin(string username, string password)
        {
            if (!IsConnect()) return false;

            string query = "SELECT * FROM t_user WHERE `username` = @username;"; //Secure request
            cmd = new MySqlCommand(query, Connection); //Send the request to the database
            cmd.Parameters.AddWithValue("@username", username); //Bind the parameters
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                //Retrieve actual user id
                userID = dataReader.GetInt32(0);

                if (dataReader.GetString(1) == username)
                {
                    if (dataReader.GetString(2) == password)
                    {
                        dataReader.Close();
                        return true;
                    }
                }
            }

            dataReader.Close();
            DisConnect();
            return false;
        }

<<<<<<< HEAD
=======
        // Retrieve user id
        public int RetrieveUserID()
        {
            return userID;
        }

>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        // Retrieve the salt of the master password
        public byte[] GetSalt(string username)
        {
            if (!IsConnect()) return null;

            string query = "SELECT salt FROM t_user WHERE `username` = @username;"; //Secure request
            cmd = new MySqlCommand(query, Connection); //Send the request to the database
            cmd.Parameters.AddWithValue("@username", username); //Bind the parameters
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                salt = (byte[])dataReader.GetValue(0);
            }

            dataReader.Close();
            return salt;
        }

<<<<<<< HEAD
=======
        // Check if username is avaible
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        public bool CheckUserAvaible(string username)
        {
            if (!IsConnect()) return false;

            string query = "SELECT username FROM t_user;";
            cmd = new MySqlCommand(query, Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetString(0) == username)
                {
                    dataReader.Close();
                    DisConnect();
                    return false;
                }
            }

            dataReader.Close();
            return true;
        }

<<<<<<< HEAD
=======
        // Create a new user
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        public bool CreateUser(string username, string password, byte[] salt)
        {
            if (!IsConnect()) return false;

            string query = "INSERT INTO `t_user`(user_id, username, password, salt) VALUES(NULL, @username, @password, @salt);";

            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Prepare(); //
            cmd.ExecuteNonQuery();
            return true;
        }

        // Add passwords and data related to them
        public bool AddPassword(string username, string password, string website)
        {
            if (!IsConnect()) return false;

            string query = "INSERT INTO `t_website`(website_id, name, username, password)" +
                "VALUES (NULL, @name, @username, password);";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@name", website);
            cmd.Prepare(); //
            cmd.ExecuteNonQuery();
            return true;
        }

<<<<<<< HEAD
=======
        // Count number of user data line 
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
        public int NumberOfData()
        {
            if (!IsConnect()) return 0;

            string query = "SELECT COUNT(*) FROM(SELECT w.name, w.username, w.password " +
                "FROM `t_website` w JOIN `manage` m ON w.website_id = m.website_id JOIN `t_user` u ON u.user_id = m.user_id " +
                "WHERE u.user_id =  @userID) AS subquery;";
            int nb = 0;
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@userID", 1);
            dataReader = cmd.ExecuteReader(); //
            while (dataReader.Read())
            {
                nb = dataReader.GetInt32(0);
            }
            dataReader.Close();
            return nb * 3; //
        }

        // Send an array of data registered for passwords
<<<<<<< HEAD
        public string [] DisplayPasswordData()
        {
            if (!IsConnect()) return null;
=======
        public string [] DisplayPasswordData(int userID)
        {
            if (!IsConnect()) return null;
            this.userID = userID;
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c

            string query = "SELECT w.name, w.username, w.password " +
                "FROM `t_website` w JOIN `manage` m ON w.website_id = m.website_id " +
                "JOIN `t_user` u ON u.user_id = m.user_id " +
                "WHERE u.user_id =  @userID; ";

            string[] webSites = new string[NumberOfData()]; //Definition of website array with its length

            cmd = new MySqlCommand(query, Connection);
<<<<<<< HEAD
            cmd.Parameters.AddWithValue("@userID", 1);
=======
            cmd.Parameters.AddWithValue("@userID", userID);
>>>>>>> 3bb0ba1d405b490207e11c3ff22abc38bb79a11c
            dataReader = cmd.ExecuteReader();
            int previousI = 0;
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    webSites[i + previousI] = dataReader.GetString(i); //
                    if (i == dataReader.FieldCount - 1)
                        previousI = i + 1;
                }
            }
            dataReader.Close();
            return webSites;
        }

        // Edition of registered password data
        public bool EditPasswordData(string newName, string previousName, string username, string password)
        {
            if (!IsConnect()) return false;

            string query = "UPDATE `t_website` SET `name` = @newName && `username` = @username `password` = @password " +
                "WHERE `name` = @previousName;";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@previousName", previousName);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        // Deletion of registered password data
        public bool ErasePasswordData(string name)
        {
            if (!IsConnect()) return false;

            string query = "DELETE FROM `t_website` WHERE `name` = @name;";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}