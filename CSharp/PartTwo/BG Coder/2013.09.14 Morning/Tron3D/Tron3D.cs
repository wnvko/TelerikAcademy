/*
 * start 22:10
 * 0 points@23:50
 */

namespace tron3d
{
    using System;

    public class tron3d
    {
        public static int sizeX = 0;
        public static int sizeY = 0;
        public static int sizeZ = 0;
        public static bool[, ,] forbiden;

        public struct Pos
        {
            public int x;
            public int y;
            public int z;
            public string direction;

            public Pos(int x, int y, int z, string direction)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.direction = direction;
            }
        }

        public static Pos Move(Pos current)
        {
            int x = current.x;
            int y = current.y;
            int z = current.z;
            string dir = current.direction;

            if (dir == "xPos")
            {
                x++;
            }
            else if (dir == "xNeg")
            {
                x--;
            }
            else if (dir == "yPos")
            {
                y++;
            }
            else if (dir == "yNeg")
            {
                y--;
            }
            else if (dir == "zPos")
            {
                z++;
            }
            else if (dir == "zNeg")
            {
                z--;
            }

            Pos newpos = new Pos(x, y, z, dir);
            newpos = EdgeCrossing(newpos);
            return newpos;
        }

        public static Pos EdgeCrossing(Pos current)
        {
            Pos changed = current;
            if (changed.z < 0 && changed.y == 0)
            {
                changed.y++;
                changed.z++;
                changed.direction = "yPos";
            }
            else if (changed.z < 0 && changed.y == sizeY - 1)
            {
                changed.y--;
                changed.z++;
                changed.direction = "yNeg";
            }
            else if (changed.z > sizeZ - 1 && changed.y == 0)
            {
                changed.y++;
                changed.z--;
                changed.direction = "yPos";
            }
            else if (changed.z > sizeZ - 1 && changed.y == sizeY - 1)
            {
                changed.y--;
                changed.z--;
                changed.direction = "yNeg";
            }
            else if (changed.y < 0 && changed.z == 0)
            {
                changed.y++;
                changed.z++;
                changed.direction = "zPos";
            }
            else if (changed.y > sizeY - 1 && changed.z == 0)
            {
                changed.y--;
                changed.z++;
                changed.direction = "zPos";
            }
            else if (changed.y < 0 && changed.z == sizeZ - 1)
            {
                changed.y++;
                changed.z--;
                changed.direction = "zNeg";
            }
            else if (changed.y > sizeY - 1 && changed.z == sizeZ - 1)
            {
                changed.y--;
                changed.z--;
                changed.direction = "zNeg";
            }

            return changed;
        }

        public static string Left(Pos current)
        {
            string dir = current.direction;
            string newDir = string.Empty;
            if (dir == "xPos")
            {
                if (current.y == 0)
                {
                    if (current.z < sizeZ - 1)
                    {
                        newDir = "zPos";
                    }
                    else if (current.z >= sizeZ - 1)
                    {
                        newDir = "yPos";
                    }
                }
                else if (current.y == sizeY - 1)
                {
                    if (current.z <= sizeZ - 1)
                    {
                        newDir = "zNeg";
                    }
                    else if (current.z == 0)
                    {
                        newDir = "yNeg";
                    }
                }
                else if (current.z == 0)
                {
                    newDir = "yNeg";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "yPos";
                }
            }
            else if (dir == "xNeg")
            {
                if (current.y == 0)
                {
                    if (current.z > 0)
                    {
                        newDir = "zNeg";
                    }
                    else if (current.z == 0)
                    {
                        newDir = "yPos";
                    }
                }
                else if (current.y == sizeY - 1)
                {
                    if (current.z <= sizeZ - 1)
                    {
                        newDir = "zPos";
                    }
                    else if (current.z == sizeZ - 1)
                    {
                        newDir = "yNeg";
                    }
                }
                else if (current.z == 0)
                {
                    newDir = "yPos";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "yNeg";
                }
            }
            else if (dir == "yPos" || dir == "zPos")
            {
                newDir = "xPos";
            }
            else if (dir == "yNeg" || dir == "zNeg")
            {
                newDir = "xNeg";
            }
            return newDir;
        }

        public static string Right(Pos current)
        {
            string dir = current.direction;
            string newDir = string.Empty;
            if (dir == "xPos")
            {
                if (current.y == 0)
                {
                    if (current.z > 0)
                    {
                        newDir = "zNeg";
                    }
                    else if (current.z == 0)
                    {
                        newDir = "yPos";
                    }
                }
                else if (current.y == sizeY - 1)
                {
                    if (current.z < sizeZ - 1)
                    {
                        newDir = "zPos";
                    }
                    else if (current.z == sizeZ - 1)
                    {
                        newDir = "yNeg";
                    }
                }
                else if (current.z == 0)
                {
                    newDir = "yPos";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "yNeg";
                }
            }
            else if (dir == "xNeg")
            {
                if (current.y == 0)
                {
                    if (current.z < sizeZ - 1)
                    {
                        newDir = "zPos";
                    }
                    else if (current.z == sizeZ - 1)
                    {
                        newDir = "yPos";
                    }
                }
                else if (current.y == sizeY - 1)
                {
                    if (current.z > 0)
                    {
                        newDir = "zNeg";
                    }
                    else if (current.z == 0)
                    {
                        newDir = "yNeg";
                    }
                }
                else if (current.z == 0)
                {
                    newDir = "yNeg";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "yPos";
                }
            }
            else if (dir == "yPos")
            {
                if (current.z == 0)
                {
                    newDir = "xNeg";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "xPos";
                }
            }
            else if (dir == "yNeg")
            {
                if (current.z == 0)
                {
                    newDir = "xPos";
                }
                else if (current.z == sizeZ - 1)
                {
                    newDir = "xNeg";
                }
            }
            else if (dir == "zPos")
            {
                if (current.y == 0)
                {
                    newDir = "xPos";
                }
                else if (current.y == sizeY - 1)
                {
                    newDir = "xNeg";
                }
            }
            else if (dir == "zNeg")
            {
                if (current.y == 0)
                {
                    newDir = "xNeg";
                }
                else if (current.y == sizeY - 1)
                {
                    newDir = "xPos";
                }
            }

            return newDir;
        }

        public static bool CheckPosition(Pos current)
        {
            bool isForbiden = false;
            int currentX = current.x;
            int currentY = current.y;
            int currentZ = current.z;

            if (currentX < 0 || currentX > sizeX - 1)
            {
                isForbiden = true;
                return isForbiden;
            } 
            
            if (forbiden[currentX, currentY, currentZ])
            {
                isForbiden = true;
            }

            

            return isForbiden;
        }
        public static void Main()
        {

            string matrixsize = Console.ReadLine();
            string[] xyz = matrixsize.Split(' ');

            sizeX = int.Parse(xyz[0]) + 1;
            sizeY = int.Parse(xyz[1]) + 1;
            sizeZ = int.Parse(xyz[2]) + 1;

            string redCourse = Console.ReadLine();
            string blueCourse = Console.ReadLine();

            Pos redPos = new Pos(sizeX / 2, sizeY / 2, 0, "yPos");
            Pos bluePos = new Pos(sizeX / 2, sizeY / 2, sizeZ - 1, "yPos");

            int r = 0;
            int b = 0;

            bool redIsOver = false;
            bool blueIsOver = false;

            string gameWinner = string.Empty;
            int redDistance = 0;

            forbiden = new bool[sizeX, sizeY, sizeZ];

            while (true)
            {
                if (r < redCourse.Length && b < blueCourse.Length && redCourse[r] == 'M' && blueCourse[b] == 'M')
                {
                    forbiden[redPos.x, redPos.y, redPos.z] = true;
                    forbiden[bluePos.x, bluePos.y, bluePos.z] = true;

                    redPos = Move(redPos);
                    r++;
                    bluePos = Move(bluePos);
                    b++;

                    redIsOver = CheckPosition(redPos);
                    blueIsOver = CheckPosition(bluePos);

                    if (gameWinner == string.Empty)
                    {
                        if (redPos.x == bluePos.x && redPos.y == bluePos.y && redPos.z == bluePos.z)
                        {
                            redIsOver = true;
                            blueIsOver = true;
                            gameWinner = "DRAW";
                            break;
                        }

                        if (redIsOver || redPos.x > sizeX - 1 || redPos.x < 0)
                        {
                            gameWinner = "BLUE";
                            break;
                        }

                        if (blueIsOver || bluePos.x > sizeX - 1 || bluePos.x < 0)
                        {
                            gameWinner = "RED";
                            break;
                        }
                    }
                }

                if (r < redCourse.Length && redCourse[r] == 'M' && b >= blueCourse.Length)
                {
                    forbiden[redPos.x, redPos.y, redPos.z] = true;

                    redPos = Move(redPos);
                    r++;

                    redIsOver = CheckPosition(redPos);
                    if (gameWinner == string.Empty)
                    {
                        if (redPos.x == bluePos.x && redPos.y == bluePos.y && redPos.z == bluePos.z)
                        {
                            redIsOver = true;
                            blueIsOver = true;
                            gameWinner = "DRAW";
                            break;
                        }

                        if (redIsOver)
                        {
                            gameWinner = "BLUE";
                            break;
                        }
                    }
                }

                if (r >= redCourse.Length && b < blueCourse.Length && blueCourse[b] == 'M')
                {
                    forbiden[bluePos.x, bluePos.y, bluePos.z] = true;

                    bluePos = Move(bluePos);
                    b++;

                    blueIsOver = CheckPosition(bluePos);

                    if (gameWinner == string.Empty)
                    {
                        if (redPos.x == bluePos.x && redPos.y == bluePos.y && redPos.z == bluePos.z)
                        {
                            redIsOver = true;
                            blueIsOver = true;
                            gameWinner = "DRAW";
                            break;
                        }

                        if (blueIsOver)
                        {
                            gameWinner = "RED";
                            break;
                        }
                    }
                }

                if (r < redCourse.Length && redCourse[r] == 'R')
                {
                    redPos.direction = Right(redPos);
                    r++;
                }

                if (r < redCourse.Length && redCourse[r] == 'L')
                {
                    redPos.direction = Left(redPos);
                    r++;
                }

                if (b < blueCourse.Length && blueCourse[b] == 'R')
                {
                    bluePos.direction = Right(bluePos);
                    b++;
                }

                if (b < blueCourse.Length && blueCourse[b] == 'L')
                {
                    bluePos.direction = Left(bluePos);
                    b++;
                }

                if (gameWinner != string.Empty)
                {
                    if (b >= blueCourse.Length && r >= redCourse.Length)
                    {
                        gameWinner = "DRAW";
                        break;
                    }
                }
            }

            Console.WriteLine(gameWinner);

            redDistance += Math.Abs(sizeX / 2 - redPos.x);
            redDistance += Math.Abs(sizeY / 2 - redPos.y);
            redDistance += Math.Abs(redPos.z);
            Console.WriteLine(redDistance);
        }
    }
}