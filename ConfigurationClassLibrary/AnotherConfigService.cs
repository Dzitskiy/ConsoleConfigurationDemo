using Microsoft.Extensions.Configuration;

namespace ConfigurationClassLibrary
{
    public class AnotherConfigService
    {
        private readonly IConfiguration _configuration;

        public AnotherConfigService(IConfiguration configuration)
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
            Console.WriteLine($"Конфигурация приложения в сервисе {nameof(AnotherConfigService)}");
            Console.WriteLine($"API URL: {ApiUrl}");
            Console.WriteLine($"API Key: {ApiKey}");
            Console.WriteLine($"Timeout: {TimeoutSeconds} сек");
            Console.WriteLine($"Max Retries: {MaxRetries}");
            Console.WriteLine($"Logging Enabled: {EnableLogging}");
            Console.WriteLine();
        }
    }
}