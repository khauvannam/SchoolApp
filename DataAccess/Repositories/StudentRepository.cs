using DataAccess.DataContext;
using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Driver;

namespace DataAccess.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IMongoCollection<Student> _studentsCollection;

    public StudentRepository()
    {
        var mongoClient = new MongoClient(MongoDbConnection.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(MongoDbConnection.DatabaseName);
        _studentsCollection = mongoDatabase.GetCollection<Student>("Students"); // Replace with your collection name
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _studentsCollection.InsertOneAsync(student);
        return student;
    }

    public async Task<Student> UpdateAsync(Student student)
    {
        await _studentsCollection.ReplaceOneAsync(s => s.Id == student.Id, student);
        return student;
    }

    public async Task<Student> DeleteAsync(Student student)
    {
        await _studentsCollection.DeleteOneAsync(s => s.Id == student.Id);
        return student;
    }

    public async Task<Student?> GetAsync(string id)
    {
        return await _studentsCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _studentsCollection.Find(_ => true).ToListAsync();
    }
}
