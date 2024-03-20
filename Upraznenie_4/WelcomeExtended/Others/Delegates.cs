using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");
        private static readonly ILogger _errorLogger = LoggerHelper.GetErrorLogger("ErrorLogger");
        public static void Log(string error)
        {
            logger.LogError(error);
        }
        public static void Log2(string error) 
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
        public static void Log3(string error)
        {
            // Log some messages
            logger.LogInformation("Information message => Task 4");
            logger.LogWarning("Warning message => Task 4");
            logger.LogError("Error message => Task 4");
        }

        public static void Log4(string logMessage)
        {
            // Log the provided message
            logger.LogInformation(logMessage);
        }

        public static void Log5(string logMessage)
        {
            // Log the provided message
            _errorLogger.LogInformation(logMessage);
        }
    }
}
