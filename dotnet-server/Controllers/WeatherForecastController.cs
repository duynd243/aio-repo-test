using dotnet_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_server.Controllers;

[ApiController]
[Route("")]
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

    [HttpGet("/get-weather")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Hello i'm a log");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("/hello/{name}")]
    public string Get(string name)
    {
        return $"Your name: {name}";
    }

    [HttpGet("/post-person")]
    public Person GetPerson()
    {
        var person = new Person()
        {
            Name = "John",
            Email = "abc@gmail.com",
        };
        return person;
    }
}