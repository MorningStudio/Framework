﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MorningStudio
{
    public static class Log
    {
        private static ILogHelper m_LogHelper = null;

        /// <summary>
        /// 设置日志辅助器。
        /// </summary>
        /// <param name="logHelper">要设置的日志辅助器。</param>
        public static void SetLogHelper(ILogHelper logHelper)
        {
            m_LogHelper = logHelper;
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="message">日志内容。</param>
        [Conditional("DEBUG")]
        public static void Debug(object message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="message">日志内容。</param>
        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        [Conditional("DEBUG")]
        public static void Debug(string format, object arg0)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, string.Format(format, arg0));
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        [Conditional("DEBUG")]
        public static void Debug(string format, object arg0, object arg1)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, string.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        /// <param name="arg2">日志参数 2。</param>
        [Conditional("DEBUG")]
        public static void Debug(string format, object arg0, object arg1, object arg2)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录调试级别日志，仅在带有 DEBUG 预编译选项时产生。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="args">日志参数。</param>
        [Conditional("DEBUG")]
        public static void Debug(string format, params object[] args)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Debug, string.Format(format, args));
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(object message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, message);
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, message);
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        public static void Info(string format, object arg0)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, string.Format(format, arg0));
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        public static void Info(string format, object arg0, object arg1)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, string.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        /// <param name="arg2">日志参数 2。</param>
        public static void Info(string format, object arg0, object arg1, object arg2)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印信息级别日志，用于记录程序正常运行日志信息。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="args">日志参数。</param>
        public static void Info(string format, params object[] args)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Info, string.Format(format, args));
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Warning(object message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Warning(string message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        public static void Warning(string format, object arg0)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, string.Format(format, arg0));
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        public static void Warning(string format, object arg0, object arg1)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, string.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        /// <param name="arg2">日志参数 2。</param>
        public static void Warning(string format, object arg0, object arg1, object arg2)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="args">日志参数。</param>
        public static void Warning(string format, params object[] args)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Warning, string.Format(format, args));
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Error(object message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, message);
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Error(string message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, message);
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        public static void Error(string format, object arg0)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, string.Format(format, arg0));
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        public static void Error(string format, object arg0, object arg1)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, string.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        /// <param name="arg2">日志参数 2。</param>
        public static void Error(string format, object arg0, object arg1, object arg2)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="args">日志参数。</param>
        public static void Error(string format, params object[] args)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Error, string.Format(format, args));
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Fatal(object message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, message);
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Fatal(string message)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, message);
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        public static void Fatal(string format, object arg0)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, string.Format(format, arg0));
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        public static void Fatal(string format, object arg0, object arg1)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, string.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="arg0">日志参数 0。</param>
        /// <param name="arg1">日志参数 1。</param>
        /// <param name="arg2">日志参数 2。</param>
        public static void Fatal(string format, object arg0, object arg1, object arg2)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架。
        /// </summary>
        /// <param name="format">日志格式。</param>
        /// <param name="args">日志参数。</param>
        public static void Fatal(string format, params object[] args)
        {
            if (m_LogHelper == null)
            {
                return;
            }

            m_LogHelper.Log(LogLevel.Fatal, string.Format(format, args));
        }
    }
}
