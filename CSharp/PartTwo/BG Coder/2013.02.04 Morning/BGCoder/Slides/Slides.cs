using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Slides
{
    public class Slides
    {
        public static void GenerateMatrix(string[] plates, string[, ,] matrix)
        {
            int size = plates.Length;
            char[] verticalSynbol = new char[1] { '|' };
            char[] brackets = new char[2] { '(', ')' };
            for (int i = 0; i < size; i++)
            {
                string[] lines = plates[i].Split(verticalSynbol, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {

                    lines[j] = lines[j].Trim();
                    string[] coordinates = lines[j].Split(brackets, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < size; k++)
                    {
                        coordinates[k] = coordinates[k].Trim();
                        matrix[k, j, i] = coordinates[k];
                    }
                    //int k = 0;
                    //Regex rx = new Regex(@"(?<=\()[\w\s]+");
                    //foreach (var match in rx.Matches(lines[j]))
                    //{
                    //    matrix[k, j, i] = match.ToString();
                    //    k++;
                    //}
                }
            }
        }

        public static void MoveTheBall(string[, ,] matrix, int startX, int startY)
        {
            Cor ball = new Cor(startX, startY, 0);
            int size = matrix.GetLength(0);
            string box = string.Empty;
            string result = string.Empty;
            while (true)
            {
                Cor temp = ball;
                box = matrix[temp.X, temp.Y, temp.Z];
                box = box.Trim();
                if (box[0] == 'S')
                {
                    box = box.Replace(" ", string.Empty);
                    if (temp.Z == size - 1)
                    {
                        result = "Yes\n" + temp.X + " " + temp.Z + " " + temp.Y;
                        break;
                    }

                    if (box.Length > 2)
                    {
                        string test = box[1].ToString() + box[2];
                        switch (test)
                        {
                            case "LF":
                                {
                                    temp.X--;
                                    temp.Y--;
                                    break;
                                }
                            case "LB":
                                {
                                    temp.X--;
                                    temp.Y++;
                                    break;
                                }
                            case "RF":
                                {
                                    temp.X++;
                                    temp.Y--;
                                    break;
                                }
                            case "RB":
                                {
                                    temp.X++;
                                    temp.Y++;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        string test = box[1].ToString();
                        switch (test)
                        {
                            case "L":
                                {
                                    temp.X--;
                                    break;
                                }
                            case "B":
                                {
                                    temp.Y++;
                                    break;
                                }
                            case "R":
                                {
                                    temp.X++;
                                    break;
                                }
                            case "F":
                                {
                                    temp.Y--;
                                    break;
                                }
                        }
                    }

                    temp.Z++;
                    if (temp.X < 0 || temp.Y < 0 || temp.X > size - 1 || temp.Y > size - 1)
                    {
                        result = "No\n" + ball.X + " " + ball.Z + " " + ball.Y;
                        break;
                    }

                    ball = temp;
                }
                else if (box[0] == 'T')
                {
                    box = box.Remove(0, 1);
                    char[] empty = new char[1] { ' ' };
                    string[] teleport = box.Split(empty, StringSplitOptions.RemoveEmptyEntries);
                    temp.X = int.Parse(teleport[0].ToString());
                    temp.Y = int.Parse(teleport[1].ToString());
                    ball = temp;
                }
                else if (box[0] == 'E')
                {
                    if (temp.Z == size - 1)
                    {
                        result = "Yes\n" + ball.X + " " + ball.Z + " " + ball.Y;
                        break;
                    }

                    temp.Z++;
                    ball = temp;
                }
                else if (box[0] == 'B')
                {
                    result = "No\n" + ball.X + " " + ball.Z + " " + ball.Y;
                    break;
                }
            }

            Console.WriteLine(result);
        }



        public static void Main()
        {
            string cubeSize = Console.ReadLine();
            string[] sizes = cubeSize.Split(' ');
            int width = int.Parse(sizes[0]);
            int height = width;
            int depth = width;
            string[] boxes = new string[width];

            for (int i = 0; i < width; i++)
            {
                boxes[i] = Console.ReadLine();
            }

            string[, ,] matrix = new string[width, height, depth];
            GenerateMatrix(boxes, matrix);

            string starts = Console.ReadLine();
            string[] start = starts.Split(' ');
            int startX = int.Parse(start[0]);
            int startY = int.Parse(start[1]);

            MoveTheBall(matrix, startX, startY);
        }

        public struct Cor
        {
            private int x;
            private int y;
            private int z;
            public Cor(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public int X { get { return x; } set { x = value; } }
            public int Y { get { return y; } set { y = value; } }
            public int Z { get { return z; } set { z = value; } }
        }
    }
}