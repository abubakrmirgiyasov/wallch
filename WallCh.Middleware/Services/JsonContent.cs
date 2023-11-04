using Newtonsoft.Json;

namespace WallCh.Middleware.Services;

internal class JsonContent<T>
{
    internal static string GetContent(T entity)
    {
        return JsonConvert.SerializeObject(
            value: entity,
            formatting: Formatting.None,
            settings: new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
    }
}
