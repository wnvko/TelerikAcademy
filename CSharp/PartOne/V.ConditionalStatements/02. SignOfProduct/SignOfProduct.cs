namespace SignOfProduct
{
    using System;

    class SignOfProduct
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            if ((firstNumber == 0) || (secondNumber == 0) || (thirdNumber == 0))
            {
                Console.WriteLine("The product is \"0\"");
            }
            else
            {
                if (firstNumber > 0)
                {
                    if (secondNumber > 0)
                    {
                        if (thirdNumber > 0)
                        {
                            Console.WriteLine("Sign of the product is \"+\"");
                        }
                        else
                        {
                            Console.WriteLine("Sign of the product is \"-\"");
                        }
                    }
                    else
                    {
                        if (thirdNumber > 0)
                        {
                            Console.WriteLine("Sign of the product is \"-\"");
                        }
                        else
                        {
                            Console.WriteLine("Sign of the product is \"+\"");
                        }
                    }
                }
                else
                {
                    if (secondNumber > 0)
                    {
                        if (thirdNumber > 0)
                        {
                            Console.WriteLine("Sign of the product is \"-\"");
                        }
                        else
                        {
                            Console.WriteLine("Sign of the product is \"+\"");
                        }
                    }
                    else
                    {
                        if (thirdNumber > 0)
                        {
                            Console.WriteLine("Sign of the product is \"+\"");
                        }
                        else
                        {
                            Console.WriteLine("Sign of the product is \"-\"");
                        }
                    }
                }
            }
        }
    }
}
