using MongoDB.Bson;
interface IUtilsDatabase
{
    bool TestConn(string bson);
}
namespace db.mongod
{

    class Database : IUtilsDatabase
    {
        private string con_uri;
        public Database(string koneksi_uri)
        {
            this.con_uri = koneksi_uri;
        }

        bool IUtilsDatabase.TestConn(string bson)
        {
            var dbClient = new MongoClient(this.con_uri);
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("database:");

            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }

            return true;
        }
    }
}