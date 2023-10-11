using Calculator.Controllers;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorTests.Controllers
{
    public class CalculatorControllerTest
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(-1,2,1)]
        [InlineData(1,-2,-1)]
        [InlineData(-1,-2,-3)]
        public async void AddingNumbersGivesCorrectResult(decimal number1, decimal number2, decimal expectation)
        {
            // Arrange, Act
            var calculator = new CalculatorController();
            var result = await calculator.Addition(new CalculationRequest { Number1 = number1, Number2 = number2 });
            // Assert
            Assert.Equal(expectation, result.Result);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(-1, -2, 0.5)]
        [InlineData(-1, 2, -0.5)]
        [InlineData(1, -2, -0.5)]
        public async void DividingNumbersGivesCorrectResult(decimal number1, decimal number2, decimal expectation)
        {
            // Arrange, Act
            var calculator = new CalculatorController();
            var result = (OkObjectResult)await calculator.Division(new CalculationRequest { Number1 = number1, Number2 = number2 });
            CalculationResult? calculationResult = result.Value as CalculationResult;
            // Assert
            Assert.NotNull(calculationResult);
            Assert.Equal(expectation, calculationResult?.Result);
        }

        [Theory]
        [InlineData(1, 0, "Divide by zero error")]
        public async void DividingNumbersGivesErrorResult(decimal number1, decimal number2, string expectation)
        {
            // Arrange, Act
            var calculator = new CalculatorController();
            var result = (BadRequestObjectResult)await calculator.Division(new CalculationRequest { Number1 = number1, Number2 = number2 });
            string? error = result.Value as string;
            // Assert
            Assert.True(!string.IsNullOrEmpty(error));
            Assert.Equal(expectation, error);
        }


    }
}