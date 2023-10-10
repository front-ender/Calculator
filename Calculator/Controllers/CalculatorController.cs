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



        /// <summary>
        /// Division - divide Number1 by Number2
        /// Throws DivideByZeroException
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result as a decimal</returns>
        [Route("Division")]
        [HttpPost()]
        [ProducesResponseType(typeof(CalculationResult), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> Division([FromBody] CalculationRequest request)
        {
            var filelogger = new FileLogger(new FileInfo(new StringBuilder(Environment.CurrentDirectory).Append(CalculatorFile).ToString()));
            var consolelogger = new ConsoleLogger();

            var logEntry = $"Dividing {request.Number1} by {request.Number2}";
            var _ = await filelogger.LogEntry(logEntry);
            _ = await consolelogger.LogEntry(logEntry);

            try
            {
                decimal result = request.Number1 / request.Number2;
                return Ok(new CalculationResult
                {
                    Result = result,
                });
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Divide by zero error");
            }
            catch
            {
                return BadRequest("The operation is invalid");
            }
        }
    }
}