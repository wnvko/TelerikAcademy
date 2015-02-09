namespace CheckForAPlayCard
{
    using System;

    public class CheckForAPlayCard
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a card face:");
            string cardFace = Console.ReadLine();
            bool isCardFace = false;

            switch (cardFace)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                case "A":
                    isCardFace = true;
                    break;
                default:
                    isCardFace = false;
                    break;
            }

            if (isCardFace)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
