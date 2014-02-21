using System;

namespace BookHomeworks
{
    class Chapter05Problem02
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете първото число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Въведете второто число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Въведете третото число: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            string result;
            int negativeCounter = 0;
            if (firstNumber < 0)
            {
                negativeCounter++;
            }
            if (secondNumber < 0)
            {
                negativeCounter++;
            }
            if (thirdNumber < 0)
            {
                negativeCounter++;
            }
            switch (negativeCounter)
            {
                case 0:
                case 2:
                    result = "Произведението е положително (+)"; break;
                case 1:
                case 3:
                    result = "Произведението е отрицателно (-)"; break;
                default:
                    result = "Нещо съм оплескал :("; break;
            }
            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                result = "Произведението е 0";
            }
            Console.WriteLine(result);
        }
    }
}