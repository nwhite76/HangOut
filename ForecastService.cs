#nullable enable

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ForecastService
{
    private readonly string apiKey = "b40c63a5b29f1e90c3d56084d84b20c0";
    private readonly HttpClient httpClient = new();

    public async Task<WeatherForecast?> GetForecastAsync(double lat, double lon)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?" +
             $"lat={lat}&lon={lon}&units=metric&appid={apiKey}";
        Console.WriteLine(url);

        try
        {
            var response = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherForecast>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Weather API error: {ex.Message}");
            return null;
        }
    }
}
