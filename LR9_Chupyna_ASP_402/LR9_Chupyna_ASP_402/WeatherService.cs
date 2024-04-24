using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LR9_Chupyna_ASP_402
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeather(string region);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetWeather(string region)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={region}&appid=e6711bef8339b8e13b7fcc7149537f84&units=metric");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(content);
            }
            throw new Exception("failed to retrieve data");
        }
    }

    public class WeatherResponse
    {
        public MainInfo Main { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
    }
}
