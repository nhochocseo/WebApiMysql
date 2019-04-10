using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMysql.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string HOVATEN { get; set; }
        public string TENDANGNHAP { get; set; }
        public string MATKHAU { get; set; }
        public string NGAYLAP { get; set; }
    }
}