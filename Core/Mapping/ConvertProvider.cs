#nullable enable
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using SharpMongoDB.Core.Container.Attributes;

namespace SharpMongoDB.Core.Mapping
{
    [Singleton]
    public class ConvertProvider<T>
    {
        public string ConvertFromObjectToJson(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T ConvertFromJsonToObject(string jsonObject)
        {
            return BsonSerializer.Deserialize<T>(jsonObject);
        }
        
    }
}