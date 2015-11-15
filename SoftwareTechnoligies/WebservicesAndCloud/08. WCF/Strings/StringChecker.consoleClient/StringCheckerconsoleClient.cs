namespace StringChecker.Consoleclient
{
    using System;
    using Proxy;

    public class StringCheckerconsoleClient
    {
        public static void Main(string[] args)
        {
            //string lookIn = "No test in this dummy text";
            //string lookFor = "Test";

            string lookIn = "Test some text TestTest and more text and TestTestTest and one more Test";
            string lookFor = "Test";

            var count = 0;
            using (var client = new StringCheckerServiceClient())
            {
                count = client.CheckRepeatedCount(lookIn, lookFor);
            }

            Console.WriteLine("{0} is repeated {1} times in {2}", lookFor, count, lookIn);
        }
    }
}
