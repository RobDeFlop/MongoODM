using MongoDB.Bson;

namespace MongoODM.Core.Interfaces
{
    public interface IMongoEntity
    {
        public ObjectId Id { get; set; }
    }
}