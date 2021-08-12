using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpMongoDB.Core.Interfaces;

namespace SharpMongoDB.Core.Repository
{
    public abstract class MongoRepository<T> where T : IMongoEntity
    {
        protected IMongoCollection<T> MongoCollection;
        protected IMongoDatabase MongoDatabase;

        protected MongoRepository(IMongoDatabase mongoDb)
        {
            MongoDatabase = mongoDb;
            MongoCollection = MongoDatabase.GetCollection<T>(NamingHelper.GeneratePluralNaming(typeof(T).Name));
        }

        public void Insert(T obj)
        {
            MongoCollection.InsertOne(obj);
        }

        public T Update(T obj)
        {
            return MongoCollection.FindOneAndReplace(old => obj.Id == old.Id, obj);
        }

        public T Delete(T obj)
        {
            return MongoCollection.FindOneAndDelete(find => find.Id == obj.Id);
        }

        public T FindOneByObject(T obj)
        {
            return MongoCollection.Find(findObj => findObj.Id == obj.Id).FirstOrDefault();
        }

        public T FindOneByFilter(Expression<Func<T, bool>> filter)
        {
            return MongoCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> filter)
        {
            return MongoCollection.Find(filter).ToEnumerable();
        }

        public IEnumerable<T> FindAll()
        {
            return MongoCollection.Find(new BsonDocument()).ToEnumerable();
        }
        
    }
}