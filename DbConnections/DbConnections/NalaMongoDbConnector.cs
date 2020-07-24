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

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public IMongoDatabase Database { get; set; }

        public NalaMongoDbConnector(IConfiguration config)
        {
            DatabaseName = config.GetSection("DatabaseName").ToString();
            ConnectionString = config.GetSection("ConnectionString").ToString();
            client = new MongoClient(ConnectionString);
            Database = client.GetDatabase(DatabaseName);
        }
    }
}
