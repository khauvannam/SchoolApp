using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IClassRepository
{
    Task<Class> CreateAsync(Class @class);
    Task<Class> UpdateAsync(Class @class);
    Task<Class> DeleteAsync(Class @class);
    Task<Class?> GetAsync(string id);
    Task<IEnumerable<Class>> GetAllAsync();
}
