using System;
using System.Collections.Generic;

public struct Coordinate
{
    public int Row;
    public int Col;

    public Coordinate(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }
}

public class Labyrinth
{
    private static Random rnd = new Random();

    public static string[,] GenerateLabyrinth(int rows, int cols)
    {
        string[,] labyrinth = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (rnd.Next(10) > 3)
                {
                    labyrinth[row, col] = "0";
                }
                else
                {
                    labyrinth[row, col] = "X";
                }
            }
        }

        return labyrinth;
    }

    public static void PrintLabyrinth(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write("{0} ", labyrinth[row, col]);
            }

            Console.WriteLine();
        }
    }

    public static string[,] SolveLabyrinth(string[,] labyrinth, int startRow, int startCol)
    {
        bool[,] visited = new bool[labyrinth.GetLength(0), labyrinth.GetLength(1)];
        labyrinth[startRow, startCol] = "*";
        Queue<Coordinate> path = new Queue<Coordinate>();
        path.Enqueue(new Coordinate(startRow, startCol));

        while (path.Count > 0)
        {
            Coordinate currentPosition = path.Dequeue();
            if (CheckNeightbour("left", currentPosition.Row, currentPosition.Col, labyrinth, visited))
            {
                if (labyrinth[currentPosition.Row, currentPosition.Col] == "*")
                {
                    labyrinth[currentPosition.Row, currentPosition.Col - 1] = "1";
                }
                else
                {
                    int current = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col]);
                    int next = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col - 1]);
                    next = ++current;
                    labyrinth[currentPosition.Row, currentPosition.Col - 1] = next.ToString();
                }

                visited[currentPosition.Row, currentPosition.Col - 1] = true;
                path.Enqueue(new Coordinate(currentPosition.Row, currentPosition.Col - 1));
            }

            if (CheckNeightbour("right", currentPosition.Row, currentPosition.Col, labyrinth, visited))
            {
                if (labyrinth[currentPosition.Row, currentPosition.Col] == "*")
                {
                    labyrinth[currentPosition.Row, currentPosition.Col + 1] = "1";
                }
                else
                {
                    int current = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col]);
                    int next = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col + 1]);
                    next = ++current;
                    labyrinth[currentPosition.Row, currentPosition.Col + 1] = next.ToString();
                }

                visited[currentPosition.Row, currentPosition.Col + 1] = true;
                path.Enqueue(new Coordinate(currentPosition.Row, currentPosition.Col + 1));
            }

            if (CheckNeightbour("up", currentPosition.Row, currentPosition.Col, labyrinth, visited))
            {
                if (labyrinth[currentPosition.Row, currentPosition.Col] == "*")
                {
                    labyrinth[currentPosition.Row - 1, currentPosition.Col] = "1";
                }
                else
                {
                    int current = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col]);
                    int next = int.Parse(labyrinth[currentPosition.Row - 1, currentPosition.Col]);
                    next = ++current;
                    labyrinth[currentPosition.Row - 1, currentPosition.Col] = next.ToString();
                }

                visited[currentPosition.Row - 1, currentPosition.Col] = true;
                path.Enqueue(new Coordinate(currentPosition.Row - 1, currentPosition.Col));
            }

            if (CheckNeightbour("down", currentPosition.Row, currentPosition.Col, labyrinth, visited))
            {
                if (labyrinth[currentPosition.Row, currentPosition.Col] == "*")
                {
                    labyrinth[currentPosition.Row + 1, currentPosition.Col] = "1";
                }
                else
                {
                    int current = int.Parse(labyrinth[currentPosition.Row, currentPosition.Col]);
                    int next = int.Parse(labyrinth[currentPosition.Row + 1, currentPosition.Col]);
                    next = ++current;
                    labyrinth[currentPosition.Row + 1, currentPosition.Col] = next.ToString();
                }

                visited[currentPosition.Row + 1, currentPosition.Col] = true;
                path.Enqueue(new Coordinate(currentPosition.Row + 1, currentPosition.Col));
            }
        }

        return labyrinth;
    }

    public static bool CheckNeightbour(string direction, int row, int col, string[,] labyrinth, bool[,] visited)
    {
        bool result = true;

        switch (direction)
        {
            case "left":
                {
                    if ((col - 1 < 0) || visited[row, col - 1] || (labyrinth[row, col - 1] == "X") || (labyrinth[row, col - 1] == "*"))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }

                    break;
                }

            case "right":
                {
                    if ((col + 1 >= labyrinth.GetLength(0)) || visited[row, col + 1] || (labyrinth[row, col + 1] == "X") || (labyrinth[row, col + 1] == "*"))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }

                    break;
                }

            case "down":
                {
                    if ((row + 1 >= labyrinth.GetLength(1)) || visited[row + 1, col] || (labyrinth[row + 1, col] == "X") || (labyrinth[row + 1, col] == "*"))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }

                    break;
                }

            case "up":
                {
                    if ((row - 1 < 0) || visited[row - 1, col] || (labyrinth[row - 1, col] == "X") || (labyrinth[row - 1, col] == "*"))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }

                    break;
                }
        }

        return result;
    }

    public static string[,] Unreachable(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == "0")
                {
                    labyrinth[row, col] = "U";
                }
            }
        }

        return labyrinth;
    }

    public static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of cols: ");
        int cols = int.Parse(Console.ReadLine());

        string[,] labyrinth = GenerateLabyrinth(rows, cols);
        Console.WriteLine("\nInitial labyrinth\n");
        PrintLabyrinth(labyrinth);

        int startRow = rnd.Next(rows);
        int startCol = rnd.Next(cols);

        labyrinth = SolveLabyrinth(labyrinth, startRow, startCol);
        labyrinth = Unreachable(labyrinth);

        Console.WriteLine("\nSolved labyrinth\n");
        PrintLabyrinth(labyrinth);
    }
}