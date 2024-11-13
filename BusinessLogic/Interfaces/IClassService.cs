using DataAccess.Models;

namespace BusinessLogic.Interfaces;

public interface IClassService
{
    Task<Class> CreateAsync(Class @class);
    Task<Class> UpdateAsync(Class @class);
    Task DeleteAsync(Class @class);
    Task<Class?> GetAsync(string id);
    Task<IEnumerable<Class>> GetAllAsync();
}
