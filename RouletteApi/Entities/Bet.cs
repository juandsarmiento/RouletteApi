using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Entities
{
    public class Bet
    {
        public string Number { get; set; }
        public decimal Money { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreation { get; set; }
        [JsonIgnore]
        public bool IsValid { get => getValid();}
        private bool getValid()
        {
            if (GetNotValidMessages().Any())
            {

                return false;
            }

            return true;
        }
        public IEnumerable<string> GetNotValidMessages()
        {
            int auxNumber;
            if (Money > 10000)
            {

                yield return "Mony exceeded value";
            }
            if (int.TryParse(Number, out auxNumber) && (auxNumber < 0 || auxNumber > 36))
            {

                yield return "Number not valid";
            }
            else if (!int.TryParse(Number, out auxNumber) && Number != "red" && Number != "black")
            {

                yield  return "color not valid";
            }

        }
    }
}
