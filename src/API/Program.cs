using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Data;
using Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Connection String
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<Db>(options =>
    options.UseSqlServer(connectionString));

// Identity configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    
    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    
    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<Db>()
.AddDefaultTokenProviders();

// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

// Add authorization
builder.Services.AddAuthorization();


// Register custom services
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

// Configure the HTTP request pipeline
app.UseAuthentication();
app.UseAuthorization();


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

// Run the application
app.Run();
