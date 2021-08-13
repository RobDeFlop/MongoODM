#nullable enable
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;

namespace SharpMongoDB.Core.Mapping
{
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