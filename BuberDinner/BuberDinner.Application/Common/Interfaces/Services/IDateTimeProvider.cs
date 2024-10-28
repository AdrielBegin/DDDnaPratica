namespace BuberDinner.Application.Common.Interfarces.Services;

public interface IDateTimeProvider 
{
    DateTime UtcNow { get; }
}