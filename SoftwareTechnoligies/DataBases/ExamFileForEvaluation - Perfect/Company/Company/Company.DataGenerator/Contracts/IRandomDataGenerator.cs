namespace Company.DataGenerator.Contracts
{
    using System;

    public interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomString(int minLength, int maxLength);

        bool GetChance(int percent);

        DateTime GetRandomDate(DateTime min, DateTime max);
    }
}
