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
            var result = await calculator.Addition(new CalculationRequest(number1, number2));
            // Assert
            Assert.Equal(expectation, result.Result);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, 5.0, 15.0)]
        [InlineData(null, 2.0, 3.0, 4.0, 5.0, 14.0)]
        [InlineData(1.0, null, 3.0, 4.0, 5.0, 13.0)]
        [InlineData(1.0, 2.0, null, 4.0, 5.0, 12)]
        [InlineData(1.0, 2.0, 3.0, null, 5.0, 11)]
        [InlineData(1.0, 2.0, 3.0, 4.0, null, 10)]
        [InlineData(null, null, null, null, null, 0)]
        [InlineData(1.0, null, null, null, null, 1)]
        [InlineData(null, 2.0, null, null, null, 2)]
        [InlineData(null, null, 3.0, null, null, 3)]
        [InlineData(null, null, null, 4.0, null, 4)]
        [InlineData(null, null, null, null, 5.0, 5)]
        public async void AddingUpToFiveNumbersGivesCorrectResult(double? number1, double? number2, double? number3, double? number4, double? number5, decimal expectation)
        {
            //Arrange, Act
            var calculator = new CalculatorController();
            var result = await calculator.Addition(new CalculationRequestExt((decimal)(number1 ?? 0), (decimal)(number2 ?? 0), (decimal?)number3, (decimal?)number4, (decimal?)number5));
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
            var result = (OkObjectResult)await calculator.Division(new CalculationRequest(number1, number2));
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
            var result = (BadRequestObjectResult)await calculator.Division(new CalculationRequest(number1, number2));
            string? error = result.Value as string;
            // Assert
            Assert.True(!string.IsNullOrEmpty(error));
            Assert.Equal(expectation, error);
        }
    }
}