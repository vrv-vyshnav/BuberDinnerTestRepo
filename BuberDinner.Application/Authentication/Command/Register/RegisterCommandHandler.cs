using BuberDinner.Application.common.Interface.Authenticator;
using BuberDinner.Application.common.Interface.Persistence;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Domain.Common;
using MediatR;

namespace BuberDinner.Application.Authentication.Command.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator
        )
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public  Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var(fullName, email, password, Cpassword) = request;


        var user = new Domain.Entity.User
        {
            FirstName = fullName,
            LastName = fullName,
            Email = email,
            Password = password 
        };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user.Id,user.Email,user.FirstName, user.LastName);

        var response = new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            token);

         return Task.FromResult(Result<AuthenticationResult>.Success(response));

    }
}