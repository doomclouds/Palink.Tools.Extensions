using Palink.Tools.Json11.Extensions.SerializeExt;

namespace Palink.Tools.Json11.Extensions.ConvertExt;

/// <summary>
/// ConvertExtensions
/// </summary>
public static class ConvertExtensions
{
    /// <summary>
    /// json to value tuple
    /// </summary>
    /// <param name="valueTupleJson"></param>
    /// <returns></returns>
    public static T? TryToValueTuple<T>(this string valueTupleJson)
    {
        return valueTupleJson.FromJson<T>();
    }

    /// <summary>
    /// tuple to json
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string TupleTryToString<T>(this T value) where T : struct
    {
        return value.ToJson();
    }
}