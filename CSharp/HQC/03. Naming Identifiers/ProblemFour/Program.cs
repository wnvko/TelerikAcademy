namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        public static void Main()
        {
            const int Max = 35;
            string command = string.Empty;
            char[,] playGround = PlayGround.PlaygroundInitialisation();
            char[,] mines = PlayGround.PutMines();
            int pointsCount = 0;
            bool isDead = false;
            List<Player> bestPlayers = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool newGame = true;
            bool isWinGame = false;

            do
            {
                if (newGame)
                {
                    Console.WriteLine("Let's play \"Mines\". Try to find all the mineless fields.");
                    Console.WriteLine("Menu:");
                    Console.WriteLine("- 'top' - shows current standings;");
                    Console.WriteLine("- 'restart' - starts new game;");
                    Console.WriteLine("- 'exit' - quit the game and Good Bye!");

                    PlayGround.DrawPlayGround(playGround);
                    newGame = false;
                }

                Console.Write("Enter row and col number [r c]: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    bool isRowOk = int.TryParse(command[0].ToString(), out row);
                    bool isColOk = int.TryParse(command[2].ToString(), out col);

                    if (isRowOk && isColOk)
                    {
                        if (row < playGround.GetLength(0) && col < playGround.GetLength(1) && row >= 0 && col >= 0)
                        {
                            command = "turn";
                        }
                    }
                }

                switch (command)
                {
                    case "top":
                        {
                            BestPlayersInitialization(bestPlayers);
                            break;
                        }

                    case "restart":
                        {
                            playGround = PlayGround.PlaygroundInitialisation();
                            mines = PlayGround.PutMines();
                            PlayGround.DrawPlayGround(playGround);
                            isDead = false;
                            newGame = false;
                            break;
                        }

                    case "exit":
                        {
                            Console.WriteLine("Good Buy!");
                            break;
                        }

                    case "turn":
                        {
                            if (mines[row, col] != '*')
                            {
                                if (mines[row, col] == '-')
                                {
                                    PlayerTurn(playGround, mines, row, col);
                                    pointsCount++;
                                }

                                if (Max == pointsCount)
                                {
                                    isWinGame = true;
                                }
                                else
                                {
                                    PlayGround.DrawPlayGround(playGround);
                                }
                            }
                            else
                            {
                                isDead = true;
                            }

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nInvalid command!\n");
                            break;
                        }
                }

                if (isDead)
                {
                    PlayGround.DrawPlayGround(mines);
                    Console.Write("\nHrrrrrr! Game Over - You Hit The Mine. You have {0} points.", pointsCount);
                    Console.WriteLine("Please enter your name: ");
                    string playerName = Console.ReadLine();
                    Player currentPlayer = new Player(playerName, pointsCount);

                    if (bestPlayers.Count < 5)
                    {
                        bestPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < bestPlayers.Count; i++)
                        {
                            if (bestPlayers[i].Points < currentPlayer.Points)
                            {
                                bestPlayers.Insert(i, currentPlayer);
                                bestPlayers.RemoveAt(bestPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    bestPlayers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    bestPlayers.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));

                    BestPlayersInitialization(bestPlayers);

                    playGround = PlayGround.PlaygroundInitialisation();
                    mines = PlayGround.PutMines();
                    pointsCount = 0;
                    isDead = false;
                    newGame = true;
                }

                if (isWinGame)
                {
                    Console.WriteLine("\nCONGRATULATIONS! You opene all 35 cells!");
                    PlayGround.DrawPlayGround(mines);
                    Console.WriteLine("What is your name, dude: ");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, pointsCount);
                    bestPlayers.Add(to4kii);
                    BestPlayersInitialization(bestPlayers);
                    playGround = PlayGround.PlaygroundInitialisation();
                    mines = PlayGround.PutMines();
                    pointsCount = 0;
                    isWinGame = false;
                    newGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("See you");
            Console.Read();
        }

        private static void BestPlayersInitialization(List<Player> players)
        {
            Console.WriteLine("\nPoints:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no saved scores yet!\n");
            }
        }

        private static void PlayerTurn(char[,] playGround, char[,] mines, int row, int col)
        {
            char surroundingMinesCount = PlayGround.SurroundingMinesCount(mines, row, col);
            mines[row, col] = surroundingMinesCount;
            playGround[row, col] = surroundingMinesCount;
        }
    }
}