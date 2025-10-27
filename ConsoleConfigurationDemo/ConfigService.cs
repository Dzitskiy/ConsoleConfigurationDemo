using ConfigurationClassLibrary;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleConfigurationDemo
{
    public class ConfigService
    {
        private readonly IConfiguration _configuration;

        public ConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiUrl => _configuration["AppSettings:ApiUrl"] ?? string.Empty;
        public string ApiKey => _configuration["AppSettings:ApiKey"] ?? string.Empty;
        public int TimeoutSeconds => _configuration.GetValue<int>("AppSettings:TimeoutSeconds");
        public int MaxRetries => _configuration.GetValue<int>("AppSettings:MaxRetries");
        public bool EnableLogging => _configuration.GetValue<bool>("AppSettings:EnableLogging");

        public void DisplayConfiguration()
        {
            Console.WriteLine($"Конфигурация приложения в сервисе {nameof(ConfigService)}");
            Console.WriteLine($"API URL: {ApiUrl}");
            Console.WriteLine($"API Key: {ApiKey}");
            Console.WriteLine($"Timeout: {TimeoutSeconds} сек");
            Console.WriteLine($"Max Retries: {MaxRetries}");
            Console.WriteLine($"Logging Enabled: {EnableLogging}");
            Console.WriteLine();
        }
    }
}
