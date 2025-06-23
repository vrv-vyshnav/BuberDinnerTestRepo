using BuberDinner.Domain.Common;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Query;

public record LoginQuery(
    string Email,
    string Password) : IRequest<Result<AuthenticationResult>>;