namespace PrintMatrixSpiral
{
    using System;

    class PrintMatrixSpiral
    {
        static void Main()
        {
            /*
             * * Write a program that reads a positive integer number N (N < 20)
             * from console and outputs in the console the numbers 1 ... N numbers
             * arranged as a spiral.
             * 
             * Example for N = 4
             * 
             *  1  2  3  4
             * 12 13 14  5
             * 11 16 15  6
             * 10  9  8  7
             */
            
            Console.Write("Enter N: ");
            int inputNumber = int.Parse(Console.ReadLine());

            int finalNumber = inputNumber * inputNumber;
            int[,] matrix = new int[inputNumber, inputNumber];
            int row = 0;
            int column = 0;
            int currentNumber = 0;

            while (true)
            {
                //print numbers right
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    } 
                    
                    matrix[row, column] = currentNumber;
                    column++;
                    
                    if ((column > inputNumber - 1) || (matrix[row, column] != 0))
                    {
                        column--;
                        break;
                    }
                }
                row++;

                //print numbers down
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    } 
                    
                    matrix[row, column] = currentNumber;
                    row++;
                    
                    if ((row > inputNumber - 1) || (matrix[row, column] != 0))
                    {
                        row--;
                        break;
                    }
                }
                column--;
                
                //print numbers left
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    }

                    matrix[row, column] = currentNumber;
                    column--;
                    
                    if ((column < 0) || (matrix[row, column] != 0))
                    {
                        column++;
                        break;
                    }
                }
                row--;

                //print numbers up
                while (true)
                {
                    currentNumber++;
                    if (currentNumber > finalNumber)
                    {
                        break;
                    } 
                    
                    matrix[row, column] = currentNumber;
                    row--;
                    
                    if ((row < 0) || (matrix[row, column] != 0))
                    {
                        row++;
                        break;
                    }
                }
                if (currentNumber >= finalNumber)
                {
                    break;
                }
                column++;
            }
            
            //print the matrix
            for (int i = 0; i < inputNumber; i++)
            {
                Console.Write("|");
                for (int j = 0; j < inputNumber; j++)
                {
                    Console.Write("{0:000}|", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}