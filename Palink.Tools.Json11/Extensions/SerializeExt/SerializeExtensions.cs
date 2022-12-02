using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Palink.Tools.Extensions.StringExt;

namespace Palink.Tools.Json11.Extensions.SerializeExt;

/// <summary>
/// SerializeExtensions
/// </summary>
public static class SerializeExtensions
{
    public static string ToJson(this object? obj,
        bool ignoreNull,
        string dateFormatString = "yyyy-MM-dd HH:mm:ss")
    {
        return JsonConvert.SerializeObject(obj, Formatting.None,
            new JsonSerializerSettings
            {
                DateFormatString = dateFormatString,
                NullValueHandling = ignoreNull
                    ? NullValueHandling.Ignore
                    : NullValueHandling.Include
            });
    }

    public static string ToJson(this object? obj,
        JsonSerializerSettings? jsonSerializerSettings = default)
    {
        return JsonConvert.SerializeObject(obj, Formatting.None, jsonSerializerSettings);
    }

    public static T? FromJson<T>(this string? jsonStr,
        JsonSerializerSettings? jsonSerializerSettings = default)
    {
        return jsonStr.IsNullOrEmpty()
            ? default
            : JsonConvert.DeserializeObject<T>(jsonStr, jsonSerializerSettings);
    }

    public static async Task<T?> FromJsonFile<T>(this string? filePath, string key = "",
        JsonSerializerSettings? jsonSerializerSettings = default)
        where T : new()
    {
        if (!File.Exists(filePath) || filePath.IsNullOrEmpty()) return new T();

        using var reader = new StreamReader(filePath);
        var json = await reader.ReadToEndAsync();

        if (string.IsNullOrEmpty(key))
            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);

        return JsonConvert.DeserializeObject<object>(json, jsonSerializerSettings) is not
            JObject obj
            ? new T()
            : JsonConvert.DeserializeObject<T>(obj[key]?.ToString() ?? string.Empty,
                jsonSerializerSettings);
    }
}