namespace FormulaBit1
{
    using System;

    class FormulaBit1
    {
        static void Main()
        {
            int[] inputNumber = new int[8];
            for (int i = 0; i < 8; i++)
            {
                inputNumber[i] = int.Parse(Console.ReadLine());
            }

            int column = 0;
            int row = 0;
            int mask = 1;
            int trackLenght = 1;
            int directionChange = 0;
            bool weHaveTrack = false;

            while (true)
            {
                if (inputNumber[0] % 2 == 1)
                {
                    trackLenght--;
                    break;
                }
                //move to the south
                MoveToSouth(inputNumber, column, ref row, mask, ref trackLenght, ref weHaveTrack);
                if (weHaveTrack)
                {
                    break;
                }
                row--;
                trackLenght--;
                if (((column + 1) > 7) || (inputNumber[row] & (mask << (column + 1))) != 0)
                {
                    break;
                }
                directionChange++;

                //move to the west
                MoveToTheWest(inputNumber, ref column, row, mask, ref trackLenght, ref weHaveTrack);
                if (weHaveTrack)
                {
                    break;
                }
                column--;
                trackLenght--;
                if (((row - 1) < 0) || (inputNumber[row - 1] & (mask << column)) != 0)
                {
                    break;
                }
                directionChange++;

                //move to the north
                MoveToTheNorth(inputNumber, column, ref row, mask, ref trackLenght, ref weHaveTrack);
                if (weHaveTrack)
                {
                    break;
                }
                row++;
                trackLenght--;
                if (((column + 1) > 7) || (inputNumber[row] & (mask << (column + 1))) != 0)
                {
                    break;
                }

                directionChange++;

                //move to the west
                MoveToTheWest(inputNumber, ref column, row, mask, ref trackLenght, ref weHaveTrack);
                if (weHaveTrack)
                {
                    break;
                }
                column--;
                trackLenght--;
                if (((row + 1) > 7) || (inputNumber[row + 1] & (mask << column)) != 0)
                {
                    break;
                }
                directionChange++;
            }

            //output
            if (weHaveTrack)
            {
                Console.WriteLine(trackLenght + " " + directionChange);
            }
            else
            {
                Console.WriteLine("No {0}", trackLenght);
            }
        }

        private static void MoveToTheNorth(int[] inputNumber, int column, ref int row, int mask, ref int trackLenght, ref bool weHaveTrack)
        {
            while (true)
            {
                int maskToAply = mask << column;
                if ((row < 0) || ((inputNumber[row] & maskToAply) != 0))
                {
                    break;
                }
                else
                {
                    row--;
                    trackLenght++;
                }
                if ((column == 7) && (row == 7))
                {
                    weHaveTrack = true;
                    break;
                }
            }
        }

        private static void MoveToTheWest(int[] inputNumber, ref int column, int row, int mask, ref int trackLenght, ref bool weHaveTrack)
        {
            while (true)
            {
                int maskToAply = mask << column;
                if ((column > 7) || ((inputNumber[row] & maskToAply) != 0))
                {
                    break;
                }
                else
                {
                    column++;
                    trackLenght++;
                }
                if ((column == 7) && (row == 7))
                {
                    weHaveTrack = true;
                    break;
                }
            }
        }

        private static void MoveToSouth(int[] inputNumber, int column, ref int row, int mask, ref int trackLenght, ref bool weHaveTrack)
        {
            while (true)
            {
                int maskToAply = mask << column;
                if ((row > 7) || ((inputNumber[row] & maskToAply) != 0))
                {
                    break;
                }
                else
                {
                    row++;
                    trackLenght++;
                }
                if ((column == 7) && (row == 7))
                {
                    weHaveTrack = true;
                    break;
                }
            }
        }
    }
}