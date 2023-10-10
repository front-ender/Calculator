using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        public const string CalculatorFile = @"\CalculatorLog.txt";

        [Route("Addition")]
        [HttpPost()]
        public async Task<CalculationResult> Addition([FromBody] CalculationRequest request)
        {

            var filelogger = new FileLogger(new FileInfo(new StringBuilder(Environment.CurrentDirectory).Append(CalculatorFile).ToString()));
            var consolelogger = new ConsoleLogger();

            var logEntry = $"Adding {request.Number1} to {request.Number2}";
            var _ = await filelogger.LogEntry(logEntry);
            _ = await consolelogger.LogEntry(logEntry);

            return new CalculationResult
            {
                Result = request.Number1 + request.Number2,
            };
        }
    }
}