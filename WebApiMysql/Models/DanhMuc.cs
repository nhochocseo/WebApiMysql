using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMysql.Models
{
    public class DanhMuc
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int IdDanhMucCha { get; set; }
    }
}