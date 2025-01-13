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
    public List<string> Summaries = new List<string> { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
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
}
