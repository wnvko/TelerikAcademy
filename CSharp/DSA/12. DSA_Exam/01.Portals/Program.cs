using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Portals
{
    class Program
    {
        private static int[,] Portals;
        private static Possition CurrentPos;
        private static int MaxPower = 0;

        static void Main(string[] args)
        {
            GetInput();
            int maxPower = 0;
            Go(CurrentPos.X, CurrentPos.Y, maxPower);
            Console.WriteLine(MaxPower);
        }

        private static void Go(int x, int y, int currentPower)
        {

            if (x < 0 || y < 0 || x >= Portals.GetLength(0) || y >= Portals.GetLength(1))
            {
                return;
            }

            if (Portals[x, y] <= 0)
            {
                // froooooogs or visited
                return;
            }

            int curCelVal = Portals[x, y];

            if (((x + curCelVal) < Portals.GetLength(0) && Portals[x + curCelVal, y] >= 0) ||
                ((x - curCelVal) >= 0 && Portals[x - curCelVal, y] >= 0) ||
                ((y + curCelVal) < Portals.GetLength(1) && Portals[x, y + curCelVal] >= 0) ||
                ((y - curCelVal) >= 0 && Portals[x, y - curCelVal] >= 0))
            {
                currentPower += curCelVal;

                if (currentPower > MaxPower)
                {
                    MaxPower = currentPower;
                }
            }

            if (currentPower > MaxPower)
            {
                MaxPower = currentPower;
            }

            // mark as visited
            Portals[x, y] = 0;

            // go get some power :)
            Go(x, y - curCelVal, currentPower); //left
            Go(x - curCelVal, y, currentPower); //up
            Go(x, y + curCelVal, currentPower); //right
            Go(x + curCelVal, y, currentPower); //down

            Portals[x, y] = curCelVal;
            currentPower -= curCelVal;
        }

        private static void GetInput()
        {
            string[] inputLocation = Console.ReadLine().Split(' ');
            CurrentPos = new Possition(int.Parse(inputLocation[0]), int.Parse(inputLocation[1]));

            string[] PortalsSizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(PortalsSizes[0]);
            int cols = int.Parse(PortalsSizes[1]);

            Portals = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    int currentPower = -1;
                    bool isNotFrogs = int.TryParse(currentRow[col], out currentPower);
                    if (!isNotFrogs)
                    {
                        Portals[row, col] = -1;
                        continue;
                    }

                    Portals[row, col] = currentPower;
                }
            }
        }
    }

    public class Possition
    {
        public Possition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
