using BuberDinner.Application.common.Interface.services;

namespace BuberDinner.infrastructure.services;

public class DateTimeProvider : IDatetimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}