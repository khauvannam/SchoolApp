using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;

public class ClassService(IClassRepository repository) : IClassService
{
    public async Task<Class> CreateAsync(Class @class)
    {
        return await repository.CreateAsync(@class);
    }

    public async Task<Class> UpdateAsync(Class @class)
    {
        return await repository.UpdateAsync(@class);
    }

    public async Task DeleteAsync(Class @class)
    {
        await repository.DeleteAsync(@class);
    }

    public async Task<Class?> GetAsync(string id)
    {
        return await repository.GetAsync(id);
    }

    public async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }
}
