namespace NullValuesArithmetic
{
    using System;

    public class NullValuesArithmetic
    {
        public static void Main(string[] args)
        {
            int? nullableInteger = null;
            double? nullableDouble = null;
            Console.WriteLine("The value of integer is {0}", nullableInteger);
            Console.WriteLine("The value of double is {0}", nullableDouble);

            nullableInteger += null;
            nullableDouble += 5.0;
            Console.WriteLine("The value of integer is {0}", nullableInteger);
            Console.WriteLine("The value of double is {0}", nullableDouble);
        }
    }
}
