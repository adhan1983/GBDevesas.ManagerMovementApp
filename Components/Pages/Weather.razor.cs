using GBDevesas.ManagerMovementApp.Models;
using GBDevesas.ManagerMovementApp.Services;
using Microsoft.AspNetCore.Components;

namespace GBDevesas.ManagerMovementApp.Components.Pages;
public partial class Weather
{
    [Inject] private WeatherService WeatherService { get; set; } = default!;

    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await WeatherService.GetForecastsAsync();
    }
}