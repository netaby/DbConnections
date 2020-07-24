using DbConnections.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnections.DAL
{
    public class WalksCollection : INalaMongoCollection<Walk>
    {
            public INalaMongoDbConnector nalaDbConnector { get; set; }
            public IMongoCollection<Walk> _collection { get; set; }
            public string NalaCollectionName { get; set; }
            public WalksCollection(INalaMongoDbConnector dbConnector, IConfiguration config)
            {
                NalaCollectionName = config.GetSection("Walks").ToString();
                nalaDbConnector = dbConnector;
                _collection = nalaDbConnector.Database.GetCollection<Walk>(NalaCollectionName);

            }



            public List<Walk> Get() =>
                _collection.Find(walk => true).ToList();


            public Walk GetByIg(string id) =>
                _collection.Find<Walk>(walk => walk.Id == id).FirstOrDefault();

            public Walk Create(Walk toCreate)
            {
                _collection.InsertOne(toCreate);
                return toCreate;
            }

            public void Remove(Walk toRemove) =>
                _collection.DeleteOne(walk => walk.Id == toRemove.Id);


            public void Update(string id, Walk toIn) =>
                _collection.ReplaceOne(walk => walk.Id == id, toIn);
        }



}

