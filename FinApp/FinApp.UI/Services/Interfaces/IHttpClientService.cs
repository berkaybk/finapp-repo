namespace FinApp.UI.Services.Interfaces {
    public interface IHttpClientService {
        Task<TResponse?> GetAsync<TResponse>(string url);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse?> DeleteAsync<TResponse>(string url);
    }
}
