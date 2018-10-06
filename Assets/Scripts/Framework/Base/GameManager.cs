using System;
using UnityEngine;

namespace MorningStudio
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private const int DefaultDpi = 96;  // default windows dpi
        [SerializeField]
        private string m_LogHelperTypeName = "LFramework.DefaultLogHelper";

        protected override void Awake()
        {
            base.Awake();
            InitLogHelper();

            Utility.Converter.ScreenDpi = Screen.dpi;
            if (Utility.Converter.ScreenDpi <= 0)
            {
                Utility.Converter.ScreenDpi = DefaultDpi;
            }
        }

        private void InitLogHelper()
        {
            Type type = Utility.Assembly.GetType(m_LogHelperTypeName);
            Log.SetLogHelper(Activator.CreateInstance(type) as ILogHelper);
        }
    }
}