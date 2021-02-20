/**
 *        file: Services/Business/ILoggerService.cs
 * description: Data service for BibleVerse
 *      author: Richard Williamson
 *       notes: none
 */

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleVerseApplication.Services
{
    public interface ILoggerService
    {
        Logger GetLogger();
    }
}
