using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;

public class StudentService(IStudentRepository repository) : IStudentService
{
    public async Task<Student> CreateAsync(Student student)
    {
        return await repository.CreateAsync(student);
    }

    public async Task<Student> UpdateAsync(Student student)
    {
        return await repository.UpdateAsync(student);
    }

    public async Task DeleteAsync(Student student)
    {
        await repository.DeleteAsync(student);
    }

    public async Task<Student?> GetAsync(string id)
    {
        return await repository.GetAsync(id);
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }
}
