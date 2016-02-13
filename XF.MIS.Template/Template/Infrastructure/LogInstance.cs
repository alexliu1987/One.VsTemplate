using System;
using log4net;

namespace $safeprojectname$.Infrastructure
{
    public class LogInstance
    {
        /// <summary>
        /// Log4net实例
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 消息日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(object message, Exception exception = null)
        {
            if (exception != null)
                Log.Info(message, exception);
            else
                Log.Info(message);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(object message, Exception exception = null)
        {
            if (exception != null)
                Log.Warn(message, exception);
            else
                Log.Warn(message);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Debug(object message, Exception exception = null)
        {
            if (exception != null)
                Log.Debug(message, exception);
            else
                Log.Debug(message);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(object message, Exception exception = null)
        {
            if (exception != null)
                Log.Error(message, exception);
            else
                Log.Error(message);
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Fatal(object message, Exception exception = null)
        {
            if (exception != null)
                Log.Fatal(message, exception);
            else
                Log.Fatal(message);
        }
    }
}
