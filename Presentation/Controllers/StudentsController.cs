using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
    {
        var student = new Student(
            studentDto.Age,
            studentDto.Username,
            studentDto.Email,
            studentDto.FullName
        );

        var createdStudent = await studentService.CreateAsync(student);

        return CreatedAtAction(
            nameof(GetStudentById),
            new { id = createdStudent.Id },
            createdStudent
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(string id, [FromBody] StudentDto studentDto)
    {
        var existingStudent = await studentService.GetAsync(id);

        if (existingStudent is null)
            return NotFound();

        existingStudent.Update(
            studentDto.Age,
            studentDto.Username,
            studentDto.Email,
            studentDto.FullName
        );

        var updatedStudent = await studentService.UpdateAsync(existingStudent);

        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(string id)
    {
        var existingStudent = await studentService.GetAsync(id);

        if (existingStudent is null)
            return NotFound();

        await studentService.DeleteAsync(existingStudent);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var student = await studentService.GetAsync(id);

        if (student is null)
            return NotFound();

        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await studentService.GetAllAsync();

        return Ok(students);
    }
}
