namespace Calculator.Services
{
    public interface ILogger
    {
        Task<bool> LogEntry(string message);
    }
}