using System;
using System.Diagnostics;

namespace AddSubtractComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            int[] intArray = GenerateNumArray(1);
            long[] longArray = GenerateNumArray(1L);
            float[] floatArray = GenerateNumArray(1.0F);
            double[] doubleArray = GenerateNumArray(1.0d);
            decimal[] decimalArray = GenerateNumArray(1.0m);

            var intContainer = 0;
            stopwatch.Start();
            for (int i = 0; i < intArray.Length; i++)
            {
                intContainer += intArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Sum ints for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            var longContainer = 0L;
            stopwatch.Start();
            for (int i = 0; i < longArray.Length; i++)
            {
                longContainer += longArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Sum longs for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            var floatContainer = 0f;
            stopwatch.Start();
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatContainer += floatArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Sum floats for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            var doubleContainer = 0.0d;
            stopwatch.Start();
            for (int i = 0; i < doubleArray.Length; i++)
            {
                doubleContainer += doubleArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Sum doubles for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            var decimalContainer = 0.0m;
            stopwatch.Start();
            for (int i = 0; i < decimalArray.Length; i++)
            {
                decimalContainer += decimalArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Sum decimals for {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            intContainer = 1;
            stopwatch.Start();
            for (int i = 0; i < intArray.Length; i++)
            {
                intContainer *= intArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Multiply ints for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            longContainer = 1L;
            stopwatch.Start();
            for (int i = 0; i < longArray.Length; i++)
            {
                longContainer *= longArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Multiply longs for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            floatContainer = 1f;
            stopwatch.Start();
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatContainer *= floatArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Multiply floats for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            doubleContainer = 1.0d;
            stopwatch.Start();
            for (int i = 0; i < doubleArray.Length; i++)
            {
                doubleContainer *= doubleArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Multiply doubles for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimalContainer = 1.0m;
            stopwatch.Start();
            for (int i = 0; i < decimalArray.Length; i++)
            {
                decimalContainer *= decimalArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Multiply decimals for {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            stopwatch.Start();
            for (int i = 0; i < intArray.Length; i++)
            {
                intContainer /= intArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Divide ints for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < longArray.Length; i++)
            {
                longContainer /= longArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Divide longs for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatContainer /= floatArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Divide floats for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < doubleArray.Length; i++)
            {
                doubleContainer /= doubleArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Divide doubles for {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < decimalArray.Length; i++)
            {
                decimalContainer /= decimalArray[i];
            }

            stopwatch.Stop();
            Console.WriteLine("Divide decimals for {0}", stopwatch.Elapsed);
            stopwatch.Reset();
        }

        public static T[] GenerateNumArray<T>(T type)
        {
            T[] intArray = new T[10000];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = type;
            }

            return intArray;
        }
    }
}
