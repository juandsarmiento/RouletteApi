using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Exceptions;

namespace RouletteApi.Entities
{
    public class Roulettes : ICollectionRoulletes<Roulette,Bet>
    {
        private readonly IMongoDatabase DataBase;
        public Roulettes(MongoConnection mongoConnection)
        {
            DataBase = mongoConnection.DataBase;
        }
        private IMongoCollection<Roulette> getCollection()
        {

            return DataBase.GetCollection<Roulette>("roulette");
        }
        public IEnumerable<IDocumentRoullete> GetElements()
        {
            getCollection()
                .Find(x => true)
                .Project(f => new RouletteResponse
                {
                    Id = f.Id,
                    IsOpen = f.IsOpen
                });

            return getCollection().Find(x => true).ToList();
        }
        public void CreateElement(Roulette roulette)
        {
            roulette.Id = Guid.NewGuid().ToString();
            getCollection().InsertOne(roulette); 
        }
        public void OpenRoulette(string rouletteId)
        {
            FilterDefinition<Roulette> filterDef = new BsonDocument("_id", rouletteId);
            UpdateDefinition<Roulette> updateDef = Builders<Roulette>.Update.Set("IsOpen", true);
            getCollection().UpdateOne(filterDef, updateDef);
        }
        public void AddBet(string rouletteId, Bet bet)
        {
            if (!bet.IsValid)
            {
                throw new ArgumentException(string.Join(';', bet.GetNotValidMessages()));
            }
            Roulette item = getCollection().Find(f => f.Id == rouletteId).FirstOrDefault();
            if (item == null)
            {
                throw new MongoDocumentNotFound();
            }
            if (!item.IsOpen)
            {
                throw new RouletteIsNotOpenException("The roulette is not open");
            }
            FilterDefinition<Roulette> filterDef = new BsonDocument("_id", rouletteId);
            UpdateDefinition<Roulette> updateDef = Builders<Roulette>.Update.AddToSet("Bets", bet);
            getCollection().UpdateOne(filterDef, updateDef);
        }
        public IEnumerable<Bet> CloseBets(string rouletteId)
        {
            FilterDefinition<Roulette> filterDef = new BsonDocument("_id", rouletteId);
            UpdateDefinition<Roulette> updateDef = Builders<Roulette>.Update.Set("IsOpen", false);
            getCollection().UpdateOne(filterDef, updateDef);

            return getCollection().Find(f => f.Id == rouletteId).Project(f => f.Bets).First();
        }
    }
}
