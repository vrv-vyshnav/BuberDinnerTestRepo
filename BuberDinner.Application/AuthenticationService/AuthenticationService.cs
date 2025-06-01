using BuberDinner.Application.common.Interface.Authenticator;
using BuberDinner.Application.common.Interface.Persistence;

namespace BuberDinner.Contracts.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password, string confirmPassword)
    {

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

    public Task<AuthenticationResult> LoginAsync(string email, string password)
    {
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