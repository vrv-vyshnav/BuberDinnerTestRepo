using BuberDinner.Application.common.Interface.Authenticator;

namespace BuberDinner.Contracts.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        // Simulate registration logic
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId,email,firstName, lastName);

        var response = new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token);

        return Task.FromResult(response);
    }

    public Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var response = new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            email,
            "dummy-token login");

        return Task.FromResult(response);
    }
    
}