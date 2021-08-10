using MongoDB.Bson;

namespace SharpMongoDB.Core.Interfaces
{
    public interface IMongoEntity
    {
        public ObjectId Id { get; set; }
    }
}