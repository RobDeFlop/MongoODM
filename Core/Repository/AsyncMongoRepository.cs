using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpMongoDB.Core.Interfaces;

namespace SharpMongoDB.Core.Repository
{
    public abstract class AsyncMongoRepository<T> where T : IMongoEntity
    {
        protected IMongoCollection<T> MongoCollection;
        protected IMongoDatabase MongoDatabase;

        protected AsyncMongoRepository(IMongoDatabase mongoDb)
        {
            MongoDatabase = mongoDb;
            MongoCollection = MongoDatabase.GetCollection<T>(NamingHelper.GeneratePluralNaming(typeof(T).Name));
        }

        public Task Insert(T obj)
        {
           return MongoCollection.InsertOneAsync(obj);
        }

        public Task<T> Update(T obj)
        {
            return MongoCollection.FindOneAndReplaceAsync(old => obj.Id == old.Id, obj);
        }

        public Task<T> Delete(T obj)
        {
            return MongoCollection.FindOneAndDeleteAsync(find => find.Id == obj.Id);
        }

        public Task<IAsyncCursor<T>> FindOneByObject(T obj)
        {
            return MongoCollection.FindAsync(findObj => findObj.Id == obj.Id);
        }

        public Task<IAsyncCursor<T>> FindOneByFilter(Expression<Func<T, bool>> filter)
        {
            return MongoCollection.FindAsync(filter);
        }

        public async Task<IAsyncCursor<T>> FindAllByFilter(Expression<Func<T, bool>> filter)
        {
            return await MongoCollection.FindAsync(filter);
        }

        public Task<IAsyncCursor<T>> FindAll()
        {
            return MongoCollection.FindAsync(new BsonDocument());
        }
        
       
    }
}