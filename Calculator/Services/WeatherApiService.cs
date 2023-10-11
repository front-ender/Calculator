using Newtonsoft.Json;

namespace Calculator.Services
{
    public class WeatherApiService
    {
        public string ApiKey { get; private set; }

        public WeatherApiService(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<double> GetTemperatureForCity(string cityName)
        {
            HttpClient client = new HttpClient();

            string url = $"https://api.weatherapi.com/v1/current.json?key={ApiKey}&q={cityName}";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Let's not create the model - but use dynamic instead for runtime evaluations
                dynamic data = JsonConvert.DeserializeObject(json);

                return data.current.temp_c;
            }
            else
            {
                throw new Exception($"Failed to fetch weather data for city {cityName}: {response.StatusCode}");
            }
        }
    }
}
