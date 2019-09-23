using System;
using System.Collections.Generic;

namespace mvcPet.Framework.Logging
{
    public partial interface ILoggingService
    {
        void Log(string message);
        void Error(string message);
        void Error(Exception ex);
        void Initialise(int maxLogSize);
        IList<LogEntry> ListLogFile();
        void Recycle();
        void ClearLogFiles();
    }
}
