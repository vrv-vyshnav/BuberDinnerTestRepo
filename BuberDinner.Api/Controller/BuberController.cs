using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BuberController : ControllerBase
{
    [HttpGet("GetBuberDinner")]
    public IActionResult GetBuberDinner() => Ok("BuberDinner");
}

