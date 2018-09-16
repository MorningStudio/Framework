using UnityEngine;

namespace LFramework
{
    public class DefaultLogHelper : ILogHelper
    {
        public void Log(LogLevel level, object message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    Debug.Log(string.Format("<color=#888888>{0}</color>", message.ToString()));
                    break;

                case LogLevel.Info:
                    Debug.Log(message.ToString());
                    break;

                case LogLevel.Warning:
                    Debug.LogWarning(message.ToString());
                    break;

                case LogLevel.Error:
                    Debug.LogError(message.ToString());
                    break;

                default:
                    throw new LException(message.ToString());
            }
        }
    }
}