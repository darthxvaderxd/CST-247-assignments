using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1Part3.Utility
{
    public class MyLogger1 : ILogger
    {
        private static MyLogger1 instance;
        private static Logger logger;

        private MyLogger1() { }

        private Logger GetLogger()
        {
            if (logger == null)
            {
                logger = LogManager.GetLogger("myAppLoggerRules");
            }
            return logger;
        }

        public void Debug(string msg)
        {
            GetLogger().Debug(msg);
        }

        public void Error(string msg)
        {
            GetLogger().Error(msg);
        }

        public void Info(string msg)
        {
            GetLogger().Info(msg);
        }

        public void Warning(string msg)
        {
            GetLogger().Warn(msg);
        }

        public static MyLogger1 GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger1();
            }

            return instance;
        }
    }
}