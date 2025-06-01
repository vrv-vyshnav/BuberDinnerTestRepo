namespace BuberDinner.Application.common.Interface.Authenticator;
public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email, string firstName, string lastName);
}

