using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMysql.Models;

namespace WebApiMysql.Interface
{
    public interface IPortalusers
    {
        List<Users> getListUser();
        Users CheckUser(string username, string password);
    }
}