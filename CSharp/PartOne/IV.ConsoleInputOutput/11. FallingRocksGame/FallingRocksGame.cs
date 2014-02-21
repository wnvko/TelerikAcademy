/*
 * Implement the "Falling Rocks" game in the text console. A small dwarf stays at
 * the bottom of the screen and can move left and right (by the arrows keys).
 * A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
 * Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density.
 * The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
 * Implement collision detection and scoring system.
 */

namespace FallingRocksGame
{
    using System;
    using System.Threading;

    class FallingRocksGame
    {
        //create new type for rocks. This will help trace rock easyer
        struct Rock
        {
            public int X;
            public int Y;
            public char typeOfRock;
            public ConsoleColor color;
        };

        //create random number
        static int RandomNumber(int inputValue)
        {
            Random randomNumber = new Random();
            int output = randomNumber.Next(0, inputValue);
            Thread.Sleep(10);
            return output;
        }

        //creat new rock method
        static Rock InitializeNewRock()
        {
            Rock newRock;
            newRock.X = RandomNumber(Console.WindowWidth - 1);
            newRock.Y = RandomNumber(Console.WindowHeight - 20);
            char rockSymbol = '*';
            int randomRock;
            ConsoleColor[] colorRock = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Green };
            randomRock = RandomNumber(11);
            switch (randomRock)
            {
                case 0: rockSymbol = '^'; break;
                case 1: rockSymbol = '@'; break;
                case 2: rockSymbol = '*'; break;
                case 3: rockSymbol = '&'; break;
                case 4: rockSymbol = '+'; break;
                case 5: rockSymbol = '%'; break;
                case 6: rockSymbol = '$'; break;
                case 7: rockSymbol = '#'; break;
                case 8: rockSymbol = '!'; break;
                case 9: rockSymbol = '.'; break;
                case 10: rockSymbol = ';'; break;
                case 11: rockSymbol = '-'; break;
            }
            newRock.typeOfRock = rockSymbol;
            newRock.color = colorRock[randomRock];
            return newRock;
        }

        //move rocks
        static Rock MoveRock(Rock rockToMove)
        {
            Console.SetCursorPosition(rockToMove.X, rockToMove.Y);
            Console.Write(" ");
            int newY = rockToMove.Y + 1;
            Rock newRock = rockToMove;
            if (newY > Console.WindowHeight - 1)
            {
                newRock = InitializeNewRock();
                return newRock;
            }
            else
            {
                Console.SetCursorPosition(rockToMove.X, newY);
                Console.ForegroundColor= rockToMove.color;
                Console.Write(rockToMove.typeOfRock);
                Console.ResetColor();
                newRock.Y++;
                return newRock;
            }
        }

        //writes the dwarf
        private static void WriteDwarf(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" (O) ");
        }

        //writes dead dwarf
        private static void WriteDeadDwarf(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" _o_ ");
        }

        static void Main(string[] args)
        {
            //set the gamefield parameters
            Console.WindowHeight = 25;
            Console.WindowWidth = 80;
            int maxCurrentRock = 10;
            DateTime startGameTime = DateTime.Now;
            int oldscore = 0;
            int score = 0;
            int gamespeed = 200;

            //put first ten rocks on the field
            Rock[] newRock = new Rock[100];
            for (int i = 0; i < maxCurrentRock; i++)
            {
                newRock[i] = InitializeNewRock();
            }

            //put the dwarf on the field
            int dwarfXPosition = (Console.WindowWidth / 2) - 2;
            int dwarfYPosition = Console.WindowHeight - 1;
            WriteDwarf(dwarfXPosition, dwarfYPosition);

            while (true)
            {
                //sets game speed
                Thread.Sleep(gamespeed);

                //shows current score
                Console.SetCursorPosition(0, 0);
                Console.Write("Score: {0:F0}", score);

                //check if dwarf is moving
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

                //checks for collision
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

                //start moving rocks
                for (int i = 0; i < maxCurrentRock; i++)
                {
                    newRock[i] = MoveRock(newRock[i]);
                }

                //calculates score and increas dificulty
                score = (int)(DateTime.Now - startGameTime).TotalSeconds;
                if ((score - oldscore) > 10)
                {
                    oldscore = score;
                    maxCurrentRock++;
                    newRock[maxCurrentRock] = InitializeNewRock();
                }
                if ((score - oldscore) > 25)
                {
                    gamespeed -= 20;
                }
            }
        }
    }
}
