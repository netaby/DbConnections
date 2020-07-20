using MongoDB.Driver;
using System.Collections.Generic;

namespace DbConnections.DAL
{
    interface INalaMongoCollection <T>
    {
       INalaMongoDbConnector nalaDbConnector { get; set; }
       IMongoCollection<T> _collection { get; set; }
       string NalaToysCollectionName { get; set; }


        List<T> Get();
        T GetByIg(string id);
        T Create(T toCreate);
        void Update(string id, T toyIn);
        void Remove(T toRemove);
    }
}
