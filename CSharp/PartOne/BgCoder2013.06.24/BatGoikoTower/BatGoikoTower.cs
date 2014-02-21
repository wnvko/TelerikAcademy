namespace BatGoikoTower
{
    using System;

    class BatGoikoTower
    {
        static void Main()
        {
            int towerHeight = int.Parse(Console.ReadLine());
            int dotRows = -1;
            int dashRows = 0;

            for (int i = 0; i < towerHeight; i++)
            {
                string printToConsole = "";
                printToConsole = printToConsole + (new string('.', (towerHeight - 1 - i)));
                printToConsole = printToConsole + "/";
                if (dotRows == dashRows)
                {
                    printToConsole = printToConsole + (new string('-', (i * 2)));
                    dotRows = 0;
                    dashRows++;
                }
                else
                {
                    printToConsole = printToConsole + (new string('.', (i * 2)));
                    dotRows++;
                }
                printToConsole = printToConsole + "\\";
                printToConsole = printToConsole + (new string('.', (towerHeight - 1 - i)));

                Console.WriteLine(printToConsole);
            }
        }
    }
}
