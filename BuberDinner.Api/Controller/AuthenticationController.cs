using BuberDinner.Application.Authentication.Command.Register;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Query;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResult>> Register(RegisterRequest request)
    {
        var model = _mapper.Map<RegisterCommand>(request);
        var result = await _mediator.Send(model);

        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> login(AuthenticationRequest request)
    {
        var model = _mapper.Map<LoginQuery>(request);
        var result = await _mediator.Send(model);
        return Ok(result);
    }

}