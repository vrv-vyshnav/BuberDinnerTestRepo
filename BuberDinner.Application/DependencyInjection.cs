
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}