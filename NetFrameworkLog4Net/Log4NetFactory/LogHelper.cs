using log4net;
using log4net.Config;
using System;

namespace Log4NetFactory
{
    public class LogHelper
    {
        private static ILog _ilog;

        /// <summary>
        /// 初始化Log4Net
        /// </summary>
        static LogHelper()
        {
            XmlConfigurator.Configure(); 
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">日志信息</param>
        public static void write(string message)
        {
            writeLog(Type.GetType("System.Object"), LogMessageType.Info, message);
        }
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="logMessageType"></param>
        public static void write(Exception ex, LogMessageType logMessageType)
        {
            string message = String.Empty;
            if (!Object.Equals(ex, null)) {
                message = $"\n\t异常信息：{ex.Message}\n\t错误源：{ex.Source}\n\t堆栈信息：{ex.StackTrace}";
            }
            writeLog(Type.GetType("System.Object"), logMessageType, message);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="logMessageType"></param>
        private static void writeLog(Type type, LogMessageType logMessageType, string message = null)
        {
            _ilog = LogManager.GetLogger(type);
            switch (logMessageType)
            {
                case LogMessageType.Debug: _ilog.Debug(message); break;
                case LogMessageType.Info: _ilog.Info(message); break;
                case LogMessageType.Warn: _ilog.Warn(message); break;
                case LogMessageType.Error: _ilog.Error(message); break;
                case LogMessageType.Fatal: _ilog.Fatal(message); break;
                default: _ilog.Info(message); break;
            }
        }

        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogMessageType
        {
            /// <summary>
            /// 调试
            /// </summary>
            Debug,

            /// <summary>
            /// 信息
            /// </summary>
            Info,

            /// <summary>
            /// 警告
            /// </summary>
            Warn,

            /// <summary>
            /// 错误
            /// </summary>
            Error,

            /// <summary>
            /// 致命错误
            /// </summary>
            Fatal
        }
    }
}