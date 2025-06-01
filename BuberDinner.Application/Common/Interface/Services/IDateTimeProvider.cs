namespace BuberDinner.Application.common.Interface.services;

public interface IDatetimeProvider
{
    DateTime UtcNow { get; }
}
