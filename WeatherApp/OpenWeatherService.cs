using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    public class OpenWeatherService:ITemperatureService
    {
        private OpenWeatherProcessor owp;
        
        public TemperatureModel LastTemp;

        public OpenWeatherService(string apiKey)
        {
            owp=OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
                     
        }
        public async Task<TemperatureModel> GetTempAsync()
        {

            try
            {
                var currentweather = await owp.GetCurrentWeatherAsync();
                TemperatureModel temp = new TemperatureModel();

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                temp.DateTime = start.AddSeconds(currentweather.DateTime).ToLocalTime();

                temp.Temperature = currentweather.Main.Temperature;
                TemperatureConverter.FahrenheitInCelsius(temp.Temperature);
                temp.Temperature = Math.Round(temp.Temperature, 0);

                LastTemp = temp;

                return temp;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }

            return null;
        }   
    }

 
}
