using System.Diagnostics;


namespace Ranking {
    internal class Logger {
        private Logger() { }
        private static readonly object _lock = new object();
        private static readonly Lazy<Logger> logger = new Lazy<Logger>(new Logger());

        public static Logger instance = logger.Value;

        public void Log(string message) {
            lock (_lock) {
                Debug.WriteLine($"{DateTime.Now.ToString()}: {message}");
           }
        }
    }
}
