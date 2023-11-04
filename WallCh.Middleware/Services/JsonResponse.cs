using Newtonsoft.Json;

namespace WallCh.Middleware.Services;

internal class JsonResponse<T>
{
    internal static T GetResponse(HttpResponseMessage response, string content)
    {
        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<T>(content)!;

        throw new Exception(JsonConvert.DeserializeObject<string>(content));
    }
}
