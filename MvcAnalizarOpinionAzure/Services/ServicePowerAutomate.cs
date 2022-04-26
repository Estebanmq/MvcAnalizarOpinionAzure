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
            string request = "https://prod-81.westeurope.logic.azure.com:443/workflows/63811472ca0b424f8c983454a2e2de34/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=fZc2WbFqZEQ6r707WADj46SM_1byJFLXFfuS9Mfqt34";
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
