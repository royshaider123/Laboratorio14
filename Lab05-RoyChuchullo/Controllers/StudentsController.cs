using Lab05_RoyChuchullo.Interfaces;
using Lab05_RoyChuchullo.Models;
using Microsoft.AspNetCore.Mvc;
namespace Lab05_RoyChuchullo.Controllers;

[ApiController] 
[Route("[controller]")]
public class StudentsController : ControllerBase {
    private readonly IUnitOfWork _unitOfWork;
    public StudentsController(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var estudiantes = await _unitOfWork.Repository<Estudiante>().GetAllAsync();
        return Ok(estudiantes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
        if (estudiante == null) return NotFound();
        return Ok(estudiante);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Estudiante estudiante) {
        await _unitOfWork.Repository<Estudiante>().AddAsync(estudiante);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetById), new { id = estudiante.IdEstudiante }, estudiante);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Estudiante estudiante) {
        if (id != estudiante.IdEstudiante) return BadRequest();
        _unitOfWork.Repository<Estudiante>().Update(estudiante);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
        if (estudiante == null) return NotFound();
        _unitOfWork.Repository<Estudiante>().Remove(estudiante);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}