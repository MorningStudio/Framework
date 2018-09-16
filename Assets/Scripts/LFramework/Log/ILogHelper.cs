using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFramework
{ 
    public interface ILogHelper
    {
        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">日志等级。</param>
        /// <param name="message">日志内容。</param>
        void Log(LogLevel level, object message);
    }
}
