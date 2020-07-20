using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbConnections.DAL
{
    interface INalaMongoDbConnector
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string NalaToysCollectionName { get; set; }
        string NalaWalksCollectionName { get; set; }
        
    }
}
