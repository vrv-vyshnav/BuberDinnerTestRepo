using BuberDinner.Application.Services.Authentication;
using BuberDinner.Domain.Common;
using MediatR;

namespace BuberDinner.Application.Authentication.Command.Register;

public record struct RegisterCommand(
    string FullName,
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<Result<AuthenticationResult>>;
