using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;

using Data;
using Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Db>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<WeatherForecastService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(
    options => options.AddPolicy(
        "API",
        policy => policy.WithOrigins(builder.Configuration["FrontendUrl"] ?? "http://localhost:5225")
            .AllowAnyMethod()
            .AllowAnyHeader()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async () =>
{
    // use the WeatherService to retrieve the weather forecast
    var weatherService = app.Services.GetRequiredService<WeatherForecastService>();
    var forecasts = await weatherService.GetWeatherForecast();
    return forecasts;
})
.WithName("GetWeatherForecast");

app.MapPut("/weatherforecast", async (WeatherForecast forecast) => {
    try
    {
        var weatherService = app.Services.GetRequiredService<WeatherForecastService>();
        await weatherService.AddWeatherForecast(forecast);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    } 
    finally
    {
        Console.WriteLine("/weatherforecast put resolved.");
    }
    return Results.Ok();
}).WithName("AddWeatherForecast");


// Activate the CORS policy
app.UseCors("API");

app.Run();

