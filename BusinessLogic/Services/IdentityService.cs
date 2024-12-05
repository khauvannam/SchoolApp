using System.Security.Claims;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;

public class IdentityService(IIdentityRepository repository) : IIdentityService
{
    public async Task<string> CreateUser(User user)
    {
        return await repository.CreateUser(user);
    }

    public async Task<Claim[]> Login(string username, string password)
    {
        return await repository.Login(username, password);
    }

    public Task<User?> GetUser(string username)
    {
        return repository.GetUser(username);
    }
}
