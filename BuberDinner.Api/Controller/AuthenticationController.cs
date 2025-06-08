using BuberDinner.Application.Authentication.Command.Register;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Contracts.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{

    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResult>> Register(RegisterRequest request)
    {

        var result = await _mediator.Send(new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.ConfirmPassword));

        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> login(AuthenticationRequest request)
    {
        var result = await _mediator.Send(new LoginQuery(
            request.Email,
            request.Password));
        return Ok(result);
    }

}