namespace FallingRocksGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class FallingRocks
    {
        public const int WindowHeight = 25;
        public const int WindowWidth = 80;

        private static ConsoleColor[] colorRock = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Green };
        private static int maxCurrentRock = 10;
        private static DateTime startGameTime = DateTime.Now;

        private static int RandomNumber(int inputValue)
        {
            Random randomNumber = new Random();
            int output = randomNumber.Next(0, inputValue);
            Thread.Sleep(10);
            return output;
        }

        private static Rock InitializeNewRock()
        {
            Rock newRock;

            newRock.X = RandomNumber(Console.WindowWidth - 1);
            newRock.Y = RandomNumber(Console.WindowHeight - 20);

            char rockSymbol = '*';
            int randomRock = RandomNumber(11);
            switch (randomRock)
            {
                case 0:
                    rockSymbol = '^';
                    break;
                case 1:
                    rockSymbol = '@';
                    break;
                case 2:
                    rockSymbol = '*';
                    break;
                case 3:
                    rockSymbol = '&';
                    break;
                case 4:
                    rockSymbol = '+';
                    break;
                case 5:
                    rockSymbol = '%';
                    break;
                case 6:
                    rockSymbol = '$';
                    break;
                case 7:
                    rockSymbol = '#';
                    break;
                case 8:
                    rockSymbol = '!';
                    break;
                case 9:
                    rockSymbol = '.';
                    break;
                case 10:
                    rockSymbol = ';';
                    break;
                case 11:
                    rockSymbol = '-';
                    break;
            }

            newRock.TypeOfRock = rockSymbol;
            newRock.Color = colorRock[randomRock];
            return newRock;
        }

        private static Rock MoveRock(Rock rockToMove)
        {
            Console.SetCursorPosition(rockToMove.X, rockToMove.Y);
            Console.Write(" ");

            int newY = rockToMove.Y + 1;

            if (newY > Console.WindowHeight - 1)
            {
                rockToMove = FallingRocks.InitializeNewRock();
            }
            else
            {
                Console.SetCursorPosition(rockToMove.X, newY);
                Console.ForegroundColor = rockToMove.Color;
                Console.Write(rockToMove.TypeOfRock);
                Console.ResetColor();
                rockToMove.Y++;
            }

            return rockToMove;
        }

        private static void WriteDwarf(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" (O) ");
        }

        private static void WriteDeadDwarf(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" _o_ ");
        }

        private static void Main(string[] args)
        {
            Console.WindowHeight = FallingRocks.WindowHeight;
            Console.WindowWidth = FallingRocks.WindowWidth;
            int oldscore = 0;
            int score = 0;
            int gamespeed = 200;

            List<Rock> newRock = new List<Rock>();

            for (int i = 0; i < FallingRocks.maxCurrentRock; i++)
            {
                newRock.Add(FallingRocks.InitializeNewRock());
            }

            int dwarfXPosition = (Console.WindowWidth / 2) - 2;
            int dwarfYPosition = Console.WindowHeight - 1;
            WriteDwarf(dwarfXPosition, dwarfYPosition);

            while (true)
            {
                Thread.Sleep(gamespeed);

                Console.SetCursorPosition(0, 0);
                Console.Write("Score: {0:F0}", score);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarfXPosition + 6 < Console.WindowWidth)
                        {
                            dwarfXPosition++;
                            WriteDwarf(dwarfXPosition, dwarfYPosition);
                        }
                    }

                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarfXPosition > 0)
                        {
                            dwarfXPosition--;
                            WriteDwarf(dwarfXPosition, dwarfYPosition);
                        }
                    }
                }

                for (int i = 0; i < maxCurrentRock; i++)
                {
                    if (newRock[i].Y == Console.WindowHeight - 1)
                    {
                        if ((newRock[i].X > dwarfXPosition) && (newRock[i].X < (dwarfXPosition + 4)))
                        {
                            WriteDeadDwarf(dwarfXPosition, dwarfYPosition);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("\aGame over");
                            Thread.Sleep(250);
                            Console.WriteLine("\aYour score is {0}", score);
                            Console.ReadKey();
                            return;
                        }
                    }
                }

                for (int i = 0; i < maxCurrentRock; i++)
                {
                    newRock[i] = MoveRock(newRock[i]);
                }

                score = (int)(DateTime.Now - startGameTime).TotalSeconds;
                if ((score - oldscore) > 10)
                {
                    oldscore = score;
                    maxCurrentRock++;
                    newRock.Add(InitializeNewRock());
                }

                if ((score - oldscore) > 25)
                {
                    gamespeed -= 20;
                }
            }
        }

        private struct Rock
        {
            public int X;
            public int Y;
            public char TypeOfRock;
            public ConsoleColor Color;
        }
    }
}
