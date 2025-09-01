namespace Ecss.Common.Extensions;

public static class StringExtensions
{
    public static bool SafeContains(this string? source, string? value, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        return !string.IsNullOrEmpty(source) &&
               !string.IsNullOrEmpty(value) &&
               source.Contains(value, comparison);
    }
}
