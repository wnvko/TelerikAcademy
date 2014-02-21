namespace CardWars
{
    using System;
    using System.Numerics;

    class CardWars
    {
        static void Main()
        {
            int gamesInMatch = int.Parse(Console.ReadLine());
            string[,] firstPlayerCards = new string[gamesInMatch, 3];
            string[,] secondPlayerCards = new string[gamesInMatch, 3];
            
            //read games data
            for (int i = 0; i < gamesInMatch; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    firstPlayerCards[i, j] = Console.ReadLine();
                }
                for (int j = 0; j < 3; j++)
                {
                    secondPlayerCards[i, j] = Console.ReadLine();
                }
            }

            //calculate scores

            BigInteger firstPlayerScore = 0;
            BigInteger secondPlayerScore = 0;
            int first = 0;
            int second = 0;
            bool isFirstX = false;
            bool isSecondX = false;
            int firstPlayerGamesWon = 0;
            int secondPlayerGamesWon = 0;

            for (int i = 0; i < gamesInMatch; i++)
            {
                int fpScore = 0;
                int spScore = 0;

                for (int j = 0; j < 3; j++)
                {
                    first = ReturnCardValue(firstPlayerCards[i, j]);
                    second =  ReturnCardValue(secondPlayerCards[i, j]);
                    
                    //first player score
                    switch (first)
                    {
                        case 100: isFirstX = true; break;
                        case -200: firstPlayerScore -=200; break;
                        case 300: firstPlayerScore *=2; break;
                        default: fpScore += first; break;
                    }
                    
                    //second player score
                    switch (second)
                    {
                        case 100: isSecondX = true; break;
                        case -200: secondPlayerScore -=200; break;
                        case 300: secondPlayerScore *=2; break;
                        default: spScore += second; break;
                    }
                }
                //check for X cards
                if (isFirstX && isSecondX)
                {
                    firstPlayerScore += 50;
                    secondPlayerScore += 50;
                    isFirstX = false;
                    isSecondX = false;
                }
                if (isFirstX || isSecondX)
                {
                    break;
                }

                //calculate after game score
                if (fpScore > spScore)
                {
                    firstPlayerScore += fpScore;
                    firstPlayerGamesWon++;
                }
                else
                {
                    if (fpScore < spScore)
                    {
                        secondPlayerScore += spScore;
                        secondPlayerGamesWon++;
                    }
                }
            }
            
            //output result
            if (isFirstX || isSecondX)
            {
                if (isFirstX)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                }
                if (isSecondX)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                }
            }
            else
            {
                if (firstPlayerScore > secondPlayerScore)
                {
                    Console.WriteLine("First player wins!");
                    Console.WriteLine("Score: {0:F0}", firstPlayerScore);
                    Console.WriteLine("Games won: {0:F0}", firstPlayerGamesWon);
                }
                else
                {
                    if (secondPlayerScore > firstPlayerScore)
                    {
                        Console.WriteLine("Second player wins!");
                        Console.WriteLine("Score: {0:F0}", secondPlayerScore);
                        Console.WriteLine("Games won: {0:F0}", secondPlayerGamesWon);
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                        Console.WriteLine("Score: {0:F0}", firstPlayerScore);
                    }
                }
            }
        }

        static int ReturnCardValue(string inputCard)
        {
            int result = 0;
            switch (inputCard)
            {
                case "2": result = 10; break;
                case "3": result = 9; break;
                case "4": result = 8; break;
                case "5": result = 7; break;
                case "6": result = 6; break;
                case "7": result = 5; break;
                case "8": result = 4; break;
                case "9": result = 3; break;
                case "10": result = 2; break;
                case "A": result = 1; break;
                case "J": result = 11; break;
                case "Q": result = 12; break;
                case "K": result = 13; break;
                case "X": result = 100; break;
                case "Y": result = -200; break;
                case "Z": result = 300; break;
            }
            return result;
        }
    }
}
