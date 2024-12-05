using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public class Class(string teacherId, List<string> studentIds, string name)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string TeacherId { get; set; } = teacherId;
    public string Name { get; set; } = name;
    public List<string> StudentIds { get; set; } = studentIds;

    public void Update(string teacherId, List<string> studentIds, string name)
    {
        TeacherId = teacherId;
        Name = name;
        StudentIds = studentIds;
    }
}
