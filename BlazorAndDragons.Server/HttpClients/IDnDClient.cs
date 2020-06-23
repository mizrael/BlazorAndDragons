using System.Threading.Tasks;

namespace BlazorAndDragons.Server.HttpClients
{
    public interface IDnDClient
    {
        Task<DndArchive<DnDClassArchiveItem>> GetAllClassesAsync();
        Task<DndClass> GetClassAsync(string id);
    }
}