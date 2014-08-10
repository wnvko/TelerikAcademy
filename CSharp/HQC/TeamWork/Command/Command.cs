using HangMan.Interfaces;

namespace HangMan.Command
{
    /// <summary>
    /// Base abstract class 'Command'. Serve as a contract for the inherited command classes with two methods, redo and Undo.
    /// These methods are to be implemented in the concrete classes, and will contain references to the client class.
    /// </summary>
    internal abstract class Command
    {
        protected ICommandReceiver commandReciever;

        public Command(ICommandReceiver commandReciever)
        {
            this.commandReciever = commandReciever;
        }

        public abstract void Execute();
    }
}