using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWeatherApp.Models.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {
        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }

        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string weatherIcon;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation(Latitude, Longitude);
            if(weatherApiResponse != null) 
            {
                WeatherIcon = weatherApiResponse.current.weather_icons[0];
                Temperature = $"{weatherApiResponse.current.temperature}°C";
                Location = $"{weatherApiResponse.location.name}, {weatherApiResponse.location.region}, {weatherApiResponse.location.country}";
                WeatherDescription = weatherApiResponse.current.weather_descriptions[0];
                Humidity = weatherApiResponse.current.humidity;
                CloudCoverLevel = $"{weatherApiResponse.current.cloudcover}%";
                IsDay = weatherApiResponse?.current.is_day.ToUpper();
            }
        }
    }
}
