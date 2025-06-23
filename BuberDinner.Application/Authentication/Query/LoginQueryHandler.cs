using BuberDinner.Application.common.Interface.Authenticator;
using BuberDinner.Application.common.Interface.Persistence;
using BuberDinner.Domain.Common;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Query;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var (email, password) = request;
        var user =  _userRepository.GetUserByEmail(email);

        if (user is null)
            return Task.FromResult(Result<AuthenticationResult>.Failure("Invalid Credentials"));

        if (user.Password == password)
            return Task.FromResult(Result<AuthenticationResult>.Failure("Invalid Credentials"));

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