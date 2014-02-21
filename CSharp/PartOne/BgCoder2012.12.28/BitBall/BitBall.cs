namespace BitBall
{
    using System;

    class BitBall
    {
        static void Main()
        {
            int[] topTeam = new int[8];
            int[] bottomTeam = new int[8];

            //top team input
            for (int i = 0; i < 8; i++)
            {
                topTeam[i] = int.Parse(Console.ReadLine());
            }

            //bottom team input
            for (int i = 0; i < 8; i++)
            {
                bottomTeam[i] = int.Parse(Console.ReadLine());
            }

            //players after fouls
            int[] xorBuffer = new int[8];
            for (int i = 0; i < 8; i++)
            {
                xorBuffer[i] = topTeam[i] ^ bottomTeam[i];
                topTeam[i] = topTeam[i] & xorBuffer[i];
                bottomTeam[i] = bottomTeam[i] & xorBuffer[i];
            }

            //top team result
            int topTeamScore = 0;
            int bottomTeamScore = 0;
            bool scorePoint = true;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    //find players
                    if ((topTeam[row] & (1 << col)) != 0)
                    {
                        scorePoint = true;

                        for (int i = row+1; i < 8; i++)
                        {
                            //is there team mate on the player's column
                            if((row < 8) && (topTeam[row] & (1 << col)) == (topTeam[i] & (1 << col)))
                            {
                                scorePoint = false;
                                break;
                            }

                            //is there oposite player on the player's column
                            if ((row < 8) && (topTeam[row] & (1 << col)) == (bottomTeam[i] & (1 << col)))
                            {
                                scorePoint = false;
                                break;
                            }
                        }

                        if (scorePoint)
                        {
                            topTeamScore++;
                        }
                    }
                }
            }

            //top team result
            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col < 8; col++)
                {
                    //find players
                    if ((bottomTeam[row] & (1 << col)) != 0)
                    {
                        scorePoint = true;

                        for (int i = row - 1; i >= 0; i--)
                        {
                            //is there team mate on the player's column
                            if ((row >= 0) && (bottomTeam[row] & (1 << col)) == (bottomTeam[i] & (1 << col)))
                            {
                                scorePoint = false;
                                break;
                            }

                            //is there oposite player on the player's column
                            if ((row >= 0) && (bottomTeam[row] & (1 << col)) == (topTeam[i] & (1 << col)))
                            {
                                scorePoint = false;
                                break;
                            }
                        }

                        if (scorePoint)
                        {
                            bottomTeamScore++;
                        }
                    }
                }
            }
            Console.Write(topTeamScore);
            Console.Write(":");
            Console.WriteLine(bottomTeamScore);
        }
    }
}
