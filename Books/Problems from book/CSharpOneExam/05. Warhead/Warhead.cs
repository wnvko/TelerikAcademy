namespace Warhead
{
    using System;

    class Warhead
    {

        static void Main()
        {

            //input
            int[,] numbers = new int[16, 16];
            string input = "";

            for (int rows = 0; rows < 16; rows++)
            {
                input = Console.ReadLine();

                for (int columns = 0; columns < 16; columns++)
                {
                    char[] inputAsChat = input.ToCharArray();
                    numbers[rows, columns] = inputAsChat[columns] - '0';
                }
            }

            //calc
            int bombsLeft = 0;
            int bombsRight = 0;
            for (int row = 0; row < 14; row++)
            {
                for (int columns = 0; columns < 8; columns++)
                {
                    if (numbers[row, columns] == 1)
                    {
                        if (numbers[row + 1, columns] == 1 &&
                            numbers[row + 2, columns] == 1 &&
                            numbers[row, columns + 1] == 1 &&
                            numbers[row + 1, columns + 1] == 0 &&
                            numbers[row + 2, columns + 1] == 1 &&
                            numbers[row, columns + 2] == 1 &&
                            numbers[row + 1, columns + 2] == 1 &&
                            numbers[row + 2, columns + 2] == 1
                            )
                        {
                            bombsLeft++;
                        }
                    }
                }
                for (int columns = 15; columns > 7; columns--)
                {
                    if (numbers[row, columns] == 1)
                    {
                        if (numbers[row + 1, columns] == 1 &&
                            numbers[row + 2, columns] == 1 &&
                            numbers[row, columns - 1] == 1 &&
                            numbers[row + 1, columns - 1] == 0 &&
                            numbers[row + 2, columns - 1] == 1 &&
                            numbers[row, columns - 2] == 1 &&
                            numbers[row + 1, columns - 2] == 1 &&
                            numbers[row + 2, columns - 2] == 1
                            )
                        {
                            bombsRight++;
                        }
                    }
                }
            }

            string output = "";

            while (input != "cut")
            {
                input = Console.ReadLine();
                if (input == "hover")
                {
                    int row = int.Parse(Console.ReadLine());
                    int column = int.Parse(Console.ReadLine());
                    if (numbers[row, column] == 1)
                    {
                        output = output + "*\n";
                    }
                    else
                    {
                        output = output + "-\n";
                    }
                }

                if (input == "operate")
                {
                    int row = int.Parse(Console.ReadLine());
                    int column = int.Parse(Console.ReadLine());
                    if (numbers[row, column] == 1)
                    {
                        output = output + "missed\n";
                        output = output + (bombsRight + bombsLeft) + "\n";
                        output = output + "BOOM";
                        break;
                    }
                    else
                    {
                        if (column > 0 && column < 8 && row > 0 && row < 15)
                        {
                            if (numbers[row - 1, column - 1] == 1 &&
                             numbers[row - 1, column] == 1 &&
                             numbers[row - 1, column + 1] == 1 &&
                             numbers[row, column - 1] == 1 &&
                             numbers[row, column + 1] == 1 &&
                             numbers[row + 1, column - 1] == 1 &&
                             numbers[row + 1, column] == 1 &&
                             numbers[row + 1, column + 1] == 1
                             )
                            {
                                bombsLeft--;
                                numbers[row - 1, column - 1] = 0;
                                numbers[row - 1, column] = 0;
                                numbers[row - 1, column + 1] = 0;
                                numbers[row, column - 1] = 0;
                                numbers[row, column + 1] = 0;
                                numbers[row + 1, column - 1] = 0;
                                numbers[row + 1, column] = 0;
                                numbers[row + 1, column + 1] = 0;
                            }
                        }

                        if (column > 7 && column < 15 && row > 0 && row < 15)
                        {
                            if (numbers[row - 1, column - 1] == 1 &&
                             numbers[row - 1, column] == 1 &&
                             numbers[row - 1, column + 1] == 1 &&
                             numbers[row, column - 1] == 1 &&
                             numbers[row, column + 1] == 1 &&
                             numbers[row + 1, column - 1] == 1 &&
                             numbers[row + 1, column] == 1 &&
                             numbers[row + 1, column + 1] == 1
                             )
                            {
                                bombsRight--;
                                numbers[row - 1, column - 1] = 0;
                                numbers[row - 1, column] = 0;
                                numbers[row - 1, column + 1] = 0;
                                numbers[row, column - 1] = 0;
                                numbers[row, column + 1] = 0;
                                numbers[row + 1, column - 1] = 0;
                                numbers[row + 1, column] = 0;
                                numbers[row + 1, column + 1] = 0;
                            }
                        }
                    }
                }
            }

            if (input == "cut")
            {
                input = Console.ReadLine();
                if (input == "red")
                {
                    if (bombsLeft == 0)
                    {
                        output = output + bombsRight + "\ndisarmed";
                    }
                    else
                    {
                        output = output + bombsLeft + "\n";
                        output = output + "BOOM";
                    }
                }

                if (input == "blue")
                {
                    if (bombsRight == 0)
                    {
                        output = output + bombsLeft + "\ndisarmed";
                    }
                    else
                    {
                        output = output + bombsRight + "\n";
                        output = output + "BOOM";
                    }
                }
            }


            //output
            Console.WriteLine(output);
        }
    }
}