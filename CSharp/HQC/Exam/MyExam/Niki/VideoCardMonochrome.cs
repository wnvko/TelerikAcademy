namespace Computers
{
    using System;
    using Contracts;

    public class VideoCardMonochrome : IVideoCard
    {
        public void Draw(string textToDraw)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(textToDraw);
            Console.ResetColor();
        }
    }
}