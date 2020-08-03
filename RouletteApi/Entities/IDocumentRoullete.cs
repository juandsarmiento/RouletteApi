using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Entities
{
    public interface IDocumentRoullete
    {
        string Id { get; set; }
        bool IsOpen { get; set; }
    }
}
