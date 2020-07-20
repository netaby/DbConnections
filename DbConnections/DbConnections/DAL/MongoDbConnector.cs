﻿using DbConnections.Models;
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

        public List<Walk> Get() =>
            _walks.Find(walk => true).ToList();


        public Walk GetWalkByIg(string id) =>
            _walks.Find<Walk>(walk => walk.Id == id).FirstOrDefault();

        
        public Walk CreateWalk(Walk walk)
        {
            _walks.InsertOne(walk);
            return walk;
        }


        public void UpdateWalk(string id, Walk walkIn) =>
            _walks.ReplaceOne(walk => walk.Id == id, walkIn);

            

        public void RemoveWalk(Walk walkIn) =>
            _walks.DeleteOne(walk => walk.Id == walkIn.Id);
        
    }
}
