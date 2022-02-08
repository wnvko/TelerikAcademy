namespace Computers
{
    using System;
    using Contracts;

    public class VideoCardColorful : IVideoCard
    {
        public void Draw(string textToDraw)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textToDraw);
            Console.ResetColor();
        }
    }
}