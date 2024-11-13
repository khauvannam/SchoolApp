using DataAccess.DataContext;
using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly IMongoCollection<Class> _collection;

    public ClassRepository()
    {
        var mongoClient = new MongoClient(MongoDbConnection.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(MongoDbConnection.DatabaseName);
        _collection = mongoDatabase.GetCollection<Class>("Classes");
    }

    public async Task<Class> CreateAsync(Class @class)
    {
        await _collection.InsertOneAsync(@class);
        return @class;
    }

    public async Task<Class> UpdateAsync(Class @class)
    {
        await _collection.ReplaceOneAsync(c => c.Id == @class.Id, @class);
        return @class;
    }

    public async Task<Class> DeleteAsync(Class @class)
    {
        await _collection.DeleteOneAsync(c => c.Id == @class.Id);
        return @class;
    }

    public async Task<Class?> GetAsync(string id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}