using System.Collections.Generic;

namespace BlazorAndDragons.Server.HttpClients
{
    public class DndArchive<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int Count { get; set; }
    }
}