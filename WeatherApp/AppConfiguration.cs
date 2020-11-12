using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        static public string GetValue(String key)
        {
            var value = " ";
            if (configuration == null)
            {
                
                initConfig();
                value=configuration.GetSection("Configuration")["Apikey"]; 
                return value;
              
            }
            value = configuration.GetSection("Configuration")["Apikey"];
            return value;
            
        }

        static private void initConfig()
        {
            //Appsetting + UserSecret
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            builder.AddUserSecrets<MainWindow>();

            //Environement

            var devEnvVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvVariable) ||
                                    devEnvVariable.ToLower() == "development";

            if (isDevelopment)
            {
                builder.AddUserSecrets<MainWindow>();
            }
            configuration = builder.Build();

        }

    }
}
