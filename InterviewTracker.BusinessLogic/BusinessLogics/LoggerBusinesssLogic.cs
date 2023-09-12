using InterviewTracker.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic
{
    public class LoggerBusinesssLogic : ILoggerBusinessLogic
    {
        private readonly ILogger<LoggerBusinesssLogic> _logger;

        public LoggerBusinesssLogic(ILogger<LoggerBusinesssLogic> logger) { 
            _logger = logger;
        }

        public void LogMessage(string message) 
        { 
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }
    }
}
