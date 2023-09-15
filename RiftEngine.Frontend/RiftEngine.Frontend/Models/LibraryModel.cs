using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftEngine.Frontend.Models
{
    public class LibraryModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<string> SupportedGames { get; set; }  // List of game names or IDs
    }
}
