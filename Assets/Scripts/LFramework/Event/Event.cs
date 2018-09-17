using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFramework
{
    /// <summary>
    /// 事件结点。
    /// </summary>
    internal sealed class Event
    {
        private readonly object m_Sender;
        private readonly GameEventArgs m_EventArgs;

        public Event(object sender, GameEventArgs e)
        {
            m_Sender = sender;
            m_EventArgs = e;
        }

        public object Sender
        {
            get
            {
                return m_Sender;
            }
        }

        public GameEventArgs EventArgs
        {
            get
            {
                return m_EventArgs;
            }
        }
    }
}
