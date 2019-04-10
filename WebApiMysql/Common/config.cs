using Newtonsoft.Json.Linq;

namespace WebApiMysql.Common
{
    public class config
    {
        public JObject json { get; set; }
        public setting setting { get { return json["setting"].ToObject<setting>(); } }
        public api[] api { get { return json["api"].ToObject<api[]>(); } }
    }
    public class setting
    {
        private string _uObject;
        private string _pObject;
        private string _uBusiness;
        private string _pBusiness;
        public string uObject { get { return EncryptionHelper.Decrypt(_uObject); } set { _uObject = value; } }
        public string pObject { get { return EncryptionHelper.Decrypt(_pObject); } set { _pObject = value; } }
        public string uBusiness { get { return EncryptionHelper.Decrypt(_uBusiness); } set { _uBusiness = value; } }
        public string pBusiness { get { return EncryptionHelper.Decrypt(_pBusiness); } set { _pBusiness = value; } }
    }
    public class api
    {
        public string ApiName { get; set; }
        public string ApiTokenUrl { get; set; }
        public string ApiUrl { get; set; }
        public string ApiAction { get; set; }
        public string ApiParam { get; set; }
    }
}