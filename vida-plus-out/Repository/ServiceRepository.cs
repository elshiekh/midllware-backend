using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace vida_plus_out.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public ServiceRepository()
        {
            HttpClientHandler handler = new HttpClientHandler();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ConnectionStrings:VidaURLConn"].ToString());
            byte[] cred = Encoding.UTF8.GetBytes("qwidmzi_occFGSkOPp9vDV3w1hrJ55uZB2dAR7E5AWajBfq_epABioNBT0FMtrSH5NXA:bsrbcwf_MBSC8wwFDrpZGHaitd_NTlzY30Ivon0XNkxETI3lqL3wd9Og5Y5yg2gI7eWSWgHDUhwX05Fxn9wKnAi9DapgRCqNDsZxX2VoxX1m");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/service/branch?limit=30&page=1");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(string.Empty, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Client.BaseAddress = new Uri("https://staging-open-api.elevatustesting.xyz/");
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); ;
            //Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //var username = "qwidmzi_occFGSkOPp9vDV3w1hrJ55uZB2dAR7E5AWajBfq_epABioNBT0FMtrSH5NXA";
            //var password = "bsrbcwf_MBSC8wwFDrpZGHaitd_NTlzY30Ivon0XNkxETI3lqL3wd9Og5Y5yg2gI7eWSWgHDUhwX05Fxn9wKnAi9DapgRCqNDsZxX2VoxX1m";
            //string encoded = Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            // Client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
            //Client.DefaultRequestHeaders.Add("Accept","application/json");
            //Client.DefaultRequestHeaders.Add("Content-Type","application/json");
        }
        public HttpResponseMessage GetResponse(string url)
        {
            try
            {
                var ccc = Client.GetAsync(url).Result;
                return ccc;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
