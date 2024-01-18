using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TechMEd.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class  OpeningTimeController : ControllerBase
{
    private readonly IOptions<OpeningTime> _openingTime;

     public OpeningTimeController(IOptions<OpeningTime> openingTime)
    {
        _openingTime = openingTime;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(_openingTime.Value);
    }
}
