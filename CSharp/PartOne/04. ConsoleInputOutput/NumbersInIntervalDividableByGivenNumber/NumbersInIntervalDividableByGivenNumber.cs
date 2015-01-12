namespace NumbersInIntervalDividableByGivenNumber
{
    using System;
    using System.Collections.Generic;

    public class NumbersInIntervalDividableByGivenNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter start ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end ");
            int end = int.Parse(Console.ReadLine());

            Console.Write("{0} - {1} ", start, end);

            List<int> theRightNumbers = new List<int>();
            for (int number = start; number <= end; number++)
            {
                if (number % 5 == 0)
                {
                    theRightNumbers.Add(number);
                }
            }

            Console.Write("{0} ", theRightNumbers.Count);

            for (int number = 0; number < theRightNumbers.Count; number++)
            {
                Console.Write("{0} ", theRightNumbers[number]);
            }
        }
    }
}
