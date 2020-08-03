using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Entities
{
    public class Roulette : IDocumentRoullete
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        [JsonIgnore]
        public DateTime DateOpened { get; set; } = new DateTime();
        [JsonIgnore]
        public DateTime? DateClose { get; set; } = null;
        public List<Bet> Bets { get; set; } = new List<Bet>();
    }
}
