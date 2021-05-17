using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi_Net5.Areas.Test.Controllers.NuclearTest.ReqModel;
using WebApi_Net5.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebApi_Net5.DTO;
using WebApi_Net5.Helper;

namespace WebApi_core5.Controllers
{
    [ApiController]
    [Area("Test")]
    [Route("[area]/[controller]/[action]")]
    public class NuclearTestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly TestDb _testDb;
        private readonly ILogger<NuclearTestController> _logger;

        public NuclearTestController(ILogger<NuclearTestController> logger, TestDb testDb)
        {
            _testDb = testDb;
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
        /// 成功惹
        /// </summary>
        /// <param name="id">Guraaaaaaa</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<int> GetTest(int id)
        {
            return Enumerable.Range(1, id);
        }

        /// <summary>
        /// Hello Batman
        /// </summary>
        /// <remarks>
        /// # Welcome to Markdown zone
        /// ### Sample area
        /// Sample request:
        /// 
        ///     {
        ///         "Name": "YourName",
        ///         "GreetingMessage": "Greeting",
        ///         "Children": [
        ///             { "Name": "OtherName", "GreetingMessage": "Farewell" },
        ///             { "Name": "AnotherName", "GreetingMessage": "Nice to meet you" }
        ///         ]
        ///     }
        /// ---
        ///     Arye~~~~~
        /// 1. a
        /// 2. b
        /// * c
        /// * d
        /// ```
        /// const double pi = 3.1415926;
        /// ```
        /// </remarks>
        /// <param name="req">Request model</param>
        /// <returns></returns>
        [HttpPost]
        public string IAmBatman([FromBody] Greetings req)
        {
            return $"{req}\n" +
                $"{string.Join('\n', req.Children)}" +
                $"I am Batman peko desu.\n";
        }

        [HttpGet]
        public string LoggerTest()
        {
            _logger.LogDebug("owo");
            _logger.LogTrace("owo");
            _logger.LogInformation("owo");
            _logger.LogWarning("owo");
            _logger.LogError("owo");
            _logger.LogCritical("owo");

            return "owo";
        }

        [HttpPost]
        public string DbTest([FromBody] DbTest req)
        {
            var param = new DynamicParameters();
            //param.Add("ThirdPartyCode", null, DbType.String);
            param.AddDynamicParams(new { ThirdPartyCode = default(string) });

            var result = _testDb.C_Test("[Back].[s_ThirdParty_Get]", param, CommandType.StoredProcedure);

            return JsonConvert.SerializeObject(result);
        }

#if DEBUG
        [HttpPost]
        public string DbGet([FromBody] DbTest req)
        {
            var param = DbParamHelper.Generate(req.Param);

            var result = _testDb.GetAll<object>(req.Query, param, CommandType.Text);

            return JsonConvert.SerializeObject(result);
        }
#endif

        [HttpGet]
        public void ExceptionTest()
        {
            throw new Exception("Exception Test");
        }
    }
}
