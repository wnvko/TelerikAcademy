namespace GravitationOnTheMoon
{
    using System;

    public class GravitationOnTheMoon
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your weight on the Earth: ");
            double userWeight = double.Parse(Console.ReadLine());
            double userWeightOnTheMoon = userWeight * 0.17;
            Console.WriteLine("You will weight only {0:F2} on the Moon", userWeightOnTheMoon);
        }
    }
}
