using BuberDinner.Application.common.Interface.Authenticator;
using BuberDinner.Application.common.Interface.Persistence;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Query;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var (email, password) = request;
        if (_userRepository.GetUserByEmail(email) is not { } user)
        {
            throw new Exception("User does not exist with this email.");
        }
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

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