namespace PrintADeckOf52Cards
{
    using System;

    public class PrintADeckOf52Cards
    {
        public static void Main(string[] args)
        {
            for (int card = 2; card < 15; card++)
            {
                string cardName = card.ToString();
                if (card > 10)
                {
                    switch (card)
                    {
                        case 11:
                            cardName = "J";
                            break;
                        case 12:
                            cardName = "Q";
                            break;
                        case 13:
                            cardName = "K";
                            break;
                        case 14:
                            cardName = "A";
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("{0,4}\u2660 {0,4}\u2665 {0,4}\u2666 {0,4}\u2663", cardName);
            }
        }
    }
}
