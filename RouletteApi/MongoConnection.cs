using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi
{
    public class MongoConnection
    {
        public MongoClient Client { get; internal set; }
        public IMongoDatabase DataBase { get; internal set; }
        public MongoConnection(string connectionString, string dataBaseName)
        {
            Client = new MongoClient(connectionString);
            DataBase = Client.GetDatabase(dataBaseName);
        }
    }
}
