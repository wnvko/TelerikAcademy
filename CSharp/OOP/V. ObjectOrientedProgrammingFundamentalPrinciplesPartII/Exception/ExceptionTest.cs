namespace Exceptions
{
    using System;

    class ExceptionTest
    {
        static void Main(string[] args)
        {
            const int LowerNumber = 0;
            const int UpperNumber = 100;
            DateTime LowerDate = new DateTime(1980,1,1);
            DateTime UpperDate = new DateTime(2013,12,31);
            try
            {
                int wrongNumber = 150;
                if (wrongNumber < LowerNumber || wrongNumber > UpperNumber)
                {
                    throw new InvalidRangeException<int>("Number out of range!", LowerNumber, UpperNumber);
                }

                DateTime wrongDate = new DateTime(2015, 10, 15);
                if (wrongDate < LowerDate || wrongDate > UpperDate)
                {
                    throw new InvalidRangeException<DateTime>("Date out of range!", LowerDate,UpperDate);
                    
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("Wrong number entered. Number must be in range {0} - {1}",ex.LowerLimit,ex.UpperLimit);
            }

            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("Wrong date entered. Date must be in range {0:dd/MM/yyyy} - {1:dd/MM/yyyy}", ex.LowerLimit, ex.UpperLimit);
            }
        }
    }
}