using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RiftEngine.Frontend.DataModels
{
    public class LibraryConfig
    {
        public string LibraryName { get; set; }
        public List<string> SupportedGames { get; set; }

        public static List<LibraryConfig> LoadLibraryConfig(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<LibraryConfig>>(json);
        }
    }
}
