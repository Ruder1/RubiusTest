using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace RubiusUI.Services.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Логгер для отображение информации
        /// </summary>
        public void InfoLogg()
        {
            using (var log = new LoggerConfiguration().WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day).CreateLogger())
            {
                log.Information("This is an informational message.");
                log.Warning("This is a warning for testing purposes.");
            }
        }
    }
}
