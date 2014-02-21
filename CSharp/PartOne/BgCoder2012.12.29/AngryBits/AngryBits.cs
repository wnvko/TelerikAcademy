namespace ABM
{
    using System;

    class AngryBits
    {
        static void Main()
        {
            //receive input as array
            int[] rows = new int[8];
            for (int i = 0; i < 8; i++)
            {
                rows[i] = int.Parse(Console.ReadLine());
            }


            ////output the grid just for tests
            //foreach (int bit in rows)
            //{
            //    console.writeline((convert.tostring(bit, 2)).padleft(16, '0'));
            //}

            //find all birds
            int[] birdColumn = new int[8];
            int[] birdRow = new int[8];
            int birdCount = 0;

            for (int i = 8; i < 16; i++) //goes trough columns
            {
                for (int j = 0; j < 8; j++) //goes trough rows
                {
                    if ((rows[j] & (1 << i)) > 0)
                    {
                        birdColumn[birdCount] = i;
                        birdRow[birdCount] = j;
                        birdCount++;
                    }
                }
            }

            //find pigs count
            int pigCount = 0;

            for (int i = 0; i < 8; i++) //goes trough columns
            {
                for (int j = 0; j < 8; j++) //goes trough rows
                {
                    if ((rows[j] & (1 << i)) > 0)
                    {
                        pigCount++;
                    }
                }
            }

            //bird starts flying
            int score = 0;

            for (int i = 0; i < birdCount; i++)
            {
                int deadPigs = 0;
                int birdMoves = 0;
                int row = birdRow[i];
                int column = birdColumn[i];
                rows[row] = rows[row] & (~(1 << column)); //clear the bird from board
                bool hereIsThePig = false;

                //birds go up and right
                while (row > 0 && column > 0)
                {
                    row--;
                    column--;
                    birdMoves++;
                    
                    //find pigs 'seek and destroy'
                    hereIsThePig = (rows[row] & (1 << column)) > 0;
                    if (hereIsThePig)
                    {
                        deadPigs++;
                        pigCount--;
                        rows[row] = rows[row] & (~(1 << column)); //clear the pig from board

                        //clear pigs around the found one
                        for (int k = -1; k < 2; k++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if (((row + k) >= 0) && ((column + j) >= 0) && ((row + k) < 8) && ((rows[row + k] & (1 << (column + j))) > 0))
                                {
                                    deadPigs++;
                                    pigCount--;
                                    rows[row + k] = rows[row + k] & (~(1 << (column + j)));
                                }
                            }
                        }
                        //stop current bird
                        column = 0;

                    }//end if pig is dead
                }//end up+right 

                //birds go down and right
                while (row < 7 && column > 0)
                {
                    row++;
                    column--;
                    birdMoves++;

                    //find pigs 'seek and destroy'
                    hereIsThePig = (rows[row] & (1 << column)) > 0;
                    if (hereIsThePig)
                    {
                        deadPigs++;
                        pigCount--;
                        rows[row] = rows[row] & (~(1 << column)); //clear the pig from board

                        //clear pigs around the found one
                        for (int k = -1; k < 2; k++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if (((row + k) >= 0) && ((column + j) >= 0) && ((row + k) < 8) && ((rows[row + k] & (1 << (column + j))) > 0))
                                {
                                    deadPigs++;
                                    pigCount--;
                                    rows[row + k] = rows[row + k] & (~(1 << (column + j)));
                                }
                            }
                        }
                        //stop current bird if pig is killed
                        column = 0;

                    }//end if pig is dead
                }//end down+right

                if (deadPigs > 0)
                {
                    score = score + birdMoves * deadPigs;
                }
                
                //prevent bird flying after all pigs are dead
                if (pigCount == 0)
                {
                    break;
                }
            } //for end

            if (pigCount > 0)
            {
                Console.WriteLine("{0} No", score);
            }
            else
            {
                Console.WriteLine("{0} Yes", score);
            }
        }
    }
}