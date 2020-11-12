using Microsoft.Extensions.Configuration;
using OpenWeatherAPI;
using System;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;
          
        
        public MainWindow()
        {
            InitializeComponent();     

            ApiHelper.InitializeClient();
            var config = AppConfiguration.GetValue("ApiKey");
            ITemperatureService ops = new OpenWeatherService(config);


            vm = new TemperatureViewModel(ops);
            DataContext = vm;           
        }

     
    }
}
