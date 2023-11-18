using System;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture.Utils
{
    /// <summary>
    /// Logger singleton class used for logging only in Development build or in Editor when wanted
    /// By the usage of the Logger.Instance?.Log, we can avoid string creation in heap
    /// </summary>
    public class Logger
    {
        public enum LogType
        {
            Default,
            Warning,
            Error
        }
        private const string LOGPrefix = "[SO ARCH]";
        public static Logger Instance
        {
            get
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                if (_instance is null)
                {
                    _instance = new Logger();
                }

                return _instance;
#else
                return null;
#endif
            }
        }

        private static Logger _instance;

        public void Log(LogType logType, string message)
        {
            switch (logType)
            {
                case LogType.Default:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }
        }
        
        public void Log(ScriptableObjectArchitectureObject source, string message) =>
            Log(source, LogType.Default, message);
        public void Log(ScriptableObjectArchitectureObject source, LogType logType, string message)
        {
            if (!ShallLog(source))
            {
                return;
            }

            Log(logType, $"{LOGPrefix} {message}");
        }

        private bool ShallLog(ScriptableObjectArchitectureObject logSource)
        {
#if UNITY_EDITOR
            return logSource.DebugMode;
#elif DEVELOPMENT_BUILD
            return true;
#else
            throw new Exception("Shall not have reached this code if the we are not in Unity Editor or Development Build");
#endif
        }
    }
}