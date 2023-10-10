namespace Calculator.Services
{
    /// TODO: Consider using  Action<string> logConsoleAction = m => Console.WriteLine(m);
    public class ConsoleLogger : ILogger
    {
        public async Task<bool> LogEntry(string message)
        {
            await Task.Delay(20);
            return false;
        }
    }
}