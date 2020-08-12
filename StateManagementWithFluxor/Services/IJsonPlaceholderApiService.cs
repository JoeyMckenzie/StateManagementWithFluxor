using System.Net.Http;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Services
{
    public interface IJsonPlaceholderApiService
    {
        Task<TResponse> GetAsync<TResponse>(string path);

        Task<HttpResponseMessage> PostAsync<TBody>(string path, TBody body);

        Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body);

        Task<HttpResponseMessage> DeleteAsync(string path);
    }
}
