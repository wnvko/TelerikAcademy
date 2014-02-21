namespace PrintAllCardFromADeck
{
    using System;

    class PrintAllCardFromADeck
    {
        static void Main(string[] args)
        {
            /*
             * Write a program that prints all possible cards from a standard
             * deck of 52 cards (without jokers). The cards should be printed
             * with their English names. Use nested for loops and switch-case.
             */

            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            for (int j = 1; j <= 13; j++)
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2660"); break;
                                    case 2: Console.WriteLine("2\u2660"); break;
                                    case 3: Console.WriteLine("3\u2660"); break;
                                    case 4: Console.WriteLine("4\u2660"); break;
                                    case 5: Console.WriteLine("5\u2660"); break;
                                    case 6: Console.WriteLine("6\u2660"); break;
                                    case 7: Console.WriteLine("7\u2660"); break;
                                    case 8: Console.WriteLine("8\u2660"); break;
                                    case 9: Console.WriteLine("9\u2660"); break;
                                    case 10: Console.WriteLine("10\u2660"); break;
                                    case 11: Console.WriteLine("J\u2660"); break;
                                    case 12: Console.WriteLine("Q\u2660"); break;
                                    case 13: Console.WriteLine("K\u2660"); break;
                                }
                            }
                        }; break;
                    case 2:
                        {
                            for (int j = 1; j <= 13; j++)
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2665"); break;
                                    case 2: Console.WriteLine("2\u2665"); break;
                                    case 3: Console.WriteLine("3\u2665"); break;
                                    case 4: Console.WriteLine("4\u2665"); break;
                                    case 5: Console.WriteLine("5\u2665"); break;
                                    case 6: Console.WriteLine("6\u2665"); break;
                                    case 7: Console.WriteLine("7\u2665"); break;
                                    case 8: Console.WriteLine("8\u2665"); break;
                                    case 9: Console.WriteLine("9\u2665"); break;
                                    case 10: Console.WriteLine("10\u2665"); break;
                                    case 11: Console.WriteLine("J\u2665"); break;
                                    case 12: Console.WriteLine("Q\u2665"); break;
                                    case 13: Console.WriteLine("K\u2665"); break;
                                }
                            }
                        }; break;
                    case 3:
                        {
                            for (int j = 1; j <= 13; j++)
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2666"); break;
                                    case 2: Console.WriteLine("2\u2666"); break;
                                    case 3: Console.WriteLine("3\u2666"); break;
                                    case 4: Console.WriteLine("4\u2666"); break;
                                    case 5: Console.WriteLine("5\u2666"); break;
                                    case 6: Console.WriteLine("6\u2666"); break;
                                    case 7: Console.WriteLine("7\u2666"); break;
                                    case 8: Console.WriteLine("8\u2666"); break;
                                    case 9: Console.WriteLine("9\u2666"); break;
                                    case 10: Console.WriteLine("10\u2666"); break;
                                    case 11: Console.WriteLine("J\u2666"); break;
                                    case 12: Console.WriteLine("Q\u2666"); break;
                                    case 13: Console.WriteLine("K\u2666"); break;
                                }
                            }
                        }; break;
                    case 4:
                        {
                            for (int j = 1; j <= 13; j++)
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2663"); break;
                                    case 2: Console.WriteLine("2\u2663"); break;
                                    case 3: Console.WriteLine("3\u2663"); break;
                                    case 4: Console.WriteLine("4\u2663"); break;
                                    case 5: Console.WriteLine("5\u2663"); break;
                                    case 6: Console.WriteLine("6\u2663"); break;
                                    case 7: Console.WriteLine("7\u2663"); break;
                                    case 8: Console.WriteLine("8\u2663"); break;
                                    case 9: Console.WriteLine("9\u2663"); break;
                                    case 10: Console.WriteLine("10\u2663"); break;
                                    case 11: Console.WriteLine("J\u2663"); break;
                                    case 12: Console.WriteLine("Q\u2663"); break;
                                    case 13: Console.WriteLine("K\u2663"); break;
                                }
                            }
                        }; break;
                }
            }
        }
    }
}
