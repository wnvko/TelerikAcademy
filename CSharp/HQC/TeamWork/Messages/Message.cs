namespace HangMan.Messages
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Message
    {
        private static IDictionary<string, string> messages =

            new Dictionary<string, string>() 
            {
                { "greeting", "Welcome to Hangman" },
                { "howToPlay", "Use 'top' to view the top scoreboard, \n'restart' to start a new game, 'help' to cheat,\n 'undo' to undo last command, 'redo' to redo,\n 'save' to save game, 'load' to load game,\n and 'exit' to quit the game." },
                { "congratulations", "Congratulations! You guessed the word" },
                { "guessed", "You guessed {0} letters" },
                { "notFound", "Letter not found" },
                { "invalidCommand", "Invalid command" },
                { "congratulationsScoreBoard", "Congratulations! You made the scoreboard\nEnter your name: " },
                { "cheated", "You cheated" },
                { "promptForCommand", "Enter a letter or command: " },
                { "goodbye", "Goodby" },
                { "redo", "Nothing to Redo!"},
                { "undo", "Undo done"},
                { "noUndo", "Nothing to Undo!"},
                { "save", "Game saved"},
                { "load", "Game loaded"},
                { "noLoad", "No saved game to load from!"}
            };

        public static string GetMessage(string messageKey)
        {
            return Message.messages[messageKey];
        }
    }
}
