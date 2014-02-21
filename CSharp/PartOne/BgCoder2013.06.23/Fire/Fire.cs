namespace Fire
{
    using System;

    class Fire
    {
        static void Main(string[] args)
        {
            int fireWidth = int.Parse(Console.ReadLine());
            for (int i = 0; i < fireWidth / 2; i++)
            {
                string output = "";
                output = output + (new string('.', (fireWidth / 2 - i - 1)));
                output = output + "#";
                output = output + (new string('.', i));
                output = output + (new string('.', i));
                output = output + "#";
                output = output + (new string('.', (fireWidth / 2 - i - 1)));

                Console.WriteLine(output);
            }

            for (int i = 0; i < fireWidth / 4; i++)
            {
                string output = "";
                output = output + (new string('.', i));
                output = output + "#";
                output = output + (new string('.', (fireWidth / 2 - i - 1)));
                output = output + (new string('.', (fireWidth / 2 - i - 1)));
                output = output + "#";
                output = output + (new string('.', i));

                Console.WriteLine(output);
            }

            Console.WriteLine(new string('-', fireWidth));

            for (int i = 0; i < fireWidth / 2; i++)
            {
                string output = "";
                output = output + (new string('.', i));
                output = output + (new string('\\', (fireWidth / 2 - i)));
                output = output + (new string('/', (fireWidth / 2 - i)));
                output = output + (new string('.', i));

                Console.WriteLine(output);
            }
        }
    }
}
