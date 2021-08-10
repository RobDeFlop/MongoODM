using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoODM.Core.Interfaces;

namespace MongoODM.Core.Repository
{
    public abstract class MongoRepository<T> where T : IMongoEntity
    {
        protected IMongoCollection<T> MongoCollection;
        protected IMongoDatabase MongoDatabase;

        protected MongoRepository(IMongoDatabase mongoDb)
        {
            MongoDatabase = mongoDb;
            MongoCollection = MongoDatabase.GetCollection<T>(GenerateNamingConvention(typeof(T).Name));
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

        public T FindOneByFilter(Expression<Func<T, bool>>filter)
        {
            return MongoCollection.Find(filter).FirstOrDefault();
        }

        public List<T> FindAllByFilter(Expression<Func<T, bool>>filter)
        {
            return MongoCollection.Find(filter).ToList();
        }

        public List<T> FindAll()
        {
            return MongoCollection.Find(new BsonDocument()).ToList();
        }

        private string GenerateNamingConvention(string singularForm)
        {
            return singularForm.ToLower() + "s";
        }
    }
}