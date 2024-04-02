using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Database;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    public static class LoggerHelper
    {
        // Pass the filePath parameter to LoggerProvider constructor
        private const string LogFilePath = "logSuccessLogin.txt";
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider(LogFilePath)); // Provide the filePath parameter

            return loggerFactory.CreateLogger(categoryName);
        }

        // Add a new method to get a logger specifically for logging errors
        public static ILogger GetErrorLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new ErrorLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }

    }
}
