using DataAccess.Models;

namespace BusinessLogic.Interfaces;

public interface IStudentService
{
    Task<Student> CreateAsync(Student student);
    Task<Student> UpdateAsync(Student student);
    Task DeleteAsync(Student student);
    Task<Student?> GetAsync(string id);
    Task<IEnumerable<Student>> GetAllAsync();
}
