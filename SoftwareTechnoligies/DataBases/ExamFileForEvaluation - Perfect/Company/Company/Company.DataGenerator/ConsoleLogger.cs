namespace Company.DataGenerator
{
    using System;

    using Contracts;

    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }

        public void LogLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
