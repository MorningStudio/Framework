using System;
using UnityEngine;

namespace LFramework
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField]
        private string m_LogHelperTypeName = "LFramework.DefaultLogHelper";

        protected override void Awake()
        {
            base.Awake();
            InitLogHelper();
        }

        private void InitLogHelper()
        {
            Type type = Assembly.GetType(m_LogHelperTypeName);
            Log.SetLogHelper(Activator.CreateInstance(type) as ILogHelper);
        }
    }
}