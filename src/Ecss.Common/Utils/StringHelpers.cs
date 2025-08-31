using System.Text.RegularExpressions;

namespace Ecss.Common.Utils;

public static class StringHelpers
{
    public static string ToKebabCase(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return Regex.Replace(value, "([a-z0-9])([A-Z])", "$1-$2").ToLower();
    }
}
