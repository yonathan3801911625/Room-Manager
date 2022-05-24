using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Transversal.Comun.Log
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWarning(string message, params object[] args);

        void LogError(Exception ex, string message, params object[] args);
    }
}
