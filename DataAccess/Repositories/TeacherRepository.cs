using DataAccess.DataContext;
using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IMongoCollection<Teacher> _collection;

    public TeacherRepository()
    {
        var mongoClient = new MongoClient(MongoDbConnection.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(MongoDbConnection.DatabaseName);
        _collection = mongoDatabase.GetCollection<Teacher>("Teachers");
    }

    public async Task<Teacher> CreateAsync(Teacher teacher)
    {
        await _collection.InsertOneAsync(teacher);
        return teacher;
    }

    public async Task<Teacher> UpdateAsync(Teacher teacher)
    {
        await _collection.ReplaceOneAsync(t => t.Id == teacher.Id, teacher);
        return teacher;
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        await _collection.DeleteOneAsync(t => t.Id == teacher!.Id);
    }

    public async Task<Teacher?> GetAsync(string id)
    {
        return await _collection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}
