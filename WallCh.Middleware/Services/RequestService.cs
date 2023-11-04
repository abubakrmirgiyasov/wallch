using System.Net.Http.Headers;
using System.Text;
using WallCh.Domain.Common;

namespace WallCh.Middleware.Services;

public class RequestService<T>
{
    private readonly bool _needAuthentication;

    public RequestService(bool needAuthentication)
    {
        _needAuthentication = needAuthentication;
    }

    public HttpClient HttpClient
    {
        get
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.BASE_URL),
                Timeout = TimeSpan.FromSeconds(5),
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (_needAuthentication)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Constants.TOKEN_DEFAULT_SCHEME, "");

            return client;
        }
    }

    public async Task<T> GetRequestAsync(string route, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = await HttpClient.GetAsync(route, cancellationToken);
            var response = await request.Content.ReadAsStringAsync(cancellationToken);
            return JsonResponse<T>.GetResponse(request, response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> PostRequestAsync(string content, string route, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = await HttpClient.PostAsync(
                requestUri: route, 
                content: new StringContent(content, Encoding.UTF8, "application/json"),
                cancellationToken: cancellationToken);
            var response = await request.Content.ReadAsStringAsync(cancellationToken);
            return JsonResponse<T>.GetResponse(request, response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> PutRequestAsync(string content, string route, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = await HttpClient.PutAsync(
                requestUri: route,
                content: new StringContent(content, Encoding.UTF8, "application/json"),
                cancellationToken: cancellationToken);
            var response = await request.Content.ReadAsStringAsync(cancellationToken);
            return JsonResponse<T>.GetResponse(request, response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<T> DeleteRequestAsync(string route, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = await HttpClient.DeleteAsync(route, cancellationToken);
            var response = await request.Content.ReadAsStringAsync(cancellationToken);
            return JsonResponse<T>.GetResponse(request, response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
