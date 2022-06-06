using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebAPI.HomeTask.ConsoleClient
{
    internal static class RequestHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task GetAsync<T>(string url, Action<T>? onSucces)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            await SendAsync<T>(message, onSucces);
        }

        public static async Task SendAsync<T>(string url, HttpMethod method, object? bodyObject, Action<T>? onSucces)
        {
            var message = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
            };

            if (bodyObject is not null)
            {
                message.Content = JsonContent.Create(bodyObject);
            }

            await SendAsync<T>(message, onSucces);
        }
        public static async Task SendAsync<T>(HttpRequestMessage message, Action<T>? onSucces)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Console.WriteLine($"\n{message.Method.ToString()} request to '{message.RequestUri!.ToString()}'");
            var result = await client.SendAsync(message);
            if (!result.IsSuccessStatusCode)
            {
                Console.WriteLine($"{result.StatusCode} is not Okay. :)");
                Console.WriteLine(result.Content.ReadAsStream());
                return;
            }

            T? resultObject = default(T?);
            if (result.StatusCode != HttpStatusCode.NoContent)
            {
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var jsonString = await result.Content.ReadAsStreamAsync();
                resultObject = await JsonSerializer.DeserializeAsync<T>(jsonString, option);
            }

            onSucces?.Invoke(resultObject);
        }
    }
}
