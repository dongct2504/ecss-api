using Ecss.Domain.Interfaces.ExternalServices;
using Serilog.Core;
using Serilog.Events;

namespace Ecss.DataAccess.ExternalServices;

public class VietnamDateTimeEnricher : ILogEventEnricher
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public VietnamDateTimeEnricher(IDateTimeProvider datetimeProvider)
    {
        _dateTimeProvider = datetimeProvider;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        DateTime vietnamDateTime = _dateTimeProvider.VietnamDateTimeNow;
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("VietnamDateTime", vietnamDateTime));
    }
}
