namespace Ecss.Domain.Interfaces.ExternalServices;

public interface ILocalizationService
{
    string Get(string key, params object[] arguments);
}
