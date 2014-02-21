namespace UKFlag
{
    using System;

    class UKFlag
    {
        static void Main(string[] args)
        {
            int sizeOfTheFlag = int.Parse(Console.ReadLine());

            string oneRowOfTheFlag = "";

            for (int i = 0; i < (sizeOfTheFlag / 2 + 1); i++)
            {
                if (i != (sizeOfTheFlag / 2))
                {
                    oneRowOfTheFlag = new string('.', i);
                    oneRowOfTheFlag = oneRowOfTheFlag + "\\";
                    oneRowOfTheFlag = oneRowOfTheFlag + (new string('.', ((sizeOfTheFlag / 2) - 1 - i)));
                    oneRowOfTheFlag = oneRowOfTheFlag + "|";
                    oneRowOfTheFlag = oneRowOfTheFlag + (new string('.', ((sizeOfTheFlag / 2) - 1 - i)));
                    oneRowOfTheFlag = oneRowOfTheFlag + "/";
                    oneRowOfTheFlag = oneRowOfTheFlag + new string('.', i);
                    Console.WriteLine(oneRowOfTheFlag);
                    oneRowOfTheFlag = "";
                }
                else
                {
                    oneRowOfTheFlag = oneRowOfTheFlag + (new string('-', (sizeOfTheFlag / 2)));
                    oneRowOfTheFlag = oneRowOfTheFlag + "*";
                    oneRowOfTheFlag = oneRowOfTheFlag + (new string('-', (sizeOfTheFlag / 2)));
                    Console.WriteLine(oneRowOfTheFlag);
                    oneRowOfTheFlag = "";
                }
            }
            for (int i = ((sizeOfTheFlag / 2) - 1); i >= 0; i--)
            {
                oneRowOfTheFlag = new string('.', i);
                oneRowOfTheFlag = oneRowOfTheFlag + "/";
                oneRowOfTheFlag = oneRowOfTheFlag + (new string('.', ((sizeOfTheFlag / 2) - 1 - i)));
                oneRowOfTheFlag = oneRowOfTheFlag + "|";
                oneRowOfTheFlag = oneRowOfTheFlag + (new string('.', ((sizeOfTheFlag / 2) - 1 - i)));
                oneRowOfTheFlag = oneRowOfTheFlag + "\\";
                oneRowOfTheFlag = oneRowOfTheFlag + new string('.', i);
                Console.WriteLine(oneRowOfTheFlag);
                oneRowOfTheFlag = "";
            }
        }
    }
}