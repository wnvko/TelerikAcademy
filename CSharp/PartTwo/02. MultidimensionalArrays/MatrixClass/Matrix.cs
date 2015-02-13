namespace Matrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private int[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new int[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public int this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("The two matrix have to have same size!");
            }
            
            Matrix result = new Matrix(first.Rows, first.Cols);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = first[row, col] + second[row, col];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("The two matrix have to have same size!");
            }

            Matrix result = new Matrix(first.Rows, first.Cols);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = first[row, col] - second[row, col];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.Cols != second.Rows)
            {
                throw new ArgumentException("The number of columns in first matrix and number of rows in second matrix must be equal!");
            }

            Matrix result = new Matrix(first.Rows, second.Cols);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < second.Cols; col++)
                {
                    for (int sumIndex = 0; sumIndex < first.Cols; sumIndex++)
                    {
                        result[row, col] += first[row, sumIndex] * second[sumIndex, col];
                    }
                }
            }
            
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this[row, col]);
                    result.Append("\t");
                }

                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
