namespace TheHorror
{
    using System;

    class TheHorror
    {
        static void Main()
        {
            //input
            string inputString = Console.ReadLine();
            inputString = inputString.Replace(("-"), (""));
            char[] inputChar = inputString.ToCharArray();
            long result = 0;

            //calculations
            long countOfNumbers = 0L;
            for (long i = 0L; i < inputString.Length; i++)
            {
                switch (inputChar[i])
                {
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                        {
                            if (i % 2 == 0)
                            {
                                result = result + inputChar[i] - '0';
                                countOfNumbers++;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            //output
            Console.WriteLine(countOfNumbers + " " + result);
        }
    }
}
