namespace NumeroUno
{
    using System;

    class ThreeSixNine
    {
        static void Main()
        {
            //input
            long A = long.Parse(Console.ReadLine());
            long B = long.Parse(Console.ReadLine());
            long C = long.Parse(Console.ReadLine());

            long R = 0L;
            long reminder = 0L;

            //check
            switch (B)
            {
                case 3:
                    {
                        R = A + C;
                        break;
                    }
                case 6:
                    {
                        R = A * C;
                        break;
                    }
                case 9:
                    {
                        R = A % C;
                        break;
                    }
            }

            if (R % 3 == 0)
            {
                reminder = R / 3;
            }
            else
            {
                reminder = R % 3;
            }


            //ouput
            Console.WriteLine(reminder);
            Console.WriteLine(R);
        }
    }
}
