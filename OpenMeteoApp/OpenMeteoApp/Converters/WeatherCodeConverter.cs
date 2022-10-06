using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OpenMeteoApp.Converters
{
    class WeatherCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = "";
            switch ((double)value)
            {
                case 0.0:
                    text = "Clear sky";
                    break;
                case 1.0:
                    text = "Mainly clear, partly cloudy, and overcast";
                    break;
                case 2.0:
                    text = "Mainly clear, partly cloudy, and overcast";
                    break;
                case 3.0:
                    text = "Mainly clear, partly cloudy, and overcast";
                    break;
                case 45.0:
                    text = "Fog and depositing rime fog";
                    break;
                case 48.0:
                    text = "Fog and depositing rime fog";
                    break;
                case 51.0:
                    text = "Drizzle: Light, moderate, and dense intensity";
                    break;
                case 53.0:
                    text = "Drizzle: Light, moderate, and dense intensity";
                    break;
                case 55.0:
                    text = "Drizzle: Light, moderate, and dense intensity";
                    break;
                case 56.0:
                    text = "Freezing Drizzle: Light and dense intensity";
                    break;
                case 57.0:
                    text = "Freezing Drizzle: Light and dense intensity";
                    break;
                case 61.0:
                    text = "Rain: Slight, moderate and heavy intensity";
                    break;
                case 63.0:
                    text = "Rain: Slight, moderate and heavy intensity";
                    break;
                case 65.0:
                    text = "Rain: Slight, moderate and heavy intensity";
                    break;
                case 66.0:
                    text = "Freezing Rain: Light and heavy intensity";
                    break;
                case 67.0:
                    text = "Freezing Rain: Light and heavy intensity";
                    break;
                case 71.0:
                    text = "Snow fall: Slight, moderate, and heavy intensity";
                    break;
                case 73.0:
                    text = "Snow fall: Slight, moderate, and heavy intensity";
                    break;
                case 75.0:
                    text = "Snow fall: Slight, moderate, and heavy intensity";
                    break;
                case 77.0:
                    text = "Snow grains";
                    break;
                case 80.0:
                    text = "Rain showers: Slight, moderate, and violent";
                    break;
                case 81.0:
                    text = "Rain showers: Slight, moderate, and violent";
                    break;
                case 82.0:
                    text = "Rain showers: Slight, moderate, and violent";
                    break;
                case 85.0:
                    text = "Snow showers slight and heavy";
                    break;
                case 86.0:
                    text = "Snow showers slight and heavy";
                    break;
                case 95.0:
                    text = "Thunderstorm: Slight or moderate";
                    break;
                case 96.0:
                    text = "Thunderstorm with slight and heavy hail";
                    break;
                case 99.0:
                    text = "Thunderstorm with slight and heavy hail";
                    break;
            }

            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
