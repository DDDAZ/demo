using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        [HttpGet("weatherforecast")]
        public WeatherForecast GetFirstData()
        {
            return new WeatherForecast();
        }
    }
}
