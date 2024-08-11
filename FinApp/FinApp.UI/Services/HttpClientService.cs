using System.Reflection;
using System.Text.Json;
using System.Text;

namespace FinApp.UI.Services {
    public class HttpClientService {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<AgreementService> logger;

        public HttpClientService(IHttpClientFactory httpClientFactory, ILogger<AgreementService> logger) {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url) {
            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.GetAsync(url);

            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data ) {
            var client = httpClientFactory.CreateClient();

            HttpRequestMessage httpRequestMessage = CreateHttpRequestMessage(url, data, HttpMethod.Post);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data) {
            var client = httpClientFactory.CreateClient();

            HttpRequestMessage httpRequestMessage = CreateHttpRequestMessage(url, data, HttpMethod.Put);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }
        public async Task<TResponse?> DeleteAsync<TResponse>(string url) {
            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.DeleteAsync(url);

            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        private static HttpRequestMessage CreateHttpRequestMessage<TRequest>(string url, TRequest data, HttpMethod httpMethod) {
            return new HttpRequestMessage() {
                Method = httpMethod,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
            };
        }
    }
}
