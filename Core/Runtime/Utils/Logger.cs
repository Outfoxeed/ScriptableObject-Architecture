using UnityEngine;

namespace ScriptableObjectArchitecture.Utils
{
    /// <summary>
    /// Logger singleton class used for logging only in UnityEditor or Development build
    /// By the usage of the Logger.Instance?.Log, we can avoid string creation
    /// </summary>
    public class Logger
    {
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
            
            Debug.Log(message);
        }
    }
}