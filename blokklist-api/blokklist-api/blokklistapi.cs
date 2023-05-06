using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace blokklist_api
{
    public class blokklistapi
    {
        private static readonly HttpClient client = new();

        public async Task<dynamic> GetUserData(Configuration config, string urlToRequestUser, int _LimitReasons = 0)
        {
            var apiUrl = "https://api.none.mba/user/request";
            var requestBody = new
            {
                UserID = urlToRequestUser,
                Options = new { LimitReasons = _LimitReasons }
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            httpContent.Headers.Clear();
            foreach (var header in config.GetHeaders())
            {
                httpContent.Headers.Add(header.Key, header.Value);
            }

            var response = await client.PostAsync(apiUrl, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseData);
        }
    }
}
