using Newtonsoft.Json;
using RiftEngine.Frontend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftEngine.Frontend.DataModels
{
    public class GameConfig
    {
        public List<GameModel>? AddedGames { get; set; }
        public List<GameModel>? SupportedGames { get; set; }
        public List<GameModel>? UnsupportedGames { get; set; }
        public List<LibraryModel>? Libraries { get; set; }

        public void Save(string path)
        {
            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }

        public static GameConfig Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<GameConfig>(json);
        }
    }
}
