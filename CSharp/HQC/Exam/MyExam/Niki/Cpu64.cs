namespace Computers
{
    using System;
    using Contracts;

   public class Cpu64 : ICPU
    {
        public const int MaxPossibleInput = 1000;
        public const string NegativeInputError = "Number too low.";
        public const string InputValueOutOfRange = "Number too high.";
        public static readonly Random Random = new Random();

        public Cpu64(int coresCount)
        {
            this.CoresCount = coresCount;
        }

        public int CoresCount { get; set; }

        public int SquareNumber(IRam ram)
        {
            int data = ram.LoadValue();

            if (data < 0)
            {
                throw new ArgumentOutOfRangeException(NegativeInputError);
            }
            else if (data > MaxPossibleInput)
            {
                throw new ArgumentOutOfRangeException(InputValueOutOfRange);
            }
            else
            {
                int value = data * data;
                return value;
            }
        }

        public void GenerateRandomNumber(IRam ram, int minValue, int maxValue)
        {
            int randomNumber = Random.Next(minValue, maxValue);
            ram.SaveValue(randomNumber);
        }
    }
}