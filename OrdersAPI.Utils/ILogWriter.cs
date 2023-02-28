﻿namespace OrdersAPI.Utils
{
    public interface ILogWriter
    {
        void Log(string logMessage, TextWriter txtWriter);
        void LogWrite(string logMessage);
    }
}