namespace Poker
{
    using System;

    class Poker
    {
        static void Main()
        {
            string[] cardAsString = new string[5];
            cardAsString[0] = Console.ReadLine();
            cardAsString[1] = Console.ReadLine();
            cardAsString[2] = Console.ReadLine();
            cardAsString[3] = Console.ReadLine();
            cardAsString[4] = Console.ReadLine();

            int[] cardAsNumber = new int[5];
            bool sameCards = true;
            bool smallSuit = false;
            bool bigSuit = false;
            //changing the card with numbers 0 = A; 1 = 2; ... 9 = 10; 10 = J ... 13 = A
            for (int i = 0; i < 5; i++)
            {
                switch (cardAsString[i])
                {
                    case "A": cardAsNumber[i] = 0; break;
                    case "2": cardAsNumber[i] = 1; break;
                    case "3": cardAsNumber[i] = 2; break;
                    case "4": cardAsNumber[i] = 3; break;
                    case "5": cardAsNumber[i] = 4; break;
                    case "6": cardAsNumber[i] = 5; break;
                    case "7": cardAsNumber[i] = 6; break;
                    case "8": cardAsNumber[i] = 7; break;
                    case "9": cardAsNumber[i] = 8; break;
                    case "10": cardAsNumber[i] = 9; break;
                    case "J": cardAsNumber[i] = 10; break;
                    case "Q": cardAsNumber[i] = 11; break;
                    case "K": cardAsNumber[i] = 12; break;
                    default: break;
                }
            }

            //sorting the cards
            for (int i = 5; i > 0; i--)
            {
                for (int j = 0; j < (i - 1); j++)
                {
                    if (cardAsNumber[j] > cardAsNumber[j + 1])
                    {
                        int buffer = cardAsNumber[j];
                        cardAsNumber[j] = cardAsNumber[j + 1];
                        cardAsNumber[j + 1] = buffer;
                    }
                }
            }

            //check for same cards
            if (cardAsNumber[0] == cardAsNumber[1])
            {
                if (cardAsNumber[1] == cardAsNumber[2])
                {
                    if (cardAsNumber[2] == cardAsNumber[3])
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Impossible");
                        }
                        else
                        {
                            Console.WriteLine("Four of a Kind");
                        }
                    }
                    else
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Full House");
                        }
                        else
                        {
                            Console.WriteLine("Three of a Kind");
                        }
                    }
                }
                else
                {
                    if (cardAsNumber[2] == cardAsNumber[3])
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Full House");
                        }
                        else
                        {
                            Console.WriteLine("Two Pairs");
                        }
                    }
                    else
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Two Pairs");
                        }
                        else
                        {
                            Console.WriteLine("One Pair");
                        }
                    }
                }
            }
            else
            {
                if (cardAsNumber[1] == cardAsNumber[2])
                {
                    if (cardAsNumber[2] == cardAsNumber[3])
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Four of a Kind");
                        }
                        else
                        {
                            Console.WriteLine("Three of a Kind");
                        }
                    }
                    else
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Two Pairs");
                        }
                        else
                        {
                            Console.WriteLine("One Pair");
                        }
                    }
                }
                else
                {
                    if (cardAsNumber[2] == cardAsNumber[3])
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("Three of a Kind");
                        }
                        else
                        {
                            Console.WriteLine("One Pair");
                        }
                    }
                    else
                    {
                        if (cardAsNumber[3] == cardAsNumber[4])
                        {
                            Console.WriteLine("One Pair");
                        }
                        else
                        {
                            sameCards = false;
                        }
                    }
                }
            }
            //check for small suits
            smallSuit = cardAsNumber[0] == (cardAsNumber[1] - 1);
            smallSuit = smallSuit && cardAsNumber[0] == (cardAsNumber[2] - 2);
            smallSuit = smallSuit && cardAsNumber[0] == (cardAsNumber[3] - 3);
            smallSuit = smallSuit && cardAsNumber[0] == (cardAsNumber[4] - 4);

            //check for big suits
            bigSuit = cardAsNumber[0] == (cardAsNumber[1] - 9);
            bigSuit = bigSuit && cardAsNumber[0] == (cardAsNumber[2] - 10);
            bigSuit = bigSuit && cardAsNumber[0] == (cardAsNumber[3] - 11);
            bigSuit = bigSuit && cardAsNumber[0] == (cardAsNumber[4] - 12);

            if (bigSuit || smallSuit)
            {
                Console.WriteLine("Straight");
            }
            if (!((bigSuit || smallSuit) || sameCards))
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}