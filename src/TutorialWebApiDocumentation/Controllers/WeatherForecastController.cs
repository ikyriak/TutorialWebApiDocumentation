using Microsoft.AspNetCore.Mvc;
using TutorialWebApiDocumentation.DTOs;

namespace TutorialWebApiDocumentation.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]

    // List of available and deprecated Versions for this ApiController.
    [ApiVersion("1.0", Deprecated = false)]
    [ApiVersion("2.0")]

    // Specify the base (or current) API route to:
    // - Keep the existing route serving a default version (backward compatible).
    // - Support query string and HTTP header versioning.
    [Route("api/[controller]")]

    // Specify the route to support URI Versioning
    [Route("api/v{version:apiVersion}/[controller]")]

    [Consumes("application/json")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet, MapToApiVersion("1.0")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet, MapToApiVersion("2.0")]
        public IEnumerable<WeatherForecastV2> GetV2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastV2
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = 20,
                Summary = "V2:" + Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // The following action implementation is used for both versions.
        [HttpGet("{forecastId}")]
        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        public WeatherForecast GetById(int forecastId)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(forecastId),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

    }
}