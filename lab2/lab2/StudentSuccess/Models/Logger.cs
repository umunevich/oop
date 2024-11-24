using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSuccess.Models {
    internal class Logger {
        private Logger() { }
        private static StreamWriter log = new StreamWriter("D:/Learning/University2/OOP/oop repo/lab2/lab2/Log.txt");
        private static readonly object _lock = new object();
        private static readonly Lazy<Logger> logger = new Lazy<Logger>(new Logger());

        public static Logger instance = logger.Value;

        public void Log(string operation, string message) {
            lock (_lock) {
                log.WriteLine($"{DateTime.Now.ToString()}: {operation}. {message}");
                log.Flush();
            }
        }
    }
}
