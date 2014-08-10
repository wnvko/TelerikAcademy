using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HangMan.EngineAndRenderer;
using HangMan.Interfaces;
using HangMan.Messages;

// This attribute allows unit testing of Internal classes
[assembly: InternalsVisibleTo("HangMan-Tests")]

namespace HangMan.Command
{
    /// <summary>
    /// The 'Invoker' class. Creates a ConcreteCommand object and sets its receiver
    /// </summary>
    internal class GameCommandInvoker
    {
        private List<Command> commands;
        private ICommandReceiver gameCommandReciever;
        private int currentComand;
        private GameState gameState;
        private List<IDictionary<string, string>> gameStates;
        private IDictionary<string, string> savedState;
        private readonly IRenderer renderer;

        public GameCommandInvoker()
        {
            this.commands = new List<Command>();
            this.gameCommandReciever = new GameCommandReciever();
            this.currentComand = 0;
            this.gameState = new GameState();
            this.gameStates = new List<IDictionary<string, string>>();
            this.savedState = null;
            this.renderer = new ConsoleRenderer();
        }

        public void ExecuteCommand(string command)
        {
            if (this.IsCommandRedo(command))
            {
                if (this.currentComand < this.commands.Count)
                {
                    this.gameState.RestoreStateInEngine((Dictionary<string, string>)this.gameStates[this.currentComand]);
                    this.commands[this.currentComand].Execute();
                    this.currentComand++;
                    return;
                }

                var redoMsg = Message.GetMessage("redo");
                this.renderer.WriteMessage(redoMsg);
                return;
            }

            if (this.IsCommandUndo(command))
            {
                if (this.currentComand > 0)
                {
                    this.currentComand--;
                    this.gameState.RestoreStateInEngine((Dictionary<string, string>)this.gameStates[this.currentComand]);
                    var undoMsg = Message.GetMessage("undo");
                    this.renderer.WriteMessage(undoMsg);
                    return;
                }

                var noUndoMsg = Message.GetMessage("noUndo");
                this.renderer.WriteMessage(noUndoMsg);
                return;
            }

            // Save and Load opperation implements Memento design pattern
            if (this.IsCommandSave(command))
            {
                this.savedState = this.gameState.GetState();
                var saveMsg = Message.GetMessage("save");
                this.renderer.WriteMessage(saveMsg);
                return;
            }

            if (this.IsCommandLoad(command))
            {
                if (this.savedState != null)
                {
                    this.gameState.RestoreStateInEngine((Dictionary<string, string>)this.savedState);
                    var loadMsg = Message.GetMessage("load");
                    this.renderer.WriteMessage(loadMsg);
                    return;
                }

                var noLoadMsg = Message.GetMessage("noLoad");
                this.renderer.WriteMessage(noLoadMsg);
                return;
            }

            this.gameStates.Add(this.gameState.GetState());
            Command currentCommand = new GameCommand(this.gameCommandReciever, command);
            this.commands.Add(currentCommand);
            this.currentComand++;
        }

        private bool IsCommandRedo(string command)
        {
            if (command == "redo")
            {
                return true;
            }

            return false;
        }

        private bool IsCommandUndo(string command)
        {
            if (command == "undo")
            {
                return true;
            }

            return false;
        }

        private bool IsCommandSave(string command)
        {
            if (command == "save")
            {
                return true;
            }

            return false;
        }

        private bool IsCommandLoad(string command)
        {
            if (command == "load")
            {
                return true;
            }

            return false;
        }
    }
}