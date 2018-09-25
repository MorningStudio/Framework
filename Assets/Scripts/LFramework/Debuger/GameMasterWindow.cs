using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace LFramework
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandInfo : Attribute
    {
        private string m_DisplayName;
        private object[] m_Parameters;

        public string DisplayName
        {
            get { return m_DisplayName; }
            set { m_DisplayName = value; }
        }

        public object[] Parameters
        {
            get { return m_Parameters; }
            set { m_Parameters = value; }
        }

        public CommandInfo(string displayName,object[] parameters)
        {
            m_DisplayName = displayName;
            m_Parameters = parameters;
        }
    }

    internal class CommandExcuteInfo
    {
        public string DisplayName;
        public MethodInfo Method;
        public object[] Parameters;

        public CommandExcuteInfo(string displayName,MethodInfo methodInfo,object[] parameters)
        {
            DisplayName = displayName;
            Method = methodInfo;
            Parameters = parameters;
        }
    }

    [Serializable]
    internal sealed class GameMasterWindow : ScrollableDebuggerWindowBase
    {
        [SerializeField]
        private string m_CmdExecutorTypeName = "";

        private Type m_CmdExecutorType;
        private List<CommandExcuteInfo> m_CMDExecuteInfos;
        private Dictionary<string, MethodInfo> m_MethodInfos;

        public override void Initialize(params object[] args)
        {
            base.Initialize(args);
            m_MethodInfos = new Dictionary<string, MethodInfo>();

            m_CmdExecutorType = Utility.Assembly.GetType(m_CmdExecutorTypeName);
            if(m_CmdExecutorType == null)
            {
                Log.Error("CmdExecutorType is null");
            }

            m_CMDExecuteInfos = new List<CommandExcuteInfo>();
            MethodInfo[] methodInfos =  m_CmdExecutorType.GetMethods();
            foreach(MethodInfo info in methodInfos)
            {
                CommandInfo cmdInfo = (CommandInfo)Attribute.GetCustomAttribute(info,typeof(CommandInfo),true);
                if(cmdInfo != null)
                {
                    m_CMDExecuteInfos.Add(new CommandExcuteInfo(cmdInfo.DisplayName,info,cmdInfo.Parameters));
                }
            }
        }

        protected override void OnDrawScrollableWindow()
        {
            foreach(CommandExcuteInfo info in m_CMDExecuteInfos)
            {
                if(GUILayout.Button(info.DisplayName,GUILayout.Height(40)))
                {
                    ExecuteCMD(info);
                }
            }
        }

        private void ExecuteCMD(CommandExcuteInfo info)
        {
            if (info.Method != null)
            {
                try
                {
                    info.Method.Invoke(null, info.Parameters);
                }
                catch (ArgumentException)
                {
                    Log.Error("Parameters not match");
                }
            }
        }
    }
}
