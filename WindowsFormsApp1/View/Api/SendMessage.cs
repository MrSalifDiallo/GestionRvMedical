using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.View.Api
{
    public class SendMessage
    {
        private readonly string phoneNumberId;
        private readonly string accessToken;

        public SendMessage()
        {
            // Lecture depuis App.config
            phoneNumberId = ConfigurationManager.AppSettings["PhoneNumberId"];
            accessToken = ConfigurationManager.AppSettings["AccessToken"];
        }

        public async Task<string> SendTextMessage(string toPhoneNumber, string messageText)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var messageData = new
            {
                messaging_product = "whatsapp",
                to = toPhoneNumber,
                type = "text",
                text = new { body = messageText }
            };

            string json = JsonConvert.SerializeObject(messageData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = $"https://graph.facebook.com/v15.0/{phoneNumberId}/messages";

            HttpResponseMessage response = await client.PostAsync(url, content);

            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return "Message WhatsApp envoyé avec succès.";
            }
            else
            {
                return $"Erreur WhatsApp : {response.StatusCode} - {responseContent}";
            }
        }
    }
}
