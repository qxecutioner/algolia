using Weather.Core.Ports;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Models;
using Newtonsoft.Json;

namespace Algolia.Controllers;

[ApiController]
[Route("[controller]")]
public class AlgoliaController : ControllerBase{

    private readonly ILogger<WeatherForecastController> _logger;

    private WeatherFacade facade;

    public AlgoliaController(ILogger<WeatherForecastController> logger, WeatherFacade facade){

        _logger = logger;
        this.facade = facade;

    }

    [HttpGet]
    [Route("/indeces")]
    public List<string> getIndices(){
        return facade.handle();
    }

    [HttpGet]
    [Route("/{index}")]
    public string getIndex(string index) {

        string result = "";

        switch (index){
            case "weather":
                result = JsonConvert.SerializeObject(facade.handle<WeatherMO>().Take(2));
                break;
        }

        return result;
    }

}