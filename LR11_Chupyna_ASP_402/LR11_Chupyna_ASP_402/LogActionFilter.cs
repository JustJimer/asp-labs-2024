using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace LR11_Chupyna_ASP_402
{
    public class LogActionFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public LogActionFilter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log action method name and execution start time
            string logMessage = $"Action Method: {context.ActionDescriptor.DisplayName} | Time: {DateTime.Now}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optionally log action execution completion
        }
    }
}
