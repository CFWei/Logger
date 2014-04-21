using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    interface IRecorder
    {
         void Info(String message);
         void Warn(String message);
         void Error(String message);
         void Debug(String message);

    }
}
