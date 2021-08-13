using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharpMongoDB.Core.Interfaces
{
    public interface IMongoEntity
    {
        [BsonId] public ObjectId Id { get; set; }
    }
}