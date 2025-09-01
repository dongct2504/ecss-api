namespace Ecss.Domain.Interfaces.ExternalServices;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
    public DateTime UtcNow { get; }
    public DateTime VietnamDateTimeNow { get; }
}
