using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Contracts.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResult>> Register(RegisterRequest request)
    {


        var result = await _authenticationService.RegisterAsync(request.FirstName,
                                                              request.LastName,
                                                              request.Email,
                                                              request.Password,
                                                              request.ConfirmPassword);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> login(string email, string password)
    {
        var result = await _authenticationService.LoginAsync(email, password);
        return Ok(result);
    }

}