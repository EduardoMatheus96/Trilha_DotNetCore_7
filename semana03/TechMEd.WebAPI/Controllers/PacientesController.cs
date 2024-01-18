using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TechMEd.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class  PacientesController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Valber", "João", "Wilton", "Welvis", "Matheus"
    };

    private static readonly string[] enderecos = new[]
    {
        "Ilheus", "Almadina", "Miknik", "saoJose", "Itabuna"
    };

    [HttpGet(Name = "GetPaciente")]
    public IEnumerable<Paciente> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Paciente
        {
            Nome = Summaries[Random.Shared.Next(Summaries.Length)],
            Endereco = enderecos[Random.Shared.Next(enderecos.Length)]
        })
        .ToArray();
    }
}
