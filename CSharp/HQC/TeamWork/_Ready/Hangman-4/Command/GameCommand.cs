using System;
using System.Runtime.CompilerServices;
using HangMan.EngineAndRenderer;
using HangMan.Interfaces;

// this attribute allows unit testing of Internal classes
[assembly: InternalsVisibleTo("HangMan-Tests")]

namespace HangMan.Command
{
    /// <summary>
    /// The 'ConcreteCommand' class. Defines a binding between a Receiver object and an action.
    /// Implements Execute by invoking the corresponding operation(s) on Receiver
    /// </summary>
    internal class GameCommand : Command
    {
        private string command;

        public GameCommand(ICommandReceiver commandReciever, string command)
            : base(commandReciever)
        {
            this.command = command;
            this.Execute();
        }

        public override void Execute()
        {
            this.commandReciever.ExecuteCommand(this.command);
        }
    }
}
