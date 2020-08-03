using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Entities
{
    public interface ICollectionRoulletes<T,U> 
    {
        IEnumerable<IDocumentRoullete> GetElements();
        void CreateElement(T roulette);
        void OpenRoulette(string rouletteId);
        void AddBet(string rouletteId, U bet);
        IEnumerable<U> CloseBets(string rouletteId);
    }
}
