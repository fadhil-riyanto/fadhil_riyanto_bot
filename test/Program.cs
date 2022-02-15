using db.mongod;
using MongoDB.Driver;
using MongoDB.Bson;

class ngetes{
    public static void Main(string[] args){
        IUtilsDatabase databasem = new Database(conf.urikon, "fadhil_riyanto_bot");


        var doc = new BsonDocument
            {
                {"test", "key"}
            };


        databasem.Insert(doc, "testing");
    }
}