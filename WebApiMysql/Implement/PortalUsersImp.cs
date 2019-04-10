using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMysql.Common;
using WebApiMysql.Interface;
using WebApiMysql.Models;

namespace WebApiMysql.Implement
{
    public class PortalUsersImp: IPortalusers
    {
        public List<Users> getListUser()
        {
            List<Users> listUser = new List<Users>();
            var dbCon = DbConnection.Instance();
            //dbCon.DatabaseName = "cvdblog";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM users";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listUser.Add(new Users
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        HOVATEN = reader["HOVATEN"].ToString(),
                        TENDANGNHAP = reader["TENDANGNHAP"].ToString(),
                        NGAYLAP = reader["NGAYLAP"].ToString(),
                    });
                }
                dbCon.Close();
            }
            return listUser;
        }
        public Users CheckUser(string username, string password)
        {
            Users result = new Users();
            string hashPassword = EncryptionHelper.HashPassword(password);
            var dbCon = DbConnection.Instance();
            //dbCon.DatabaseName = "cvdblog";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = String.Format("SELECT * FROM users WHERE TENDANGNHAP = '{0}' AND MATKHAU = '{1}'",username, hashPassword);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.ID = Convert.ToInt32(reader["ID"]);
                    result.HOVATEN = reader["HOVATEN"].ToString();
                    result.TENDANGNHAP = reader["TENDANGNHAP"].ToString();
                    result.NGAYLAP = reader["NGAYLAP"].ToString();
                }
                dbCon.Close();
            }
            return result;
        }
    }
}