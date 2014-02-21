using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PriblemTwo
{
    class Program
    {
        public static void StartPlaying(ulong[] path)
        {
            BigInteger mollyScore = 0;
            int mollyPossition = 0;
            bool gameOver = false;
            BigInteger dollyScore = 0;
            int dollyPossition = path.Length - 1;
            string result = string.Empty;
            string molly = string.Empty;
            string dolly = string.Empty;

            while (true)
            {
                ulong pathL = (ulong)path.Length;
                int tempMove = 0;
                if (mollyPossition == dollyPossition)
                {
                    if (path[mollyPossition] == 0)
                    {
                        result = "Draw";
                        break;
                    }
                    else
                    {
                        if (path[mollyPossition] % 2 == 0)
                        {
                            mollyScore += path[mollyPossition] / 2;
                            tempMove = (int)(path[mollyPossition] % pathL);
                            mollyPossition += tempMove;

                            dollyScore += path[dollyPossition] / 2;
                            dollyPossition -= tempMove;

                            path[mollyPossition] = 0;
                        }
                        else
                        {
                            mollyScore += path[mollyPossition] / 2;
                            tempMove = (int)(path[mollyPossition] % pathL);
                            mollyPossition += tempMove;

                            dollyScore += path[dollyPossition] / 2;
                            dollyPossition -= tempMove;

                            if (mollyPossition > (int)pathL - 1)
                            {
                                mollyPossition = mollyPossition - (int)pathL;
                            }

                            path[mollyPossition] = 1;
                        }
                    }
                }
                else
                {
                    if (path[mollyPossition] == 0)
                    {
                        dolly = "Dolly";
                        result = "Dolly";
                        gameOver = true;
                    }
                    else
                    {
                        mollyScore += path[mollyPossition];
                        tempMove = (int)(path[mollyPossition] % pathL);
                        path[mollyPossition] = 0;
                        mollyPossition += tempMove;
                    }

                    if (path[dollyPossition] == 0)
                    {
                        molly = "Molly";
                        result = "Molly";
                        gameOver = true;
                    }
                    else
                    {
                        dollyScore += path[dollyPossition];
                        tempMove = (int)(path[dollyPossition] % pathL);
                        path[dollyPossition] = 0;
                        dollyPossition -= tempMove;
                    }
                }

                if (mollyPossition > (int)pathL-1)
                {
                    mollyPossition = mollyPossition - (int)pathL;
                }

                if (dollyPossition < 0)
                {
                    dollyPossition = dollyPossition + (int)pathL;
                }

                if (gameOver)
                {
                    break;
                }
            }

            if (molly != string.Empty && dolly != string.Empty)
            {
                result = "Draw";
            }

            Console.WriteLine(result);
            Console.WriteLine("{0} {1}",mollyScore,dollyScore);
        }

        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string[] pathAsString = inputPath.Split(' ');
            ulong[] pathSquares = new ulong[pathAsString.Length];
            for (int i = 0; i < pathAsString.Length; i++)
            {
                pathSquares[i] = ulong.Parse(pathAsString[i]);
            }
            StartPlaying(pathSquares);
        }
    }
}
