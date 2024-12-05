using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public class User(string username, string passwordHash)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Username { get; set; } = username;
    public string PasswordHash { get; set; } = passwordHash;
    public RefreshToken? RefreshToken { get; set; }
}
