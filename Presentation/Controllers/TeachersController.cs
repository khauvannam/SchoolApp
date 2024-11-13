using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController(ITeacherService teacherService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromBody] TeacherDto teacherDto)
    {
        var teacher = new Teacher(
            teacherDto.Age,
            teacherDto.Username,
            teacherDto.Email,
            teacherDto.FullName
        );

        var createdTeacher = await teacherService.CreateAsync(teacher);

        return CreatedAtAction(
            nameof(GetTeacherById),
            new { id = createdTeacher!.Id },
            createdTeacher
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(string id, [FromBody] TeacherDto teacherDto)
    {
        var existingTeacher = await teacherService.GetAsync(id);

        if (existingTeacher is null)
            return NotFound();

        existingTeacher.Update(
            teacherDto.Age,
            teacherDto.Username,
            teacherDto.Email,
            teacherDto.FullName
        );

        var updatedTeacher = await teacherService.UpdateAsync(existingTeacher);

        return Ok(updatedTeacher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(string id)
    {
        var existingTeacher = await teacherService.GetAsync(id);

        if (existingTeacher is null)
            return NotFound();

        await teacherService.DeleteAsync(existingTeacher);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacherById(string id)
    {
        var teacher = await teacherService.GetAsync(id);

        if (teacher is null)
            return NotFound();

        return Ok(teacher);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teachers = await teacherService.GetAllAsync();

        return Ok(teachers);
    }
}
