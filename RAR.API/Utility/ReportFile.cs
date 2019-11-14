using System;
using System.IO;

namespace RAR.API.Utility
{
    public static class ReportFile
    {
        private static readonly Object Locker = new Object();
        private static System.IO.StreamWriter _reportFile;
        public static void InitFile(string pathReportFile)
        {
            lock (Locker)
            {
                _reportFile = new StreamWriter(pathReportFile);
            }
        }

        public static void WriteLine(string line)
        {
            lock (Locker)
            {
                _reportFile.Write(line + Environment.NewLine);
            }
        }
        public static void Write(string line)
        {
            lock (Locker)
            {
                _reportFile.Write(line);
            }
        }

        public static void CloseFile()
        {
            lock (Locker)
            {
                _reportFile.Close();

            }

        }
    }
}
