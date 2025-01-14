

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public record WeatherForecast()
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TemperatureC { get; set; }   
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

}