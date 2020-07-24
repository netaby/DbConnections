using DbConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DbConnections.DAL
{
    public class ToysCollection : INalaMongoCollection<Toy>
    {
        public INalaMongoDbConnector nalaDbConnector { get ; set; }
        public IMongoCollection<Toy> _collection { get ; set; }
        public string NalaCollectionName { get ; set; }
        public ToysCollection(INalaMongoDbConnector dbConnector, IConfiguration config)
        {
            NalaCollectionName = config.GetSection("Toys").ToString();
            nalaDbConnector = dbConnector;
            _collection = nalaDbConnector.Database.GetCollection<Toy>(NalaCollectionName);

        }



        public List<Toy> Get() =>
            _collection.Find(toy => true).ToList();
       

        public Toy GetByIg(string id) =>
            _collection.Find<Toy>(toy => toy.Id == id).FirstOrDefault();

        public Toy Create(Toy toCreate)
        {
            _collection.InsertOne(toCreate);
            return toCreate;
        }

        public void Remove(Toy toRemove) =>
            _collection.DeleteOne(toy => toy.Id == toRemove.Id);
        

        public void Update(string id, Toy toyIn) =>
            _collection.ReplaceOne(toy => toy.Id == id, toyIn);
    }
}
