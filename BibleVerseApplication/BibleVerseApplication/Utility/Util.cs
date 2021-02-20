/**
 *        file: Utility/Util.cs
 * description: Utility class to be used for common things that do not fit elsewhere
 *      author: Richard Williamson
 *       notes: none
 */

using BibleVerseApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Utility
{
    public static class Util
    {
        // this allows us to not have to retype the connection string multiple times
        public const string DB_CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerseRW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static VerseLogger vl = new VerseLogger(new LoggerService());

        public static ILogger GetLogger()
        {
            return vl;
        }
    }
}