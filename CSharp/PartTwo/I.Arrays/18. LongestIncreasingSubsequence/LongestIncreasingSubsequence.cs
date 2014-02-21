/*
 * * Write a program that reads an array of integers and removes from
 * it a minimal number of elements in such way that the remaining array
 * is sorted in increasing order. Print the remaining sorted array.
 * Example:	{6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
 */

//Solving longest increasing subsequence with Patience sort
//More info here:
//http://chandermani.blogspot.com/2012/05/alogorithm-finding-longest-increasing.html



namespace LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;

    class LongestIncreasingSubsequence
    {
        static void Main()
        {   
            //input
            List<int> inputData = new List<int>();
            int numbersCount = 0;
            Console.Write("Enter the how much numbers are in the array: ");
            numbersCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < numbersCount; count++)
            {
                Console.Write("Element No{0} = ", count + 1);
                inputData.Add(int.Parse(Console.ReadLine()));
            }

            //calculations
            List<int> deck = new List<int>() { inputData[0] };
            List<List<int>> decks = new List<List<int>>();
            decks.Add(deck);
            List<int> links = new List<int>();
            
            for (int indexOfArray = 1; indexOfArray < numbersCount; indexOfArray++)
            {
                int currentNumberOfDecks = decks.Count;
                for (int outerListCounter = 0; outerListCounter < currentNumberOfDecks; outerListCounter++)
                {
                    int innerListCounter = decks[outerListCounter].Count - 1;
                    if (inputData[indexOfArray] < decks[outerListCounter][innerListCounter])
                    {
                        decks[outerListCounter].Add(inputData[indexOfArray]);
                        if (outerListCounter < 1)
                        {
                            break;
                        }
                        innerListCounter = decks[outerListCounter-1].Count - 1;
                        links[outerListCounter-1] = decks[outerListCounter-1][innerListCounter];
                        break;
                    }
                    if (outerListCounter == currentNumberOfDecks - 1)
                    {
                        deck = new List<int>() { inputData[indexOfArray] };
                        decks.Add(deck);
                        links.Add(decks[currentNumberOfDecks-1][innerListCounter]);
                    }
                }
            }
            //output
            Console.WriteLine("The longest increasing subset has lenght of {0} elements.", decks.Count);
            Console.WriteLine("One example for such subset is:");


            for (int index = 0; index < links.Count; index++)
            {
                Console.Write("{0}, ", links[index]);
            }
            int outerCounter = decks.Count-1;
            int innerCounter = decks[outerCounter].Count-1;
            Console.Write(decks[outerCounter][innerCounter]);
            Console.WriteLine();
        }
    }
}