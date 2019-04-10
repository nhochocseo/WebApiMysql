using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiMysql.Common;
using WebApiMysql.Common.Response;

namespace WebApiMysql.Controllers
{
    public class CallApiController : ApiController
    {
        private readonly List<TokenResponese> apiSetting;
        private readonly config config;
        public CallApiController(config config, List<TokenResponese> apiSetting)
        {
            this.apiSetting = apiSetting;
            this.config = config;
        }
        public string GetToken(string u, string p, string apiUrl)
        {
            using (var ctoken = new HttpClient())
            {
                var value = new FormUrlEncodedContent(new Dictionary<string, string> {
                        { "Content-type", "application/x-www-form-urlencoded" },
                        { "grant_type", "password" },
                        { "username", u },
                        { "password", p }
                    });
#if DEBUG
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
                var resToken = ctoken.PostAsync(apiUrl + "token", value).Result;
                if (resToken.IsSuccessStatusCode)
                {
                    var payload = JObject.Parse(resToken.Content.ReadAsStringAsync().Result);
                    var token = payload.Value<string>("access_token");
                    return token;
                }
            }
            return null;
        }
        private object getValue(string method, string queryString, TokenResponese r)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(r.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + r.ApiToken);
                // HTTP GET
                HttpResponseMessage response = client.GetAsync("?" + queryString).Result;
                return response;
            }
        }

        private object postValue(string method, JObject input, TokenResponese r)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(r.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + r.ApiToken);
                // HTTP POST
                HttpResponseMessage response = client.PostAsJsonAsync("", input).Result;
                return response;
            }
        }
        private object callPublicApi(string code, JObject input, string typeValue = "post")
        {
            var item = apiSetting.First(s => s.ApiCode.Equals(code));
            var test = EncryptionHelper.Encrypt("caodungstore");
            item.ApiToken = GetToken(config.setting.uObject, config.setting.pObject, item.ApiTokenUrl);
            var response = new HttpResponseMessage();
            if (typeValue == "post")
            {
                response = (HttpResponseMessage)postValue(item.ApiAction, input, item);
            }
            else if (typeValue == "get")
            {
                var props = input.Properties();
                string inp = string.Empty;
                if (props.Count() > 0)
                {
                    foreach (var i in props)
                    {
                        inp += i.Name + "=" + input.Value<string>(i.Name) + "&";
                    }
                    inp = inp.TrimEnd('&');
                }
                response = (HttpResponseMessage)getValue(item.ApiAction, inp, item);
            }
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<object>().Result;
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
        
        [Route("api/getValuePublic")]
        [HttpPost]
        public object getValuePublic([FromBody] JObject input)
        {
            try
            {
                string code = input.Value<string>("code");
                return callPublicApi(code, input, "get");
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message, WebExceptionStatus.RequestCanceled);
            }
        }
    }
}
