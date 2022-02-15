using MongoDB.Driver;
using MongoDB.Bson;
namespace db.mongod
{

    interface IUtilsDatabase
    {
        bool TestConn();
        void Insert(BsonDocument data_insert, string collection);
    }

    class Database : IUtilsDatabase
    {
        private string con_uri, dbname;
        private MongoClient dbClient;
        public Database(string koneksi_uri, string ndb)
        {
            this.con_uri = koneksi_uri;
            this.dbname = ndb;
            this.dbClient = new MongoClient(this.con_uri);
        }

        public bool TestConn()
        {
            
            var dbList = this.dbClient.ListDatabases().ToList();

            Console.WriteLine("database:");

            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }

            return true;
        }
        private IMongoDatabase getDb(string nama_db)
        {
            IMongoDatabase db = this.dbClient.GetDatabase(nama_db);
            return db;
        }
        public void Insert(BsonDocument data_insert, string collection){
            IMongoDatabase db = getDb(this.dbname);
            var dbCtx = db.GetCollection<BsonDocument>(collection);
            dbCtx.InsertOne(data_insert);
        }
        // public void TestDatabase()
 
    }
}