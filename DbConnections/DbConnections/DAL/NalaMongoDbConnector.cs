using DbConnections.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DbConnections.DAL
{
    public class NalaMongoDbConnector : INalaMongoDbConnector
    {
        MongoClient client;
        
        public string ConnectionString { get ; set; }
        public string DatabaseName { get ; set; }
        public IMongoDatabase Database { get; set; }

        private readonly IMongoCollection<Toy> _toys;
        private readonly IMongoCollection<Walk> _walks;
        public string NalaToysCollectionName { get; set; }
        public string NalaWalksCollectionName { get; set; }


        public NalaMongoDbConnector(IConfiguration config)
        {
            DatabaseName = config.GetSection("DatabaseName").ToString();
            ConnectionString = config.GetSection("ConnectionString").ToString();
            client = new MongoClient(ConnectionString);
            Database = client.GetDatabase(DatabaseName);


            NalaWalksCollectionName = config.GetSection("walks").ToString();
            _walks = Database.GetCollection<Walk>(NalaWalksCollectionName);
        }
       
    }
}
