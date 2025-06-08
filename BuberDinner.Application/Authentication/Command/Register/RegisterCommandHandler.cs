using BuberDinner.Application.common.Interface.Authenticator;
using BuberDinner.Application.common.Interface.Persistence;
using BuberDinner.Application.Services.Authentication;
using MediatR;

namespace BuberDinner.Application.Authentication.Command.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
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

    public  Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var (firstName, lastName, email, password, confirmPassword) = request;

        if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User already exists with this email.");
            }

            var user = new Domain.Entity.User
            {
                FirstName = firstName,
                LastName = lastName,
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

            return Task.FromResult(response);
    }
}