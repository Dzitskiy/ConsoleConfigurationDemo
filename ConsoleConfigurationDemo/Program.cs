using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConfigurationClassLibrary;
using ConsoleConfigurationDemo.Services;

// Создание и конфигурация хоста
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Добавляем appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Регистрируем наши сервисы для DI
        services.AddSingleton<ConfigService>();
        services.AddSingleton<AnotherConfigService>();

    })
    .Build();

// Получаем сервисы из контейнера зависимостей
var configService = host.Services.GetRequiredService<ConfigService>();
configService.DisplayConfiguration();
var anotherConfigService = host.Services.GetRequiredService<AnotherConfigService>();
anotherConfigService.DisplayConfiguration();

// Пример использования конфигурации в бизнес-логике
Console.WriteLine("\nПроверка конфигурации:");
if (string.IsNullOrEmpty(configService.ApiKey))
{
    Console.WriteLine("Ошибка: API Key не настроен!");
}
else
{
    Console.WriteLine("API Key настроен корректно");
}

Console.WriteLine("\nНажмите любую клавишу для выхода...");
Console.ReadKey();