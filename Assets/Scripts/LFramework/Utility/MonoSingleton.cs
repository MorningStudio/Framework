using UnityEngine;

namespace MorningStudio
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                m_Instance = m_Instance ?? FindObjectOfType<T>();
                m_Instance = m_Instance ?? new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                return m_Instance;
            }
        }

        protected virtual void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this as T;
                if (gameObject.transform.parent == null)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            m_Instance = null;
        }
    }
}