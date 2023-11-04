using WallCh.Middleware.Managers.Interfaces;
using WallCh.Middleware.Services;

namespace WallCh.Middleware.Managers;

public class UserManager : IUserManager
{
    public async Task<List<WeatherForecast>> Get()
    {
        var baseRequestService = new RequestService<List<WeatherForecast>>(false);
        return await baseRequestService.GetRequestAsync("WeatherForecast");
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}