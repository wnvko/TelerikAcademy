namespace YourAgeNoaAndThen
{
    using System;

    public class YourAgeNoaAndThen
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your birthday [mm/dd/yyyy]: ");
            string birthDayAsString = Console.ReadLine();

            string[] birthDayAsStringArray = birthDayAsString.Split('/');
            int[] birthDayAsIntegersArray = new int[3];

            for (int i = 0; i < birthDayAsIntegersArray.Length; i++)
            {
                birthDayAsIntegersArray[i] = int.Parse(birthDayAsStringArray[i]);
            }

            DateTime birthDay = new DateTime(birthDayAsIntegersArray[2], birthDayAsIntegersArray[1], birthDayAsIntegersArray[0]);
            int currentAge = (int)(DateTime.Now - birthDay).Days / 365;
            Console.WriteLine("You are {0} years old now", currentAge);
            Console.WriteLine("After 10 years you will be {0} years old", currentAge + 10);
        }
    }
}
