using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic.Interfaces
{
    public interface ILoggerBusinessLogic
    {
        void LogMessage(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
