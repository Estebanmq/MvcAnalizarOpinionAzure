using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcAnalizarOpinionAzure.Services
{
    public class ServicePowerAutomate
    {

        private MediaTypeWithQualityHeaderValue header;

        public ServicePowerAutomate()
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<String> AnalizarOpinionAsync(string opinion)
        {
            string request = "*************************";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                var requestObject = new { opinion = opinion };
                var json = JsonConvert.SerializeObject(requestObject);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    return "Error";
                }

            }
        }

    }
}
