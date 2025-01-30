using FuzzLib;

using Microsoft.AspNetCore.Mvc;

namespace FuzzAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IArithmeticOperations _arithmeticOperations;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IArithmeticOperations arithmeticOperations) {
            _logger = logger;
            _arithmeticOperations = arithmeticOperations;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IEnumerable<WeatherForecast> Post([FromBody]WeatherForecast forecast) {
            _arithmeticOperations.SetValue(int.MinValue + 100);
            _arithmeticOperations.CheckedSubtract(forecast.TemperatureC);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
