using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    class Program
    {
        public static void SumHiddenNumbers(int[,] matrix)
        {
            int result = 0;
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (matrix[i, j])
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                if (CheckOne(i, j, size, matrix))
                                {
                                    result += 1;
                                }
                                break;
                            }
                        case 2:
                            {
                                if (CheckTwo(i, j, size, matrix))
                                {
                                    result += 2;
                                }
                                break;
                            }
                        case 3:
                            {
                                if (CheckThree(i, j, size, matrix))
                                {
                                    result += 3;
                                }
                                break;
                            }
                        case 4:
                            {
                                if (CheckFour(i, j, size, matrix))
                                {
                                    result += 4;
                                }
                                break;
                            }
                        case 5:
                            {
                                if (CheckFive(i, j, size, matrix))
                                {
                                    result += 5;
                                }
                                break;
                            }
                        case 6:
                            {
                                if (CheckSix(i, j, size, matrix))
                                {
                                    result += 6;
                                }
                                break;
                            }
                        case 7:
                            {
                                if (CheckSeven(i, j, size, matrix))
                                {
                                    result += 7;
                                }
                                break;
                            }
                        case 8:
                            {
                                if (CheckEight(i, j, size, matrix))
                                {
                                    result += 8;
                                }
                                break;
                            }
                        case 9:
                            {
                                if (CheckNine(i, j, size, matrix))
                                {
                                    result += 9;
                                }
                                break;
                            }
                    }
                }
            }

            Console.WriteLine(result);
        }

        public static bool CheckOne(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j - 2 >= 0 &&
                matrix[i + 1, j] == 1 &&
                matrix[i + 2, j] == 1 &&
                matrix[i + 3, j] == 1 &&
                matrix[i + 4, j] == 1 &&
                matrix[i + 1, j - 1] == 1 &&
                matrix[i + 2, j - 2] == 1
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckTwo(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j - 1 >= 0 &&
                j + 1 < size &&
                matrix[i + 1, j - 1] == 2 &&
                matrix[i + 1, j + 1] == 2 &&
                matrix[i + 2, j + 1] == 2 &&
                matrix[i + 3, j] == 2 &&
                matrix[i + 4, j - 1] == 2 &&
                matrix[i + 4, j] == 2 &&
                matrix[i + 4, j + 1] == 2
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckThree(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 3 &&
                matrix[i, j + 2] == 3 &&
                matrix[i + 1, j + 2] == 3 &&
                matrix[i + 2, j + 1] == 3 &&
                matrix[i + 2, j + 2] == 3 &&
                matrix[i + 3, j + 2] == 3 &&
                matrix[i + 4, j] == 3 &&
                matrix[i + 4, j + 1] == 3 &&
                matrix[i + 4, j + 2] == 3
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckFour(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 2] == 4 &&
                matrix[i + 1, j] == 4 &&
                matrix[i + 1, j + 2] == 4 &&
                matrix[i + 2, j] == 4 &&
                matrix[i + 2, j + 1] == 4 &&
                matrix[i + 2, j + 2] == 4 &&
                matrix[i + 3, j + 2] == 4 &&
                matrix[i + 4, j + 2] == 4
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckFive(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 5 &&
                matrix[i, j + 2] == 5 &&
                matrix[i + 1, j] == 5 &&
                matrix[i + 2, j] == 5 &&
                matrix[i + 2, j + 1] == 5 &&
                matrix[i + 2, j + 2] == 5 &&
                matrix[i + 3, j + 2] == 5 &&
                matrix[i + 4, j] == 5 &&
                matrix[i + 4, j + 1] == 5 &&
                matrix[i + 4, j + 2] == 5
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckSix(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 6 &&
                matrix[i, j + 2] == 6 &&
                matrix[i + 1, j] == 6 &&
                matrix[i + 2, j] == 6 &&
                matrix[i + 2, j + 1] == 6 &&
                matrix[i + 2, j + 2] == 6 &&
                matrix[i + 3, j] == 6 &&
                matrix[i + 3, j + 2] == 6 &&
                matrix[i + 4, j] == 6 &&
                matrix[i + 4, j + 1] == 6 &&
                matrix[i + 4, j + 2] == 6
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckSeven(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 7 &&
                matrix[i, j + 2] == 7 &&
                matrix[i + 1, j + 2] == 7 &&
                matrix[i + 2, j + 1] == 7 &&
                matrix[i + 3, j + 1] == 7 &&
                matrix[i + 4, j + 1] == 7
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckEight(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 8 &&
                matrix[i, j + 2] == 8 &&
                matrix[i + 1, j] == 8 &&
                matrix[i + 1, j + 2] == 8 &&
                matrix[i + 2, j + 1] == 8 &&
                matrix[i + 3, j] == 8 &&
                matrix[i + 3, j + 2] == 8 &&
                matrix[i + 4, j] == 8 &&
                matrix[i + 4, j + 1] == 8 &&
                matrix[i + 4, j + 2] == 8
                )
            {
                return true;
            }

            return false;
        }

        public static bool CheckNine(int i, int j, int size, int[,] matrix)
        {
            if (i + 4 < size &&
                j + 2 < size &&
                matrix[i, j + 1] == 9 &&
                matrix[i, j + 2] == 9 &&
                matrix[i + 1, j] == 9 &&
                matrix[i + 1, j + 2] == 9 &&
                matrix[i + 2, j + 1] == 9 &&
                matrix[i + 2, j + 2] == 9 &&
                matrix[i + 3, j + 2] == 9 &&
                matrix[i + 4, j] == 9 &&
                matrix[i + 4, j + 1] == 9 &&
                matrix[i + 4, j + 2] == 9
                )
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[,] matrix = new int[lines, lines];

            for (int i = 0; i < lines; i++)
            {
                string[] currentLine = Console.ReadLine().Split(' ');

                for (int j = 0; j < lines; j++)
                {
                    matrix[i, j] = int.Parse(currentLine[j]);
                }
            }

            SumHiddenNumbers(matrix);

        }
    }
}
