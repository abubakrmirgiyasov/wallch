namespace WallCh.Middleware.Managers.Interfaces;

public interface IUserManager
{
    Task<List<WeatherForecast>> Get();
}
