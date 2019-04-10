using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMysql.Common.Response
{
    public class TokenResponese
    {
        public string ApiCode { get; set; }
        public string ApiToken { get; set; }
        public string ApiTokenUrl { get; set; }
        public string ApiUrl { get; set; }
        public string ApiAction { get; set; }
        public bool IsPublic { get; set; }
        public string UserName { get; set; }
    }
}