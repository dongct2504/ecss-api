using System.Text.Json.Serialization;

namespace Ecss.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderByEnum
{
    Asc,
    Desc
}
