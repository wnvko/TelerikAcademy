using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using Wintellect;

public class OrderedBagTest
{
    public const int ElementsCount = 500000;
    public static Random rnd = new Random();

    public static void Main(string[] args)
    {
        OrderedBag<Product> products = new OrderedBag<Product>();
        FillTheBag(products);

        Product rangeLowerLimit = new Product();
        rangeLowerLimit.Price = 1000;

        Product rangeUpperLimit = new Product();
        rangeUpperLimit.Price = 1000.2M;

        foreach (var pair in products.Range(rangeLowerLimit, true, rangeUpperLimit, true))
        {
            Console.WriteLine("{0} -- > {1}", pair.Price, pair.Name);
        }
    }

    private static void FillTheBag(OrderedBag<Product> bagtoFill)
    {
        Product randomProduct;

        for (int element = 0; element < ElementsCount; element++)
        {
            string randomString = GetRandomString();
            decimal randomPice = GetRandomPrice();
            randomProduct = new Product();
            randomProduct.Name = randomString;
            randomProduct.Price = randomPice;

            bagtoFill.Add(randomProduct);
        }
    }

    private static string GetRandomString()
    {
        int stringLenght = rnd.Next(10, 15);
        char[] stringAsCharArray = new char[stringLenght];

        for (int letter = 0; letter < stringLenght; letter++)
        {
            stringAsCharArray[letter] = (char)(rnd.Next(25) + 'a');
        }

        string randomString = new string(stringAsCharArray);
        return randomString;
    }

    private static decimal GetRandomPrice()
    {
        decimal randomPrice = rnd.Next(0, ElementsCount) / 100m;
        return randomPrice;
    }
}
