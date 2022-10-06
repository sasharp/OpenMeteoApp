using OpenMeteoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Linq;

namespace OpenMeteoApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        HttpClient client = new HttpClient();
        private Weather weather;
        public Weather Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                NotifyPropertyChanged(nameof(Weather));
            }
        }

        private Current currentHour;
        public Current CurrentHour
        {
            get { return currentHour; }
            set
            {
                currentHour = value;
                NotifyPropertyChanged(nameof(CurrentHour));
            }
        }

        private ObservableCollection<Current> hours;

        public ObservableCollection<Current> Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                NotifyPropertyChanged(nameof(Hours));
            }
        }

        private Models.Location location;

        public Models.Location Location
        {
            get { return location; }
            set
            {
                location = value;
                NotifyPropertyChanged(nameof(Location));
            }
        }

        public async Task GetWeatherForGeolocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    await GetWeatherAsync(location.Latitude, location.Longitude);
                } else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Can't get location", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public async Task SearchGeolocationAsync(string searchTerm)
        {
            string json;
            try
            {
                HttpResponseMessage result = await client.GetAsync("https://geocoding-api.open-meteo.com/v1/search?name=" + searchTerm + "&count=1");
                json = await result.Content.ReadAsStringAsync();
                Models.LocationResults locationResults = JsonSerializer.Deserialize<Models.LocationResults>(json);
                if (locationResults.results != null && locationResults.results.Length > 0)
                {
                    Location = locationResults.results[0];
                    await GetWeatherAsync(locationResults.results[0].Latitude, locationResults.results[0].Longitude);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public async Task GetWeatherAsync(double lat, double lon)
        {
            string json;
            try
            {
                HttpResponseMessage result = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=" + lat + "&longitude="+ lon + "&hourly=temperature_2m,weathercode,windspeed_10m,winddirection_10m&current_weather=true&timezone=auto");
                json = await result.Content.ReadAsStringAsync();
                Weather = JsonSerializer.Deserialize<Weather>(json);
                ObservableCollection<Current> hourly = new ObservableCollection<Current>();
                for (int i = 0; i < Weather.Hourly.Time.Length; i++)
                {
                    hourly.Add(new Current()
                    {
                        Time = Weather.Hourly.Time[i],
                        Temperature = Weather.Hourly.Temperature2M[i],
                        Weathercode = Weather.Hourly.Weathercode[i],
                        Windspeed = Weather.Hourly.Windspeed10M[i],
                        Winddirection = Weather.Hourly.Winddirection10M[i]
                    });
                }
                hourly.Add(Weather.CurrentWeather);
                hourly.OrderBy(hour => hour.Time);
                Hours = hourly;
                CurrentHour = Weather.CurrentWeather;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
