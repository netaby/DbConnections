using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace DbConnections.Models
{
    public class Toy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string ToyName { get; set; }

        [BsonElement("size")]
        public string ToySize { get; set; }

        [BsonElement("lastTimePlayed")]
        public DateTime LastTimePlayed { get; set; }
    }
}
