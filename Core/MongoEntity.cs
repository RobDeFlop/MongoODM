using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharpMongoDB.Core
{
    public class MongoEntity
    {
        [BsonId] public ObjectId Id;
    }
}