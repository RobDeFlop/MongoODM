using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace SharpMongoDB.Core
{
    public class MongoConnection
    {
        public MongoClient MongoClient;
        public IMongoDatabase MongoDatabase;

        /// <summary>
        ///     Creates an instance of MongoConnection and establishes the connection
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="schema"></param>
        /// <param name="port">Standard port is set to 27017</param>
        public MongoConnection(string host, string username, string password, string schema, int port = 27017)
        {
            
        }

        /// <summary>
        ///     Creates an instance of MongoConnection and establishes the connection
        /// </summary>
        /// <param name="connectionString">Add a connection string</param>
        /// <param name="schema"></param>
        public MongoConnection(string connectionString, string schema)
        {
            InitWithConnectionString(connectionString);
            SelectDatabase(schema);
            setIgnoreExtraElements(true);
            
            new Container.Container();
            
        }

        /// <summary>
        ///     Connects to a database with a connection string
        /// </summary>
        /// <param name="connectionString"></param>
        private void InitWithConnectionString(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
        }

        private void SelectDatabase(string databaseName)
        {
            MongoDatabase = MongoClient.GetDatabase(databaseName);
        }

        private void setIgnoreExtraElements(bool ignore)
        {
            var ignorePack = new ConventionPack {new IgnoreExtraElementsConvention(ignore)};
            ConventionRegistry.Register("SharpMongoDB Conventions", ignorePack, t => true);
        }
    }
}