namespace DivideBySevenAndFive
{
    using System;

    public class DivideBySevenAndFive
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            string result = (number % 7 == 0) && (number % 5 == 0) ? "Yes" : "No";
            Console.WriteLine("{0} can be divided to 7 and 5 without reminder: {1}", number, result);
        }
    }
}
