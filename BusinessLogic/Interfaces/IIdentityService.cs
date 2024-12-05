using System.Security.Claims;
using DataAccess.Models;

namespace BusinessLogic.Interfaces;

public interface IIdentityService
{
    public Task<string> CreateUser(User user);
    public Task<Claim[]> Login(string username, string password);

    public Task<User?> GetUser(string username);
}
