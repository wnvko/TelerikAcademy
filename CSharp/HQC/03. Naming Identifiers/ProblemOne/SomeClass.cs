namespace ProblemOne
{
    using System;

    public class SomeClass
    {
        public const int MaxCount = 6;
        
        public class SomeInternalClass
        {
            public void PrintBooleanValue(bool inputValue)
            {
                string inputAsString = inputValue.ToString();
                Console.WriteLine(inputAsString);
            }
        }
    }
}