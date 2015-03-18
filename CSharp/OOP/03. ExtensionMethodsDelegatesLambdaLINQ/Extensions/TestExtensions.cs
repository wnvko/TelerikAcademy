using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public class TestExtensions
    {
        public static void Main(string[] args)
        {
            // Test for SubString method for StringBuilder
            StringBuilder testSB = new StringBuilder();
            testSB.Append("Some simple text just for testing");

            StringBuilder trimedSB = new StringBuilder();
            trimedSB = testSB.SubString(5, testSB.Length - 13);
            Console.WriteLine(trimedSB);

            // Generate some delegates for add, product and average extension methods
            Func<float, float, float> add = (x, y) => x + y;
            Func<float, float, float> multiply = (x, y) => x * y;
            Func<float, int, float> divide = (x, y) => x / y;

            List<float> intList = new List<float>() { 20, 23, 6, 89, 31 };

            // Test for Sum method of IEnumerable
            Console.WriteLine(intList.Sum(add));

            // Test for Product method of IEnumerable
            Console.WriteLine(intList.Product(multiply));

            // Test for Average method of IEnumerable
            Console.WriteLine(intList.Average(add, divide));

            List<string> textList = new List<string>() { "First", "Last", "Alfa", "Zulu" };

            // Test for Min method of IEnumerable
            Console.WriteLine(textList.Min());

            // Test for Max method of IEnumerable
            Console.WriteLine(textList.Max());
        }
    }
}
