namespace MatrixAssembly
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable<T>
    {
        private T[,] matrixHolder;

        // Constructors
        public Matrix(int rows, int cols)
        {
            this.MatrixHolder = new T[rows, cols];
        }

        public Matrix(int rows, int cols, T[,] matrix)
            : this(rows, cols)
        {
            this.MatrixHolder = matrix;
        }

        // Properties
        public T[,] MatrixHolder
        {
            get { return this.matrixHolder; }
            private set { this.matrixHolder = value; }
        }

        // Indexers
        public T this[int row, int col]
        {
            get
            {
                if (row >= 0 && row < this.MatrixHolder.GetLength(0) &&
                    col >= 0 && col < this.MatrixHolder.GetLength(1))
                {
                    return this.MatrixHolder[row, col];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
            }

            set
            {
                if (row >= 0 && row < this.MatrixHolder.GetLength(0) &&
                    col >= 0 && col < this.MatrixHolder.GetLength(1))
                {
                    this.MatrixHolder[row, col] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
            }
        }

        // Methods
        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrixHolder.GetLength(0);
            int colB = matrixB.matrixHolder.GetLength(1);
            if (rowA != rowB || colA != colB)
            {
                throw new ArgumentException("Cannot sum matrix of different size.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colA);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colA; col++)
                    {
                        dynamic valueA = matrixA[row, col];
                        dynamic valueB = matrixB[row, col];

                        resultMatrix[row, col] = valueA + valueB;
                    }
                }

                return resultMatrix;
            }
        }

        public static Matrix<T> operator -(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrixHolder.GetLength(0);
            int colB = matrixB.matrixHolder.GetLength(1);
            if (rowA != rowB || colA != colB)
            {
                throw new ArgumentException("Cannot subtract matrix of different size.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colA);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colA; col++)
                    {
                        dynamic valueA = matrixA[row, col];
                        dynamic valueB = matrixB[row, col];

                        resultMatrix[row, col] = valueA - valueB;
                    }
                }

                return resultMatrix;
            }
        }

        public static Matrix<T> operator *(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrixHolder.GetLength(0);
            int colB = matrixB.matrixHolder.GetLength(1);
            if (colA != rowB)
            {
                throw new ArgumentException("Cannot multiply matrix of wrong size. !st matrix cols must equal second matrix rows.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colB);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colB; col++)
                    {
                        for (int sumIndex = 0; sumIndex < colA; sumIndex++)
                        {
                            dynamic valueA = matrixA[row, sumIndex];
                            dynamic valueB = matrixB[sumIndex, col];
                            resultMatrix[row, col] += valueA * valueB;
                        }
                    }
                }

                return resultMatrix;
            }
        }

        public static bool operator true (Matrix<T> matrixToCheck)
        {
            for (int row = 0; row < matrixToCheck.MatrixHolder.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToCheck.MatrixHolder.GetLength(1); col++)
                {
                    if ((dynamic)matrixToCheck[row,col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrixToCheck)
        {
            for (int row = 0; row < matrixToCheck.MatrixHolder.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToCheck.MatrixHolder.GetLength(1); col++)
                {
                    if ((dynamic)matrixToCheck[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Matrix {0}x{1}", this.MatrixHolder.GetLength(0), this.MatrixHolder.GetLength(1)));
            result.Append(Environment.NewLine);

            for (int row = 0; row < this.MatrixHolder.GetLength(0); row++)
            {
                result.Append("[");
                for (int col = 0; col < this.MatrixHolder.GetLength(1); col++)
                {
                    result.Append(string.Format("{0}, ", this[row, col]));
                }

                result.Remove(result.Length - 2, 2);
                result.Append("]");
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}