using MongoDB.Bson;
interface IUtilsDatabase{
    bool Insert(string bson);
}

class Database : IUtilsDatabase
{
    private string con_uri;
    public Database(string koneksi_uri)
    {
        this.con_uri = koneksi_uri;
    }

    public bool IUtilsDatabase.Insert(string bson){
        return true;
    }  
}