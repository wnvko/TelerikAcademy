namespace HangMan.EngineAndRenderer
{
    using System;
    using HangMan.Interfaces;

    /// <summary>
    ///  Implementation of a concrete renderer - in this case a console renderer. 
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteEmptyLine()
        {
            Console.WriteLine();
        }
    }
}
