namespace TheMatrix
{
    using System;

    public class Test
    {
        public static void Main()
        {
            Matrix<double> matrixA = new Matrix<double>(2, 3);
            Console.WriteLine(matrixA.MinValue);
            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[0, 2] = 5;
            matrixA[1, 0] = 0;
            matrixA[1, 1] = 3;
            matrixA[1, 2] = 4;
            Console.WriteLine(matrixA);
            if (matrixA)
            {
                Console.WriteLine("No zero values");
            }
            else
            {
                Console.WriteLine("Have zero values");

            }

            Matrix<int> matrixB = new Matrix<int>(2, 3);
            matrixB[0, 0] = 3;
            matrixB[0, 1] = 9;
            matrixB[0, 2] = 8;
            matrixB[1, 0] = 1;
            matrixB[1, 1] = 0;
            matrixB[1, 2] = -2;
            Console.WriteLine(matrixB);

            Matrix<int> matrixC = new Matrix<int>(3, 2);
            matrixC[0, 0] = 3;
            matrixC[0, 1] = 9;
            matrixC[1, 0] = 8;
            matrixC[1, 1] = 1;
            matrixC[2, 0] = 0;
            matrixC[2, 1] = -2;
            Console.WriteLine(matrixC);

            //Matrix<int> sumMatrix = matrixA + matrixB;
            //Matrix<int> differenceMatrix = matrixA - matrixB;
            //Matrix<int> productMatrix = matrixA * matrixC;
            //Console.WriteLine(sumMatrix);
            //Console.WriteLine(differenceMatrix);
            //Console.WriteLine(productMatrix);

            Console.WriteLine(matrixA.MinValue);
        }
    }
}
