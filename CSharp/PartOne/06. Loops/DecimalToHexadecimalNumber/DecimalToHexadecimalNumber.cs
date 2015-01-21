namespace DecimalToHexadecimalNumber
{
    using System;

    public class DecimalToHexadecimalNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int decNumber = int.Parse(Console.ReadLine());
            string hexNumber = string.Empty;

            while (decNumber != 0)
            {
                string reminder = (decNumber % 16).ToString();
                switch (reminder)
                {
                    case "10":
                        reminder = "A";
                        break;
                    case "11":
                        reminder = "B";
                        break;
                    case "12":
                        reminder = "C";
                        break;
                    case "13":
                        reminder = "D";
                        break;
                    case "14":
                        reminder = "E";
                        break;
                    case "15":
                        reminder = "F";
                        break;
                    default:
                        break;
                }

                hexNumber = reminder + hexNumber;
                decNumber /= 16;
            }

            Console.WriteLine(hexNumber);
        }
    }
}
