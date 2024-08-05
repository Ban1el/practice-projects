using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using HRIS.Models.DTO;
using Newtonsoft.Json.Linq;

namespace HRIS.Utility
{
    public class APIConnection
    {
        private static readonly HttpClient client = new HttpClient();
        private static string baseURI = WebConfigurationManager.AppSettings["API_HRIS"];

        public APIResponse PostRequest(string endpoint, dynamic data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI); // Base address can be customized or omitted

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.Timeout = TimeSpan.FromMinutes(10);
                var response = client.PostAsync(endpoint, content).Result;
                string message = "";

                try
                {
                    //Parse the message
                    JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    message = jsonObject["Message"].ToString();
                }
                catch
                {

                }

                APIResponse dto = new APIResponse
                {
                    statusCode = response.StatusCode,
                    message = message,
                };

                return dto;
            }
        }
    }
}