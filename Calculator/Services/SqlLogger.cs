namespace Calculator.Services
{
    public class SqlLogger : ILogger
    {
        public async Task<bool> LogEntry(string message)
        {
            // TODO : Code removed for clarity
            await Task.Delay(20);
            return false;
        }
    }
}