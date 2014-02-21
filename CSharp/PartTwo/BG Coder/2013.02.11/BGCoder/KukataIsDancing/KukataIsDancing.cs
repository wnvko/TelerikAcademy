/*
 * start 22:25
 * end 23:04 @ 100 pts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukataIsDancing
{
    class KukataIsDancing
    {
        public struct Possition
        {
            public int x;
            public int y;
            public string dir;
        }

        public static void FindBoxColor(string input)
        {
            Possition actual = new Possition();
            actual.x = 1;
            actual.y = 1;
            actual.dir = "xPos";

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == 'L')
                {
                    actual = TurnLeft(actual);
                }
                else if (input[i] == 'R')
                {
                    actual = TurnRight(actual);
                }
                else
                {
                    actual = GoAhead(actual);
                }
            }

            Console.WriteLine(CheckColor(actual));
        }

        public static Possition TurnLeft(Possition input)
        {
            if (input.dir == "xPos")
            {
                input.dir = "yPos";
                return input;
            }
            else if (input.dir == "xNeg")
            {
                input.dir = "yNeg";
                return input;
            }
            else if (input.dir == "yPos")
            {
                input.dir = "xNeg";
                return input;
            }
            else
            {
                input.dir = "xPos";
                return input;
            }
        }

        public static Possition TurnRight(Possition input)
        {
            if (input.dir == "xPos")
            {
                input.dir = "yNeg";
                return input;
            }
            else if (input.dir == "xNeg")
            {
                input.dir = "yPos";
                return input;
            }
            else if (input.dir == "yPos")
            {
                input.dir = "xPos";
                return input;
            }
            else
            {
                input.dir = "xNeg";
                return input;
            }
        }

        public static Possition GoAhead(Possition input)
        {
            if (input.dir == "xPos")
            {
                input.x++;
            }
            else if (input.dir == "xNeg")
            {
                input.x--;
            }
            else if (input.dir == "yPos")
            {
                input.y++;
            }
            else
            {
                input.y--;
            }

            if (input.x > 2)
            {
                input.x = 0;
            }
            if (input.x < 0)
            {
                input.x = 2;
            }
            if (input.y > 2)
            {
                input.y = 0;
            }
            if (input.y < 0)
            {
                input.y = 2;
            }

            return input;
        }

        public static String CheckColor(Possition input)
        {
            if (input.x == 1 && input.y == 1)
            {
                return "GREEN";
            }
            else if ((input.x == 0 && input.y == 0) ||
                     (input.x == 2 && input.y == 0) ||
                     (input.x == 0 && input.y == 2) ||
                     (input.x == 2 && input.y == 2))
            {
                return "RED";
            }
            else
            {
                return "BLUE";
            }
        }

        static void Main(string[] args)
        {
            int dances = int.Parse(Console.ReadLine());
            string[] moves = new string[dances];

            for (int i = 0; i < dances; i++)
            {
                moves[i] = Console.ReadLine();
            }

            for (int i = 0; i < dances; i++)
            {
                FindBoxColor(moves[i]);
            }
        }
    }
}
