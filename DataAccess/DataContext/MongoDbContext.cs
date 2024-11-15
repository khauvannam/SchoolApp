using MongoDB.Driver;

namespace DataAccess.DataContext;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var mongoClient = new MongoClient(MongoDbConnection.ConnectionString);
        _database = mongoClient.GetDatabase(MongoDbConnection.DatabaseName);
    }

    public IMongoCollection<T> Database<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
