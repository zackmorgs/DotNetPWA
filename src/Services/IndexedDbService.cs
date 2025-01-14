using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;


using Data;
using Models;

public interface IIndexedDbService
{
    Task<List<WeatherForecast>> GetForecasts();
    Task SaveForecasts(WeatherForecast[] forecasts);
    Task AddForecast(WeatherForecast forecast);
}

public class IndexedDbService : IIndexedDbService
{
    private readonly IJSRuntime _jsRuntime;
    private const string DbName = "WeatherDb";
    private const string StoreName = "forecasts";

    public IndexedDbService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeDb()
    {
        await _jsRuntime.InvokeVoidAsync("initializeIndexedDb");
    }

    public async Task<List<WeatherForecast>> GetForecasts()
    {
        return await _jsRuntime.InvokeAsync<List<WeatherForecast>>("getFromIndexedDb", StoreName);
    }

    public async Task SaveForecasts(WeatherForecast[] forecasts)
    {
        await _jsRuntime.InvokeVoidAsync("saveToIndexedDb", StoreName, forecasts);
    }

    public async Task AddForecast(WeatherForecast forecast)
    {
        await _jsRuntime.InvokeVoidAsync("addToIndexedDb", StoreName, forecast);
    }
}