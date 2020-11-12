using OpenWeatherAPI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public interface ITemperatureService
    {
        public Task<TemperatureModel> GetTempAsync();
                  
       
    }
}