namespace BuberDinner.Contracts.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password, string confirmPassword);
    Task<AuthenticationResult> LoginAsync(string email, string password);

}