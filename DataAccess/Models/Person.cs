using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public abstract class Person(int age, string username, string email, string fullName)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public int Age { get; set; } = age;
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string FullName { get; set; } = fullName;

    public virtual void Update(int age, string username, string email, string fullName)
    {
        Age = age;
        Username = username;
        Email = email;
        FullName = fullName;
    }
}
