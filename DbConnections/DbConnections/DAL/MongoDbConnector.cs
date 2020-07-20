using DbConnections.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnections.DAL
{
    public class NalaMongoDbConnector : INalaMongoDbConnector
    {
        MongoClient client;
        
        public string ConnectionString { get ; set; }
        public string DatabaseName { get ; set; }

        
        private readonly IMongoCollection<Toy> _toys;
        private readonly IMongoCollection<Walk> _walks;
        public string NalaToysCollectionName { get; set; }
        public string NalaWalksCollectionName { get; set; }


        public NalaMongoDbConnector(IConfiguration config)
        {
            DatabaseName = config.GetSection("DatabaseName").ToString();
            ConnectionString = config.GetSection("ConnectionString").ToString();
            NalaToysCollectionName = config.GetSection("Toys").ToString();
            NalaWalksCollectionName = config.GetSection("walks").ToString();
            client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
            _toys = database.GetCollection<Toy>(NalaToysCollectionName);
            _walks = database.GetCollection<Walk>(NalaWalksCollectionName);
        }
        public List<Toy> Get() =>
            _toys.Find(toy => true).ToList();

        public List<Walk> Get() =>
            _walks.Find(walk => true).ToList();

        public Toy GetByIg(string id) =>
            _toys.Find<Toy>(toy => toy.Id == id).FirstOrDefault();

        public Walk GetWalkByIg(string id) =>
            _walks.Find<Walk>(walk => walk.Id == id).FirstOrDefault();

        public Toy CreateToy(Toy toy)
        {
            _toys.InsertOne(toy);
            return toy;
        }
        public Walk CreateWalk(Walk walk)
        {
            _walks.InsertOne(walk);
            return walk;
        }

        public void UpdateToy(string id, Toy toyIn) =>
            _toys.ReplaceOne(toy => toy.Id == id, toyIn);

        public void UpdateWalk(string id, Walk walkIn) =>
            _walks.ReplaceOne(walk => walk.Id == id, walkIn);

        public void RemoveToy(Toy toyIn) =>
            _toys.DeleteOne(toy => toy.Id == toyIn.Id);

        public void RemoveWalk(Walk walkIn) =>
            _walks.DeleteOne(walk => walk.Id == walkIn.Id);
        
    }
}
