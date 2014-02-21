namespace Bittris
{
    using System;

    class Bittris
    {
        static void Main() //88 points in BGCoder :(
        {
            int N = int.Parse(Console.ReadLine());
            int numberOfBittris = N / 4;
            int score = 0;
            int[] playGrid = { 0, 0, 0, 0 };

            for (int turns = 0; turns < numberOfBittris; turns++)
            {   
                int currentBittris = int.Parse(Console.ReadLine());
                int addToScore = 0;
                bool bittrisOver = false;
                
                //counts the 1s in current bittris
                for (int counter = 0; counter < 32; counter++)
                {
                    int mask = 1;
                    if ((currentBittris & (mask << counter)) != 0)
                    {
                        addToScore++;
                    }
                }
                
                //clears all leading 1 in the number for easyer shifting
                currentBittris = currentBittris & 255;

                //put current bittris in the field
                if ((playGrid[0] & currentBittris) == 0)
                {
                    playGrid[0] += currentBittris;
                }
                else
                {
                    break;
                }

                //PrintBittrisField(playGrid);//only for debuging

                for (int moves = 1; moves < 4; moves++)
                {
                    char bittrisDirection = char.Parse(Console.ReadLine());
                    if (bittrisOver)
                    {
                        continue;
                    }

                    //check if can move left
                    bool canMoveLeft = true;
                    canMoveLeft = ((currentBittris << 1) & playGrid[moves - 1] & (~currentBittris)) == 0;
                    canMoveLeft = canMoveLeft && (currentBittris < 127);

                    //check if can move right
                    bool canMoveRight = true;
                    canMoveRight = ((currentBittris >> 1) & playGrid[moves - 1] & (~currentBittris)) == 0;
                    canMoveRight = canMoveRight && ((currentBittris % 2) != 1);
                    
                    switch (bittrisDirection)
                    {
                        //moves bittris down
                        case 'D':
                            {
                                
                                if ((playGrid[moves] & currentBittris) == 0)
                                {
                                    playGrid[moves] += currentBittris;
                                    if (moves > 0)
                                    {
                                        playGrid[moves - 1] = 0;
                                    }
                                }
                                else
                                {
                                    bittrisOver = true;
                                }
                                break;
                            }
                            //moves bittris left
                            case 'L':
                            {
                                if (canMoveLeft)
                                {
                                    playGrid[moves - 1] <<= 1;
                                    currentBittris <<= 1;
                                }
                                else
                                {
                                    //the bittris cannot move to the left
                                    break;
                                }
                                break;
                            }
                        //moves bittris right
                        case 'R':
                            {
                                if (canMoveRight)
                                {
                                    playGrid[moves - 1] >>= 1;
                                    currentBittris >>= 1;
                                }
                                else
                                {
                                    //the bittris cannot move to the right
                                    break; 
                                }
                                break;
                            }

                    }
                    if ((bittrisDirection == 'L') || (bittrisDirection == 'R'))
                    {
                        if ((playGrid[moves] & currentBittris) == 0)
                        {
                            playGrid[moves] += currentBittris;
                            if (moves > 0)
                            {
                                playGrid[moves - 1] = 0;
                            }
                        }
                        else
                        {
                            bittrisOver = true;
                        }
                    }
                    //PrintBittrisField(playGrid);//only for debuging
                }
                //check for full line
                for (int i = 0; i < 4; i++)
                {
                    if (playGrid[i] == 255)
                    {
                        playGrid[i] = 0;
                        addToScore *= 10;
                        for (int clear = i; clear > 0; clear--)
                        {
                            playGrid[clear] = playGrid[clear - 1];
                            playGrid[clear - 1] = 0;
                        }
                    }
                }
                score += addToScore;
            }
            Console.WriteLine(score);
        }
        
        static void PrintBittrisField(int[] bittrisField)
        {
            for (int i = 0; i < 4; i++)
            {
                string output = Convert.ToString(bittrisField[i],2);
                Console.WriteLine(output.PadLeft(8,'0'));
            }
            Console.WriteLine("Pres amy ley");
        }
    }
}
