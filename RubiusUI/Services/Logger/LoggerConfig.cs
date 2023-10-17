using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace RubiusUI.Services.Logging
{
    /// <summary>
    /// Класс для создания логов
    /// </summary>
    public class LoggerConfig
    {
        /// <summary>
        /// Логгер для отображение информации
        /// </summary>
        public ILogger Logger()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();

                var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
                return logger;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}
