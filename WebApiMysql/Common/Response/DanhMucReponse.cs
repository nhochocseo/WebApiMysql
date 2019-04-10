using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMysql.Models;

namespace WebApiMysql.Common.Response
{
    public class DanhMucReponse : DanhMuc
    {
        public List<DanhMuc> ListChild { get; set; }
    }
}