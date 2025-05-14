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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="done"></param>
        /// <returns></returns>
        public List<string> DisplayTasks(int userID, bool done)
        {
            this.userID = userID;
            List<string> tasks = new List<string>();
            if (!IsConnect()) return null;

            string query = "SELECT * FROM `t_website` t INNER JOIN `t_user` u ON t.user_id = u.user_id " +
               "WHERE u.user_id = @userID && t.done = @done ;";

            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@done", done);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                tasks.Add(dataReader.GetString(0));
            }
            dataReader.Close();
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddTask(string name)
        {
            if (!IsConnect()) return false;

            string query = "INSERT INTO `t_website`(task_id, name, user_id, done)" +
                "VALUES (NULL, @name, @userID, 0);";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DisplayTasks(userID, false);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="previousName"></param>
        /// <returns></returns>
        public bool EditTask(string newName, string previousName)
        {
            if (!IsConnect()) return false;

            string query = "UPDATE `t_website` SET `name` = @newName WHERE `name` = @previousName;";
            cmd = new MySqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@previousName", previousName);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool EraseTask(string name)
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