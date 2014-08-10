using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HangMan.EngineAndRenderer;
using HangMan.Interfaces;

// This attribute allows unit testing of Internal classes
[assembly: InternalsVisibleTo("HangMan-Tests")]

namespace HangMan.Command
{
    /// <summary>
    /// Knows how to perform and perform the operations associated with carrying out the request.
    /// </summary>
    internal class GameCommandReciever : ICommandReceiver
    {
        public void ExecuteCommand(string command)
        {            
            if (command.Length == 1)
            {
                 Engine.Instance.Guess(command[0]);
                 Engine.Instance.CheckIfMustEndGame();
            }
            else
            {
                switch (command)
                {
                    case "top":
                        {
                            Engine.Instance.ShowScoreboard();
                            break;
                        }

                    case "help":
                        {
                            Engine.Instance.Help();
                            Engine.Instance.CheckIfMustEndGame();
                            break;
                        }

                    case "restart":
                        {
                            Engine.Instance.Restart();
                            break;
                        }

                    case "exit":
                        {
                            Engine.Instance.QuitTheGame();
                            break;
                        }

                    default:
                        {
                            
                            break;
                        }
                }
            }
        }
    }
}
