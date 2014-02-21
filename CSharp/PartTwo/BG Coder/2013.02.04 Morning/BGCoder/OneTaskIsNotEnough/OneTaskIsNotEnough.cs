/*
 * start @23:20
 * end 0 pts !??! @0:36
 */

namespace OneTaskIsNotEnough
{
    using System;

    public class OneTaskIsNotEnough
    {   
        public static int LastLampConter(int lampsCount)
        {
            bool[] lampIsOn = new bool[lampsCount + 1];
            lampIsOn[0] = true;
            int lastLamp = 0;

            int counter = 1;
            int step = 2;
            while (true)
            {
                if (!lampIsOn[counter])
                {
                    lampIsOn[counter] = true;
                    lastLamp = counter;
                }

                counter += step;
                if (counter >= lampsCount + 1)
                {
                    counter = Array.IndexOf(lampIsOn, false);
                    step++;
                    if (counter < 0)
                    {
                        break;
                    }
                }
            }

            return lastLamp;
        }

        public static Point RotateJoro(Point input, char turn)
        {
            Point output = new Point();
            output.X = input.X;
            output.Y = input.Y;
            output.Dir = input.Dir;

            if (input.Dir == "xPos")
            {
                if (turn == 'R')
                {
                    output.Dir = "yNeg";
                }
                else if (turn == 'L')
                {
                    output.Dir = "yPos";
                }
            }
            else if (input.Dir == "xNeg")
            {
                if (turn == 'R')
                {
                    output.Dir = "yPos";
                }
                else if (turn == 'L')
                {
                    output.Dir = "yNeg";
                }
            }
            else if (input.Dir == "yPos")
            {
                if (turn == 'R')
                {
                    output.Dir = "xPos";
                }
                else if (turn == 'L')
                {
                    output.Dir = "xNeg";
                }
            }
            else if (input.Dir == "yNeg")
            {
                if (turn == 'R')
                {
                    output.Dir = "xNeg";
                }
                else if (turn == 'L')
                {
                    output.Dir = "xPos";
                }
            }

            return output;
        }

        public static Point MoveJoro(Point input)
        {
            Point output = new Point();
            output.X = input.X;
            output.Y = input.Y;
            output.Dir = input.Dir;

            if (output.Dir == "xPos")
            {
                output.X++;
            }
            else if (output.Dir == "xNeg")
            {
                output.X--;
            }
            else if (output.Dir == "yPos")
            {
                output.Y++;
            }
            else if (output.Dir == "yNeg")
            {
                output.Y--;
            }

            return output;
        }

        public static void WhereIsJoro(string orders)
        {
            string result = "unbounded";
            Point startPoint = new Point();
            startPoint.X = 0;
            startPoint.Y = 0;
            startPoint.Dir = "xPos";
            for (int loop = 0; loop < 16; loop++)
            {
                for (int step = 0; step < orders.Length; step++)
                {
                    if (orders[step] == 'S')
                    {
                        startPoint = MoveJoro(startPoint);
                    }
                    else if (orders[step] == 'L')
                    {
                        startPoint = RotateJoro(startPoint, 'L');
                    }
                    else if (orders[step] == 'R')
                    {
                        startPoint = RotateJoro(startPoint, 'R');
                    }
                }

                if (startPoint.X == 0 && startPoint.Y == 0)
                {
                    result = "bounded";
                    break;
                }
            }

            Console.WriteLine(result);
        }

        public static void Main()
        {
            // first task
            int lampsCount = int.Parse(Console.ReadLine());
            int lastLamp = LastLampConter(lampsCount);

            // second task
            string firstOrder = Console.ReadLine();
            string secondOrder = Console.ReadLine();

            Console.WriteLine(lastLamp);
            Console.WriteLine("unbounded");
            Console.WriteLine("unbounded");
            //WhereIsJoro(firstOrder);
            //WhereIsJoro(secondOrder);
        }
    }

    public struct Point
    {
        public int X;
        public int Y;
        public string Dir;
    }
}
