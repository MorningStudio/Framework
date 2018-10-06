using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MorningStudio
{
    public class EventManager : MonoSingleton<EventManager>
    {

        private Dictionary<int, EventHandler<GameEventArgs>> m_EventHandlers;
        private Queue<Event> m_Events;

        protected override void Awake()
        {
            base.Awake();
            m_EventHandlers = new Dictionary<int, EventHandler<GameEventArgs>>();
            m_Events = new Queue<Event>();
        }

        private void OnDestroy()
        {
            Clear();
            m_EventHandlers.Clear();
        }

        private void Update()
        {
            lock (m_Events)
            {
                while (m_Events.Count > 0)
                {
                    Event e = m_Events.Dequeue();
                    HandleEvent(e.Sender, e.EventArgs);
                }
            }
        }

        /// <summary>
        /// 获取事件数量。
        /// </summary>
        public int Count
        {
            get
            {
                return m_Events.Count;
            }
        }

        /// <summary>
        /// 清理事件。
        /// </summary>
        public void Clear()
        {
            lock (m_Events)
            {
                m_Events.Clear();
            }
        }

        public void AddListener(int id, EventHandler<GameEventArgs> handler)
        {
            if (handler == null)
            {
                Log.Error("Event handler is invalid.");
            }

            EventHandler<GameEventArgs> eventHandler = null;
            if (!m_EventHandlers.TryGetValue(id, out eventHandler) || eventHandler == null)
            {
                m_EventHandlers[id] = handler;
            }
            else
            {
                eventHandler += handler;
                m_EventHandlers[id] = eventHandler;
            }
        }

        public void RemoveListener(int id)
        {
            if(m_EventHandlers.ContainsKey(id))
            {
                m_EventHandlers.Remove(id);
            }
        }

        public void RemoveListener(int id, EventHandler<GameEventArgs> handler)
        {
            if (handler == null)
            {
                Log.Error("Event handler is invalid.");
            }

            if (m_EventHandlers.ContainsKey(id))
            {
                m_EventHandlers[id] -= handler;
            }
        }

        public bool HasListener(int id, EventHandler handler)
        {
            if (handler == null)
            {
                Log.Error("Event handler is invalid.");
            }

            EventHandler<GameEventArgs> handlers = null;
            if (!m_EventHandlers.TryGetValue(id, out handlers))
            {
                return false;
            }

            if (handlers == null)
            {
                return false;
            }

            foreach (EventHandler i in handlers.GetInvocationList())
            {
                if (i == handler)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 处理事件结点。
        /// </summary>
        /// <param name="sender">事件源。</param>
        /// <param name="e">事件参数。</param>
        private void HandleEvent(object sender, GameEventArgs e)
        {
            int eventId = e.Id;
            EventHandler<GameEventArgs> handlers = null;
            if (m_EventHandlers.TryGetValue(eventId, out handlers))
            {
                if (handlers != null)
                {
                    handlers(sender, e);
                }
            }
        }

        public void Dispatch(object sender, GameEventArgs e)
        {
            Event eventNode = new Event(sender, e);
            lock (m_Events)
            {
                m_Events.Enqueue(eventNode);
            }
        }

        public void DispatchNow(object sender, GameEventArgs e)
        {
            HandleEvent(sender,e);
        }
    }
}

