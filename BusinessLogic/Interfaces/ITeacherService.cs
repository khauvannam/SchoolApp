using DataAccess.Models;

namespace BusinessLogic.Interfaces;

public interface ITeacherService
{
    Task<Teacher> CreateAsync(Teacher? teacher);
    Task<Teacher> UpdateAsync(Teacher teacher);
    Task DeleteAsync(Teacher teacher);
    Task<Teacher?> GetAsync(string id);
    Task<IEnumerable<Teacher>> GetAllAsync();
}
