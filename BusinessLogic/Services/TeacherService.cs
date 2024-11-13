using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;

public class TeacherService(ITeacherRepository repository) : ITeacherService
{
    public async Task<Teacher> CreateAsync(Teacher teacher)
    {
        var result = await repository.CreateAsync(teacher);
        return result;
    }

    public async Task<Teacher> UpdateAsync(Teacher teacher)
    {
        return await repository.UpdateAsync(teacher);
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        await repository.DeleteAsync(teacher);
    }

    public async Task<Teacher?> GetAsync(string id)
    {
        return await repository.GetAsync(id);
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }
}
