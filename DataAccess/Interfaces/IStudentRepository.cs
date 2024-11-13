using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student student);
    Task<Student> UpdateAsync(Student student);
    Task<Student> DeleteAsync(Student student);
    Task<Student?> GetAsync(string id);
    Task<IEnumerable<Student>> GetAllAsync();
}
