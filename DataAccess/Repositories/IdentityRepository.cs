using System.Security.Claims;
using DataAccess.DataContext;
using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Driver;
using UnauthorizedAccessException = System.UnauthorizedAccessException;

namespace DataAccess.Repositories;

public class IdentityRepository(MongoDbContext dbContext) : IIdentityRepository
{
    private readonly IMongoCollection<User> _collection = dbContext.Database<User>("Users");

    public async Task<string> CreateUser(User user)
    {
        await _collection.InsertOneAsync(user);
        return user.Id;
    }

    public async Task<Claim[]> Login(string username, string password)
    {
        var user = await GetUser(username);
        var refreshToken = user!.RefreshToken;

        if (refreshToken is null)
        {
            refreshToken = new RefreshToken(Guid.NewGuid().ToString());
            user.RefreshToken = refreshToken;
        }

        if (user.RefreshToken!.Expires < DateTime.Now)
        {
            refreshToken.Expires = DateTime.Now.AddDays(7);
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user!.PasswordHash);
        if (!isPasswordValid)
        {
            throw new UnauthorizedAccessException("Invalid password.");
        }

        var claims = new[] { new Claim("Id", user.Id), new Claim("Username", user.Username) };

        return claims;
    }

    public async Task<User?> GetUser(string username)
    {
        // Create a filter to find the user by username
        var filter = Builders<User>.Filter.Eq(u => u.Username, username);

        // Use the filter to find the user
        var existingUser = await _collection.Find(filter).FirstOrDefaultAsync();
        return existingUser;
    }
}
