using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class FileLoggerSuccessLogin : ILogger
    {
        private readonly string _filePath;
        private readonly object _lock = new object();

        public FileLoggerSuccessLogin(string filePath)
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
                string logMessage = formatter(state, exception);
                string formattedMessage = $"{DateTime.Now} [{logLevel}] - {logMessage}";

                // Write the log message to the file
                File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
            }
        }

    }
}
