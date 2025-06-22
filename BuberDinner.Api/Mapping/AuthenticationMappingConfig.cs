using BuberDinner.Application.Authentication.Command.Register;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}
