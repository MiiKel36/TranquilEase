using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranquilEase.Models
{
    internal class ChatGptAPI
    {
        private static readonly HttpClient client = new HttpClient();

        //To-Do: Tirar do hardCode
        //informações retiradas por segurança
        private string apiKey = ""; // Substitua pela sua chave da API
        private string url = ""; // Endpoint para GPT-3.5-turbo

        public HttpClient ConnectToAiAPI()
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            return client;
        }

        public async Task<string> SendMessageToAI(HttpClient APIConnection, string msgUsuarioForAI)
        {
            string msgSystemForAI = "Seja um profissional de saúde mental em um chat de aplicativo, focado em ansiedade, mas ajude em outros problemas mentais também. Seja breve, use poucos tokens e mantenha sempre esse comportamento profissional\" \"usuario\":\"eu estou me sentindo ansioso, o que posso fazer?";

            // Formato do corpo da requisição para GPT-3.5-turbo
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = msgSystemForAI },
                new { role = "user", content = msgSystemForAI }
            }
            };

            //trasorma "requestBody" para o formato certo para enviar para api
            var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //envia a mensagem para api e pega sua resposta
            var response = await APIConnection.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                //Pega a rsposta do AI
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic objResponse = JsonConvert.DeserializeObject(responseContent);
                

                //trasforma em double a quantidade de tokens usado (para ver quanto estou gastand)
                double objResponseNum = Convert.ToInt32(objResponse["usage"]["total_tokens"]);
                double costApiResponse = objResponseNum * 0.0000275;

                return responseContent + $"\n\nman, vc gastou:{costApiResponse} R$ 💀💀💀";
            }
            else
            {
                //Caso de errado, retorna a mensagem de erro e o statusCode
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"Houve um problema :(\n errorContet:{errorContent} \nStatusCode: {response.StatusCode}";
            }

        }
    }
}
