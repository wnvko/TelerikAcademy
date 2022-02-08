namespace Company.DataGenerator
{
    using System;

    using Contracts;

    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomDataGenerator instance;

        private readonly Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static RandomDataGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomDataGenerator();
                }

                return instance;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.random.Next(0, Letters.Length)];
            }

            return new string(result);
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            return this.GetRandomString(this.random.Next(minLength, maxLength + 1));
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }


        public DateTime GetRandomDate(DateTime min, DateTime max)
        {
            var year = this.random.Next(min.Year, max.Year + 1);
            int month;
            int day;
            int hour;
            int minute;

            if (Math.Abs(min.Year - max.Year) > 1)
            {
                month = this.random.Next(1, 13);
                day = this.random.Next(1, 29);
                hour = this.random.Next(0, 24);
                minute = this.random.Next(0, 60);
            }
            else
            {
                month = this.random.Next(Math.Min(min.Month, max.Month), Math.Max(min.Month, max.Month));
                day = this.random.Next(Math.Min(min.Day, max.Day), Math.Max(min.Day, max.Day));
                hour = this.random.Next(Math.Min(min.Hour, max.Hour), Math.Max(min.Hour, max.Hour));
                minute = this.random.Next(Math.Min(min.Minute, max.Minute), Math.Max(min.Minute, max.Minute));
            }

            return new DateTime(year, month, day, hour, minute, 0);
        }
    }
}
