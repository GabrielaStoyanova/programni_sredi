using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;

        public LoggerProvider(string filePath)
        {
            _filePath = filePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            

            // Create a FileLogger instance for writing to a file
            ILogger fileLogger = new FileLogger(_filePath);

            // Create a HashLogger instance for other logging purposes
            ILogger hashLogger = new HashLogger(categoryName);

            // Return the FileLogger instance
            return fileLogger;
            // Return the HashLogger instance
            // return hashLogger;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
