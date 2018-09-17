using System;

namespace LFramework
{
    public abstract class GameEventArgs : EventArgs
    {
        /// <summary>
        /// 获取类型编号。
        /// </summary>
        public abstract int Id
        {
            get;
        }
    }
}