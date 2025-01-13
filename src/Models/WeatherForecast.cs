

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        [Key]
        public int Id { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

}