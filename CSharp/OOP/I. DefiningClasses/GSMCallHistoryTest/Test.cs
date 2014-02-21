namespace GSMCallHistoryTest
{
    using System;
    using MobilePhone;
    using System.Globalization;
    using System.Threading;

    class Test
    {
        private static decimal callPricePerMinute = 0.37m;

        public static void PrintCallHistory(GSM phones)
        {
            Console.WriteLine("Calls list for {0} {1}\n", phones.OwnerFirstName, phones.OwnerSecondName);
            Console.WriteLine("{0,-12}{1,-10}{2,-20}{3}", "Date:", "Time:", "Called number:", "Duration [s]:");
            foreach (var call in phones.CallHistory)
            {
                DateTime callDate = call.CallDate;
                string calledNumber = call.CalledNumber;
                int callDuration = call.CallDuration;

                Console.WriteLine("{0,-12:dd.MM.yyyy}{0,-10:HH:mm:ss}{1,-20}{2,13:D0}", callDate, calledNumber, callDuration);
            }
        }

        public static void RemoveLongestCall(GSM phones)
        {
            int longestDuration = int.MinValue;
            int possitionOfLongestCall = int.MinValue;

            for (int i = 0; i < phones.CallHistory.Count; i++)
            {
                if (phones.CallHistory[i].CallDuration > longestDuration)
                {
                    longestDuration = phones.CallHistory[i].CallDuration;
                    possitionOfLongestCall = i;
                }
            }
            phones.RemoveCall(possitionOfLongestCall);
        }

        static void Main(string[] args)
        {
            GSM phones = new GSM("Samsung", "GalaxyS", 500.00m, "Jhon", "Smith", "Li-Ion", 730, 16, BatteryType.LiIon, 6d, 2000000);

            phones.AddCall(DateTime.Now.AddDays(-120.258), "+359 (87) 820 7979", 145);
            phones.AddCall(DateTime.Now, "+359 (88) 853 5280", 60);
            phones.AddCall(DateTime.Now.AddDays(35.086), "+359 (86) 315 7000", 80);
            phones.AddCall(DateTime.Now.AddDays(35.128), "+359 (2) 891 4868", 28);

            PrintCallHistory(phones);

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal callsPrice = phones.CallPriceCalculate(callPricePerMinute);
            Console.WriteLine();
            Console.WriteLine("Total calls price {0:C2}\n", callsPrice);

            RemoveLongestCall(phones);
            Console.WriteLine("Longest call removed");
            callsPrice = phones.CallPriceCalculate(callPricePerMinute);
            Console.WriteLine("Total calls price now is {0:C2}\n", callsPrice);

            phones.ClearCallsHistory();

            PrintCallHistory(phones);
        }
    }
}
