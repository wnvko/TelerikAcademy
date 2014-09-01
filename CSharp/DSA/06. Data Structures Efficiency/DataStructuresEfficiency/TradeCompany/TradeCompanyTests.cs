using System;
using Wintellect.PowerCollections;

public class TradeCompany
{
    private static Random rnd = new Random();
    private const int numberOfArticles = 1000000;
    private const decimal minValue = 500;
    private const decimal maxValue = 501;

    static void Main()
    {

        OrderedMultiDictionary<decimal, string> articles = new OrderedMultiDictionary<decimal, string>(true);
        articles = LoadData(numberOfArticles);
        PrintRange(articles, minValue, maxValue);
    }

    private static OrderedMultiDictionary<decimal, string> LoadData(int numberOfArticles)
    {
        OrderedMultiDictionary<decimal, string> articles = new OrderedMultiDictionary<decimal, string>(true);
        for (int articel = 0; articel < numberOfArticles; articel++)
        {
            decimal randomPrice = GetRandomPrice();
            string product = GetRandomProduct();
            articles[randomPrice].Add(product);
        }

        return articles;
    }

    private static void PrintRange(OrderedMultiDictionary<decimal, string> articles, decimal minValue, decimal maxValue)
    {
        OrderedMultiDictionary<decimal, string>.View filtereList = articles.Range(minValue, true, maxValue, false);
        foreach (var articel in filtereList)
        {
            Console.WriteLine("Price: {0}", articel.Key);

            foreach (var name in articel.Value)
            {
                Console.WriteLine("\t --> {0}", name);
            }
        }
    }

    private static decimal GetRandomPrice()
    {
        decimal randomPrice = rnd.Next(numberOfArticles / 10) / 100.0m;
        return randomPrice;
    }

    private static string GetRandomProduct()
    {
        string randomBarCode = GetRandomString(8, 8);
        string randomVendor = GetRandomString(5, 10);
        string randomTitle = GetRandomString(10, 20);

        return randomBarCode + " : " + randomVendor + "/" + randomTitle;
    }

    private static string GetRandomString(int minLen, int maxLen)
    {
        int stringLenght = rnd.Next(minLen, maxLen);
        char[] stringAsCharArray = new char[stringLenght];

        for (int letter = 0; letter < stringLenght; letter++)
        {
            stringAsCharArray[letter] = (char)(rnd.Next(25) + 'a');
        }

        string randomString = new string(stringAsCharArray);
        return randomString;
    }
}
