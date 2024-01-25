using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteController : ControllerBase
{
   private readonly IPacienteService _pacienteService;
   public List<PacienteViewModel> Pacientes => _pacienteService.GetAll().ToList();
   public PacienteController(IPacienteService service) => _pacienteService = service;
   // private readonly IPacienteCollection _pacientes;
   // public List<Paciente> Pacientes => _pacientes.GetAll().ToList();
   // public PacienteController(ITechMedContext context) => _pacientes = context.PacientesCollection;

   [HttpGet("pacientes")]
   public IActionResult Get()
   {
      return Ok(Pacientes);
   }

   [HttpGet("paciente/{id}")]
   public IActionResult GetById(int id)
   {
      var paciente = _pacienteService.GetById(id);
      if (paciente is null)
         return NoContent();
      return Ok(paciente);
   }

   [HttpPost("paciente")]
   public IActionResult Post([FromBody] NewPacienteInputModel paciente)
   {
      _pacienteService.Create(paciente);

      //service.Create(paciente);
      return CreatedAtAction(nameof(Get), paciente);
 
   }

   [HttpPut("paciente/{id}")]
   public IActionResult Put(int id, [FromBody] NewPacienteInputModel paciente)
   {
      if (_pacienteService.GetById(id) == null)
         return NoContent();
      _pacienteService.Update(id, paciente);
      return Ok(_pacienteService.GetById(id));
   }

   [HttpDelete("paciente/{id}")]
   public IActionResult Delete(int id)
   {
      if (_pacienteService.GetById(id) == null)
         return NoContent();
      _pacienteService.Delete(id);
      return Ok();
   }
}
