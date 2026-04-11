using System.Net.Http.Json;
using GBDevesas.ManagerMovementApp.Models;

namespace GBDevesas.ManagerMovementApp.Services;

public class WeatherService
{
    private readonly HttpClient _http;

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("API");
    }

    public Task<WeatherForecast[]?> GetForecastsAsync() =>
        _http.GetFromJsonAsync<WeatherForecast[]>("api/WeatherForecast");
}