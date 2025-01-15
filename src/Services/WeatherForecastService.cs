using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class WeatherForecastService
{
    private readonly Db _db;

    public WeatherForecastService(Db db)
    {
        _db = db;
    }

    public async Task<List<WeatherForecast>> GetWeatherForecast()
    {
        return await _db.WeatherForecasts.ToListAsync();
    }

    public async Task AddWeatherForecast(WeatherForecast forecast)
    {
        _db.WeatherForecasts.Add(forecast);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveWeatherForecast(int id)
    {
        var forecast = await _db.WeatherForecasts.FindAsync(id);
        if (forecast != null)
        {
            _db.WeatherForecasts.Remove(forecast);
            await _db.SaveChangesAsync();
        }
    }

    public async Task SetWeatherForecast(IEnumerable<WeatherForecast> forecasts)
    {
    
        _db.WeatherForecasts.RemoveRange(_db.WeatherForecasts);
        _db.WeatherForecasts.AddRange(forecasts);

        await _db.SaveChangesAsync();
    }

    public async Task<Boolean> HasWeatherForecast(WeatherForecast forecast)
    {
        return await _db.WeatherForecasts.AnyAsync(f => f.DateTime == forecast.DateTime);
    }
}
