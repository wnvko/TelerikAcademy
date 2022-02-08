namespace DiamondTrolls
{
    using System;

    class DiamondTrolls
    {
        static void Main()
        {
            //input
            int N = int.Parse(Console.ReadLine());

            //calculations
            string output = "";
            output = output + new string('.', (N - N / 2));
            output = output + new string('*', (N / 2));
            output = output + "*";
            output = output + new string('*', (N / 2));
            output = output + new string('.', (N - N / 2));
            Console.WriteLine(output);

            for (int row = 0; row < (N / 2); row++)
            {
                output = "";
                output = output + new string('.', (N / 2 - row));
                output = output + "*";
                output = output + new string('.', (N / 2 + row));
                output = output + "*";
                output = output + new string('.', (N / 2 + row));
                output = output + "*";
                output = output + new string('.', (N / 2 - row));
                Console.WriteLine(output);
            }

            output = "";
            output = output + new string('*', (N * 2 + 1));
            Console.WriteLine(output);

            for (int row = 0; row < (N - 1); row++)
            {
                output = "";
                output = output + new string('.', (row + 1));
                output = output + "*";
                output = output + new string('.', (N - 2 - row));
                output = output + "*";
                output = output + new string('.', (N - 2 - row));
                output = output + "*";
                output = output + new string('.', (row + 1));
                Console.WriteLine(output);
            }

            output = "";
            output = output + new string('.', (N));
            output = output + "*";
            output = output + new string('.', (N));
            Console.WriteLine(output);


            //ouput
        }
    }
}
