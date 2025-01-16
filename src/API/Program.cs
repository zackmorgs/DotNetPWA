using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly;

using System.Net.Http.Json;

using Data;
using Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Get MS SQL connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add MS SQL service to the container.
builder.Services.AddDbContext<Db>(options =>
    options.UseSqlServer(connectionString));

// add db error viewing.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Specify which database to use for Identity.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Db>();

// Configure authentication
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

// Add authorization
// builder.Services.AddAuthorization();


// Register Custom Services
builder.Services.AddScoped<WeatherForecastService>();

// OpenAPI (Swagger)
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// CORS policy
builder.Services.AddCors(options =>
    options.AddPolicy("API", policy =>
        policy.WithOrigins(builder.Configuration["FrontendUrl"] ?? "http://localhost:5225")
              .AllowAnyMethod()
              .AllowAnyHeader()));

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseCors("API");

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();
app.MapControllers();

// Endpoints
app.MapGet("/weatherforecast", async (WeatherForecastService weatherService) =>
{
    var forecasts = await weatherService.GetWeatherForecast();
    return forecasts;
})
.WithName("GetWeatherForecast");


app.MapPost("/weatherforecast", async (WeatherForecast forecast, WeatherForecastService weatherService) =>
{
    try
    {
        await weatherService.AddWeatherForecast(forecast);
        return Results.Ok("Weather forecast added successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return Results.Problem("An error occurred while adding the weather forecast.");
    }
})
.WithName("AddWeatherForecast");

app.MapPost("/weatherforecast", async (int Id, WeatherForecastService weatherService) =>
{
    try
    {
        await weatherService.RemoveWeatherForecast(Id);
        return Results.Ok("Weather forecast added successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return Results.Problem("An error occurred while adding the weather forecast.");
    }
})
.WithName("RemoveWeatherForecast");

app.MapPut("/weatherforecast", async (List<WeatherForecast> forecasts, WeatherForecastService weatherService) => 
{
    try
    {
        if (forecasts == null || !forecasts.Any())
        {
            throw new Exception("No weather forecasts provided.");
        }
        else
        {
            foreach (var forecast in forecasts)
            {
                // Check if the forecast already exists in the database
                var hasExistingForecast = await weatherService.HasWeatherForecast(forecast);

                if (hasExistingForecast != null)
                {
                    // Update the existing forecast
                    forecast.DateTime = forecast.DateTime;
                    forecast.TemperatureC = forecast.TemperatureC;
                    forecast.Summary = forecast.Summary;
                }
                else
                {
                    // Add a new forecast if it doesn't exist
                    await weatherService.AddWeatherForecast(forecast);
                }
            }
        }
        return Results.Ok("Weather forecasts updated successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return Results.Problem("An error occurred while adding the weather forecast.");
    }
}).WithName("SetWeatherForecast");

// Run the application
app.Run();
