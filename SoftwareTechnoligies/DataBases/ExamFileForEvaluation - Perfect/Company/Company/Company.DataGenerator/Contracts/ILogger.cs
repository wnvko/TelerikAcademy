namespace Company.DataGenerator.Contracts
{
    public interface ILogger
    {
        void Log(string message);

        void LogLine(string message);
    }
}
