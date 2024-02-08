using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] LoginInputModel user){
        
        throw new NotImplementedException();
    }
}
