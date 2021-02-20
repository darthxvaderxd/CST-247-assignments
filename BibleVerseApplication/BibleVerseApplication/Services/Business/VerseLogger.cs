/**
 *        file: Utility/VerseLogger.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using BibleVerseApplication.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services
{
    public class VerseLogger : ILogger
    {
        private Logger logger;
        
        public VerseLogger(ILoggerService service)
        {
            this.logger = service.GetLogger();
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}