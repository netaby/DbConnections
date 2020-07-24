using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnections.DAL
{
    public interface INalaMongoDbConnector
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        IMongoDatabase Database { get; set; }

    }
}
