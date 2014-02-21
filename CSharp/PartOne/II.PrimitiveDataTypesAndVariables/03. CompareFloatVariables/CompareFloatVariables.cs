namespace CompareFloatVariables
{
    using System;

    class CompareFloatVariables
    {
        static void Main()
        {
            /*
             * Write a program that safely compares floating-point
             * numbers with precision of 0.000001.
             * Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true
             */
            float firstNumber = 5.3f;
            float secondNumber = 6.0f;
            float thitdNumber = 5.3000001f;
            bool result = firstNumber == secondNumber;
            Console.WriteLine("5.3 = 6 -> {0}", result);
            result = firstNumber == thitdNumber;
            Console.WriteLine("5.3 = 5.3000001 -> {0}", result);
        }
    }
}
