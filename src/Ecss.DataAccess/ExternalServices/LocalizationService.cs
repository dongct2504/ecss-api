using Ecss.DataAccess.ExternalServices.Resources;
using Ecss.Domain.Interfaces.ExternalServices;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Ecss.DataAccess.ExternalServices;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer _localizer;

    public LocalizationService(IStringLocalizerFactory factory)
    {
        var type = typeof(Messages);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
        _localizer = factory.Create("Messages", assemblyName.Name);
    }

    public string Get(string key, params object[] arguments)
    {
        return _localizer[key, arguments];
    }
}
