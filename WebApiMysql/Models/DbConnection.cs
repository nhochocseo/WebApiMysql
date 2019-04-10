using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApiMysql.Models
{
    public class DbConnection
    {
        private DbConnection()
        {
        }
        

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
                _instance = new DbConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            string connstring = string.Format("Server=localhost; database=cvdblog; UID=root; password=");
            connection = new MySqlConnection(connstring);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}