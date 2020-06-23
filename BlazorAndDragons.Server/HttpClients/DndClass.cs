using System.Collections.Generic;

namespace BlazorAndDragons.Server.HttpClients
{
    public class DndClass
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public int Hit_Die { get; set; }
        public IEnumerable<DndClassProficiency> Proficiencies { get; set; }
    }
}