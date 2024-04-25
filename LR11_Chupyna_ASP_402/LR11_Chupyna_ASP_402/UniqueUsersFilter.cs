using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace LR11_Chupyna_ASP_402
{
    public class UniqueUsersFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public UniqueUsersFilter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log user's IP address to count unique users
            string userIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            if (!string.IsNullOrEmpty(userIp))
            {
                File.AppendAllText(_logFilePath, $"User IP: {userIp} | Time: {DateTime.Now}" + Environment.NewLine);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optionally log action execution completion
        }
    }
}
