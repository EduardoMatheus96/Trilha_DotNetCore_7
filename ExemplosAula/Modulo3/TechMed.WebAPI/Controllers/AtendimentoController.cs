using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistance.Interfaces;
using TechMed.Core.Entities;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
   private readonly IAtendimentoCollection _atendimentos;
   public List<Atendimento> Atendimentos => _atendimentos.GetAll().ToList();
   public AtendimentoController(ITechMedContext dbFake) => _atendimentos = dbFake.AtendimentosCollection;
   [HttpGet("atendimentos")]
   public IActionResult Get()
   {
      return Ok(Atendimentos);
   }



}
