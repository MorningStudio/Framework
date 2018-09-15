namespace LFramework
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T m_Instance;
        private readonly static object m_Lock = new object();

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Lock)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new T();
                            m_Instance.Init();
                        }
                    }
                }
                return m_Instance;
            }
        }

        public static void DestroyInstance()
        {
            if (m_Instance != null)
            {
                m_Instance.Destroy();
                m_Instance = null;
            }
        }

        public virtual void Init()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}