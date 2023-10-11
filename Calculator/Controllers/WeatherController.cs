using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        public const string CalculatorFile = @"\CalculatorLog.txt";

        [Route("GetTemperatureForCity")]
        [HttpGet()]
        public async Task<double> GetTemperatureForCity([FromQuery] string city)
        {
            var filelogger = new FileLogger(new FileInfo(new StringBuilder(Environment.CurrentDirectory).Append(CalculatorFile).ToString()));

            var temperature = await new WeatherApiService("0db5d6c88d38429c861101656231010").GetTemperatureForCity(city);
            var _ = await filelogger.LogEntry($"Temperature for {city} is {temperature}");
            return temperature;
        }
    }
}
