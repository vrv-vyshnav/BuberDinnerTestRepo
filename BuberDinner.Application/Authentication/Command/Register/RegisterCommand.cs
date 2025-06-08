using BuberDinner.Application.Services.Authentication;
using MediatR;

namespace BuberDinner.Application.Authentication.Command.Register;

public record struct RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<AuthenticationResult>;
