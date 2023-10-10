using System.Text;

namespace Calculator.Services
{
    public class ConsoleLogger : ILogger
    {
        private const int _maxRetries = 5;
        private static readonly object _lock = new object();
        /// <summary>
        /// Logs a message to console
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true for success</returns>
        public async Task<bool> LogEntry(string message)
        {
            bool WorkDone = false;
            int retryCount = _maxRetries;

            while (!WorkDone && retryCount > 0)
            {
                // Try to get the file handle
                StringBuilder logConcatenatedWithLineFeed = new StringBuilder().AppendJoin(Environment.NewLine, message);

                try
                {
                    lock (_lock)
                    {
                        Console.Write(logConcatenatedWithLineFeed);
                        WorkDone = true;
                        break;
                    }
                }
                catch
                {
                    // TODO: Log exception to instrumentation and continue here
                }
                finally
                {
                    retryCount--;
                }
                await Task.Delay(20);

            }
            return WorkDone;
        }
    }
}