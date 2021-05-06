using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_core5.Controllers
{
    [ApiController]
    [Area("Test")]
    [Route("[area]/[controller]")]
    public class WeatherForecast1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecast1Controller(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 0..0
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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

        /// <summary>
        /// 哪泥，居然成功惹
        /// </summary>
        /// <param name="id">Guraaaaaaa</param>
        /// <returns></returns>
        [HttpGet("GetTest")]
        public IEnumerable<int> GetTest(int id)
        {
            return Enumerable.Range(1, id);
        }

        /// <summary>
        /// I AM batman
        /// </summary>
        /// <param name="batMan">so bat</param>
        /// <returns>0..0</returns>
        [HttpPost("IAmBatMan")]
        public string IAmBatman(Batman batMan)
        {
            return $"I am Batman. {batMan.Message}";
        }

        /// <summary>
        /// cba
        /// </summary>
        public class Batman
        {
            /// <summary>
            /// abc
            /// </summary>
            public string Message { get; set; }
        }
    }
}
