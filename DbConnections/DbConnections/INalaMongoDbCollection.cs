using MongoDB.Driver;
using System.Collections.Generic;

namespace DbConnections.DAL
{
    public interface INalaMongoCollection<T>
    {
        INalaMongoDbConnector nalaDbConnector { get; set; }
        IMongoCollection<T> _collection { get; set; }
        string NalaCollectionName { get; set; }


        List<T> Get();
        T GetByIg(string id);
        T Create(T toCreate);
        void Update(string id, T toIn);
        void Remove(T toRemove);
    }
}
