using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity1Part3.Utility
{
    interface ILogger
    {
        void Debug(string msg);
        void Info(string msg);
        void Warning(string msg);
        void Error(string msg);
    }
}
