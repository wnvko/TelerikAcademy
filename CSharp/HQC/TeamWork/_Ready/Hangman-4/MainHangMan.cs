namespace HangMan
{
    using System;
    using HangMan.EngineAndRenderer;
    using HangMan.Command;

    public class MainHangMan
    {
        public static void Main()
        {
            Engine game = Engine.Instance;
            game.GameLoop();
        }
    }
}