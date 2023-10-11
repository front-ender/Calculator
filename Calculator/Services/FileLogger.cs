using System.Text;

namespace Calculator.Services
{
    public class FileLogger : ILogger
    {
        public FileInfo FileInfo { get; private set; }

        private const int _maxRetries = 5;
        private static readonly object _lock = new object();

        public FileLogger(FileInfo fileInfo) 
        {
            FileInfo = fileInfo;
        }

        /// <summary>
        /// Logs message to a file
        /// TODO : Consider IEnumerable in API for better performance https://stackoverflow.com/questions/39191791/c-sharp-async-within-an-action
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true for success</returns>
        public async Task<bool> LogEntry(string message)
        {
            bool WorkDone = false;
            int retryCount = _maxRetries;

            while (!WorkDone && retryCount>0)
            {
                StringBuilder logConcatenatedWithLineFeed = new StringBuilder(message).Append(Environment.NewLine);

                try
                {
                    lock (_lock)
                    {
                        using (FileStream file = new FileStream(FileInfo.FullName, FileMode.Append, FileAccess.Write))
                        using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                        {
                            writer.Write(logConcatenatedWithLineFeed);
                            WorkDone = true;
                            break;
                        }
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