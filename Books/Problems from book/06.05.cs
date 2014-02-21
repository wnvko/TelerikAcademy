using System;

namespace ConsoleApplication
{
    class Chapter06Problem05
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    if (j < 11 && j > 1)
                    {
                        switch (i)
                        {
                            case 1: Console.WriteLine("{0}\u2660", j); break;
                            case 2: Console.WriteLine("{0}\u2665", j); break;
                            case 3: Console.WriteLine("{0}\u2666", j); break;
                            case 4: Console.WriteLine("{0}\u2663", j); break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 1:
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2660"); break;
                                    case 11: Console.WriteLine("J\u2660"); break;
                                    case 12: Console.WriteLine("Q\u2660"); break;
                                    case 13: Console.WriteLine("K\u2660"); break;
                                }
                            }; break;
                            case 2:
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2665"); break;
                                    case 11: Console.WriteLine("J\u2665"); break;
                                    case 12: Console.WriteLine("Q\u2665"); break;
                                    case 13: Console.WriteLine("K\u2665"); break;
                                }
                            }; break;
                            case 3:
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2666"); break;
                                    case 11: Console.WriteLine("J\u2666"); break;
                                    case 12: Console.WriteLine("Q\u2666"); break;
                                    case 13: Console.WriteLine("K\u2666"); break;
                                }
                            }; break;
                            case 4:
                            {
                                switch (j)
                                {
                                    case 1: Console.WriteLine("A\u2663"); break;
                                    case 11: Console.WriteLine("J\u2663"); break;
                                    case 12: Console.WriteLine("Q\u2663"); break;
                                    case 13: Console.WriteLine("K\u2663"); break;
                                }
                            }; break;
                        }
                    }
                }
            }
        }
    }
}
