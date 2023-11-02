using UnityEngine;

namespace ScriptableObjectArchitecture.Utils
{
    /// <summary>
    /// Logger singleton class used for logging only in UnityEditor or Development build
    /// By the usage of the Logger.Instance?.Log, we can avoid string creation in heap
    /// </summary>
    public class Logger
    {
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
        
        public void Log(string message, bool log = true)
        {
            if (!log)
            {
                return;
            }
            
            Debug.Log($"{LOGPrefix} {message}");
        }

        public void LogWarning(string message, bool log = true)
        {
            if (!log)
            {
                return;
            }
            
            Debug.LogWarning($"{LOGPrefix} {message}");
        }
        
        public void LogError(string message, bool log = true)
        {
            if (!log)
            {
                return;
            }
            
            Debug.LogError($"{LOGPrefix} {message}");
        }
    }
}