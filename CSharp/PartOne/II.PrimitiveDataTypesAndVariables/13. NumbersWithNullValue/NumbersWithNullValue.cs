namespace NumbersWithNullValue
{
    using System;

    class NumbersWithNullValue
    {
        static void Main()
        {
            /*
             * Create a program that assigns null values to an integer
             * and to double variables. Try to print them on the console,
             * try to add some values or the null literal to them and see the result.
            */
            int? nullableInteger = null;
            double? nullableDouble = null;
            Console.WriteLine("The value of integer is {0}", nullableInteger);
            Console.WriteLine("The value of double is {0}", nullableDouble);
            
            //adding something to nullable variable initialized with value null does not change it
            nullableInteger += null;
            nullableDouble += 5.0;
            Console.WriteLine("The value of integer is {0}", nullableInteger);
            Console.WriteLine("The value of double is {0}", nullableDouble);
        }
    }
}