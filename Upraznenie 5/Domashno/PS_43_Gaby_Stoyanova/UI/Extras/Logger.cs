using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UI.Extras
{
    public class Logger
    {
        private string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            // Create a log entry with the current date and time
            string logEntry = $"{DateTime.Now}: {message}";

            // Write the log entry to the log file
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
