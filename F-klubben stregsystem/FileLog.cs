using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace F_klubben_stregsystem
{
    class FileLog : ILogger
    {
        private string _fileName;

        public FileLog(string fileName)
        {
            _fileName = fileName;
        }
        public void LogTransaction(Transaction log)
        {
            string logString = log.ToString();
            if (File.Exists(_fileName))
            {
                using (StreamWriter file = new StreamWriter(_fileName, true))
                {
                    file.WriteLine(logString);
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(_fileName, true))
                {
                    file.WriteLine(logString);
                }
            }
        }
    }
}
