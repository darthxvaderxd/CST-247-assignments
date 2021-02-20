/**
 *        file: Utility/ILogger.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleVerseApplication.Services
{
    public interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}
