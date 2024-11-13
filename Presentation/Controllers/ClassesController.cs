using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController(IClassService classService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClass([FromBody] ClassDto classDto)
    {
        var classEntity = new Class(classDto.TeacherId, classDto.StudentIds, classDto.Name);

        var createdClass = await classService.CreateAsync(classEntity);

        return CreatedAtAction(nameof(GetClassById), new { id = createdClass.Id }, createdClass);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(string id, [FromBody] ClassDto classDto)
    {
        var existingClass = await classService.GetAsync(id);

        if (existingClass is null)
            return NotFound();

        existingClass.Update(classDto.TeacherId, classDto.StudentIds, classDto.Name);

        var updatedClass = await classService.UpdateAsync(existingClass);

        return Ok(updatedClass);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass(string id)
    {
        var existingClass = await classService.GetAsync(id);

        if (existingClass is null)
            return NotFound();

        await classService.DeleteAsync(existingClass);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClassById(string id)
    {
        var classEntity = await classService.GetAsync(id);

        if (classEntity is null)
            return NotFound();

        return Ok(classEntity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClasses()
    {
        var classes = await classService.GetAllAsync();

        return Ok(classes);
    }
}
