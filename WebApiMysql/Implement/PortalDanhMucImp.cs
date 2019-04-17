using api.@base.IoC;
using MySql.Data.MySqlClient;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMysql.Interface;
using WebApiMysql.Models;

namespace WebApiMysql.Implement
{
    public class PortalDanhMucImp : IPortalDanhMuc
    {
        public List<DanhMuc> getListCategory()
        {
            List<DanhMuc> listUser = new List<DanhMuc>();
            var dbCon = DbConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM DanhMuc";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listUser.Add(new DanhMuc
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Ten = reader["TEN"].ToString(),
                        IdDanhMucCha = Convert.ToInt32(reader["IDDANHMUCCHA"]),
                        Url = Convert.ToString(reader["URL"]),
                    });
                }
                dbCon.Close();
            }
            return listUser;
        }
        public int SaveDanhMuc(DanhMuc json)
        {
            List<DanhMuc> listUser = new List<DanhMuc>();
            var dbCon = DbConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = String.Format("INSERT INTO DanhMuc(TEN, IDDANHMUCCHA) VALUES({0}, {1})",json.Ten, json.Id);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var test = reader.ToString();
                }
                dbCon.Close();
            }
            return 1;
        }
    }
}