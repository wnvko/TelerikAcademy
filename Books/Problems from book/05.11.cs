using System;

namespace BookHomeworks
{
    class Chapter05Problem11
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете число от 1 до 999: ");
            int number = int.Parse(Console.ReadLine());
            if (number > 999 || number < 1)
            {
                number = -1; //ще нулира всички изрази и ще изведе грешка на края
            }
            int number100 = number / 100;
            int number10 = (number - 100 * number100) / 10;
            int number1 = number - number100 * 100 - number10 * 10;
            string sayNumber100 ="";
            string sayNumber10 ="";
            string sayNumber1 ="";
            switch (number100)
            {
                case 0: sayNumber100 = ""; break;
                case 1: sayNumber100 = "сто"; break;
                case 2: sayNumber100 = "двеста"; break;
                case 3: sayNumber100 = "триста"; break;
                case 4: sayNumber100 = "четиристотин"; break;
                case 5: sayNumber100 = "петстотин"; break;
                case 6: sayNumber100 = "шестстотин"; break;
                case 7: sayNumber100 = "седемстотин"; break;
                case 8: sayNumber100 = "осемстотин"; break;
                case 9: sayNumber100 = "деветстотин"; break;
                default: break;
            }
            switch (number10)
            {
                case 0: sayNumber10 = ""; break;
                case 1:
                    {
                        switch (number1)
                        {
                            case 0: sayNumber10 = "десет"; break;
                            case 1: sayNumber10 = "единадесет"; break;
                            case 2: sayNumber10 = "дванадесет"; break;
                            case 3: sayNumber10 = "тринадесет"; break;
                            case 4: sayNumber10 = "четиринадесет"; break;
                            case 5: sayNumber10 = "петнадесет"; break;
                            case 6: sayNumber10 = "шестнадесет"; break;
                            case 7: sayNumber10 = "седемнадесет"; break;
                            case 8: sayNumber10 = "осемнадесет"; break;
                            case 9: sayNumber10 = "деветнадесет"; break;
                            default: break;
                        }
                    } break;
                case 2: sayNumber10 = "двадесет"; break;
                case 3: sayNumber10 = "тридесет"; break;
                case 4: sayNumber10 = "четиридесет"; break;
                case 5: sayNumber10 = "петдесет"; break;
                case 6: sayNumber10 = "шестедест"; break;
                case 7: sayNumber10 = "седемдесет"; break;
                case 8: sayNumber10 = "осемдесет"; break;
                case 9: sayNumber10 = "деветдесет"; break;
                default: break;
            }
             switch (number1)
            {
                case 0: sayNumber1 = ""; break;
                case 1: sayNumber1 = "едно"; break;
                case 2: sayNumber1 = "две"; break;
                case 3: sayNumber1 = "три"; break;
                case 4: sayNumber1 = "четири"; break;
                case 5: sayNumber1 = "пет"; break;
                case 6: sayNumber1 = "шест"; break;
                case 7: sayNumber1 = "седем"; break;
                case 8: sayNumber1 = "осем"; break;
                case 9: sayNumber1 = "девет"; break;
                default: break;
            }
             if (number10 == 1)
             {
                 number1 = 0;
             }
            if (number100 > 0)
            {
                if (number10 > 0)
                {
                    if (number1 > 0)
                    {
                        Console.WriteLine("С думи: " + sayNumber100 + " " + sayNumber10 + " и " + sayNumber1);
                    }
                    else
                    {
                        Console.WriteLine("С думи: " + " " + sayNumber100 + " и " + sayNumber10);
                    }
                }
                else
                {
                    if (number1 > 0)
                    {
                        Console.WriteLine("С думи: " + sayNumber100 + " и " + sayNumber1);
                    }
                    else
                    {
                        Console.WriteLine("С думи: " + sayNumber100);
                    }
                }
            }
            else
            {
                if (number10 > 0)
                {
                    if (number1 > 0)
                    {
                        Console.WriteLine("С думи: " + sayNumber10 + " и " + sayNumber1);
                    }
                    else
                    {
                        Console.WriteLine("С думи: " + sayNumber10);
                    }
                }
                else
                {
                    if (number1 > 0)
                    {
                        Console.WriteLine("С думи: " + sayNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Въведеното число не е в интервала от 1 - 999");
                    }
                }
            }
        }
    }
}