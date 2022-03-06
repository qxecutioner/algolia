using Weather.Core.Ports;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Models;
using Newtonsoft.Json;

namespace Algolia.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private WeatherFacade facade;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        facade = new WeatherFacade();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpPost]
    public void addDays(){

        List<WeatherMO> weather = new(){
            new WeatherMO{ObjectID = Guid.NewGuid().ToString(), weather = "Cold"},
            new WeatherMO{ObjectID = Guid.NewGuid().ToString(), weather = "Hot"}
        };


        facade.handle(weather);
        // SearchClient client = new("KFRUB7SA4U","9ddbb5fefc9c96105cf35ef912d7c27b");
        // SearchIndex index = client.InitIndex("Weather");
        // index.SaveObjects(weather);

        //index.SaveObject(weather);
    }

    [HttpGet]
    [Route("/getweather")]
    public string GetWeather(string weatherType){
        return JsonConvert.SerializeObject( facade.handle(weatherType));
    }

    public class Weather{
        public string? ObjectID { get; init; }
        public string? weather { get; init; }
    }
}
