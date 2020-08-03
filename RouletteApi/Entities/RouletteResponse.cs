using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Entities
{
    public class RouletteResponse : IDocumentRoullete
    {
        public string Id { get; set; }
        public bool IsOpen { get; set; }
    }
}
