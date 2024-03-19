using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly object _lock = new object();

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null; // This logger does not support scopes
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //This logger is always enabled.
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                var logMessage = $"[{DateTime.Now}] [{logLevel}] {formatter(state, exception)}{Environment.NewLine}";
                File.AppendAllText(_filePath, logMessage);
            }
        }
    }
}
