using System;

namespace BookHomeworks
{
    class Chapter05Problem08
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете вашия избор:");
            Console.WriteLine("1. Цяло число");
            Console.WriteLine("2. Число");
            Console.WriteLine("3. Текст");
            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    {
                        Console.Write("Вашият избор е цяло число. Въведете цяло число: ");
                        int firstChoice = int.Parse(Console.ReadLine());
                        firstChoice++;
                        Console.WriteLine(firstChoice);
                    }
                    break;
                case 2:
                    {
                        Console.Write("Вашият избор е число. Въведете число: ");
                        double secondChoice = double.Parse(Console.ReadLine());
                        secondChoice++;
                        Console.WriteLine(secondChoice);
                    }
                    break;
                case 3:
                    {
                        Console.Write("Вашият избор е текст. Въведете текст: ");
                        string thirdChoice = Console.ReadLine();
                        Console.WriteLine(thirdChoice + "*");
                    }
                    break;
                default: break;
            }
        }
    }
}