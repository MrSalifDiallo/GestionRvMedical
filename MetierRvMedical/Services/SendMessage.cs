using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace MetierRvMedical.Services
{
    public class SendMessage
    {
        string phoneNumberId = ConfigurationManager.AppSettings["phoneNumberId"];
        string accessToken = ConfigurationManager.AppSettings["accessToken"];

        //23889205347432243
        //EAAKEze4mGpEBPHDUFfr26tY7ip5kiJIwF7jFkZBhKC22BrvvmB05awVbBDZBxsnZBUrYbXfJPYDlSTZCjVZClw4R24BhLJvVrzlg59wZAMRhnWGLH7LDz54TZCfxzPuxn6pP7NjZCVVs7hqG9yZCHMDNhPIdQlSMOC99AZAxjirQtVZARzJfGWKJQvtMICDuzGUPK10n7CCaI2pDFXRunRNuQ9C5GAK7lJr1UCZAxC55ZAUDzqzEijQZDZD

        public async Task SendTextMessage(string toPhoneNumber, string messageText)
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

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message texte envoyé avec succès !");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Erreur lors de l'envoi : {response.StatusCode} - {error}");
            }
        }
    }
}