using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy_Out.Helper
{
    public class HttpClientHelper
    {
        private  readonly  DBOption _dbOption;
        public HttpClientHelper(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        public async Task<TOut> ExecuteRequestAsync<TIn, TOut>(TIn request,string url,HttpMethod methodType )
        {
            var requestUri = new Uri(url);
            var payload = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage()
            {
                Method = methodType,
                RequestUri = requestUri,
                Content = httpContent
            };

            return await SendUriAsync<TOut>(requestMessage);
        }


        public  async Task<T> SendUriAsync<T>(HttpRequestMessage requestMessage)
        {
            using (var client = CreateClient())
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                requestMessage.Content = new StringContent(string.Empty, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);

                var result = await client.SendAsync(requestMessage);
                result.EnsureSuccessStatusCode();
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        private  HttpClient CreateClient()
        {
            byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
            var client = new HttpClient();
            client.BaseAddress = new Uri(_dbOption.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
         
            return client;
        }
    }
}
