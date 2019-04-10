using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMysql.Interface;
using WebApiMysql.Models;

namespace WebApiMysql.Controllers
{
    public class UsersController : ApiController
    {
        private IPortalusers _portalUser;

        public UsersController(IPortalusers portalUser)
        {
            this._portalUser = portalUser;
        }
        [HttpGet]
        [Route("api/getListUser")]
        public object getListUser()
        {
            try
            {
                var result = this._portalUser.getListUser();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Login")]
        public Users Login(string username, string password)
        {
            try
            {
                var result = _portalUser.CheckUser(username, password);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
