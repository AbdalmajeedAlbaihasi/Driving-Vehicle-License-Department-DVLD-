using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Services
{
    public class BaseApiService
    {
        // إعدادات السيرفر المحلي للتطوير
        protected static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7141/api/") 
        };

        protected async Task<T?> GetAsync<T>(string url)
        {
            try
            {
                var res = await client.GetAsync(url);
                var responseBody = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }

                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default;
                }

                MessageBox.Show($"Error: {res.StatusCode}\n{responseBody}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network Exception: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        protected async Task<bool> PostAsync<T>(string url, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(url, content);
            return res.IsSuccessStatusCode;
        }

        protected async Task<bool> PutAsync<T>(string url, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(url, content);
            return res.IsSuccessStatusCode;
        }

        protected async Task<bool> DeleteAsync(string url)
        {
            var res = await client.DeleteAsync(url);
            return res.IsSuccessStatusCode;
        }

        public static void SetToken(string token)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}