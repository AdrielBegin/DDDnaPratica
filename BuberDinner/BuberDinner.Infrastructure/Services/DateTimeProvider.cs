using BuberDinner.Application.Common.Interfarces.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider 
{
    public DateTime UtcNow => DateTime.UtcNow;
}