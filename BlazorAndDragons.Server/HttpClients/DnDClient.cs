using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlazorAndDragons.Server.HttpClients
{
    public class DnDClient : IDnDClient
    {
        private readonly HttpClient _httpClient;

        public DnDClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<DndArchive<DnDClassArchiveItem>> GetAllClassesAsync() =>
            _httpClient.GetFromJsonAsync<DndArchive<DnDClassArchiveItem>>("classes");

        public Task<DndClass> GetClassAsync(string id) =>
            _httpClient.GetFromJsonAsync<DndClass>($"classes/{id}");
    }
}
