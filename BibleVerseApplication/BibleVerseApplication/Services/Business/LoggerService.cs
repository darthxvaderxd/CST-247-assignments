/**
 *        file: Services/Business/LoggerService.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services
{
    public class LoggerService : ILoggerService
    {
        private static Logger logger = LogManager.GetLogger("bibleVerseLoggerRules");
        public Logger GetLogger()
        {
            return logger;
        }
    }
}