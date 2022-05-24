using Microsoft.Extensions.Logging;
using RoomManager.Transversal.Comun.Log;
using System;

namespace RoomManager.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        //Varibles de clase.
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory"></param>
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, message, args);
        }

    }//Fín class
}
