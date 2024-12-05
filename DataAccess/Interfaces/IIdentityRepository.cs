using System.Security.Claims;
using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IIdentityRepository
{
    public Task<string> CreateUser(User user);
    public Task<Claim[]> Login(string username, string password);

    public Task<User?> GetUser(string username);
}
