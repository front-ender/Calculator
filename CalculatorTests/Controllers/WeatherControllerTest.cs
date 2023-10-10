using Calculator.Controllers;

namespace CalculatorTests.Controllers
{
    public class WeatherControllerTest
    {
        [Fact]
        public async void GetTemperature()
        {
            var result = await new WeatherController().GetTemperatureForCity("Aarhus");
            Console.WriteLine($"Temperature was {result}");
            Assert.True(result > -40);
        }
    }
}