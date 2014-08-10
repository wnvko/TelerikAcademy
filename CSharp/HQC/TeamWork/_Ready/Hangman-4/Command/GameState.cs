namespace HangMan.Command
{
    using System.Collections.Generic;
    using HangMan.EngineAndRenderer;

    /// <summary>
    /// Implements a gameState variable to contain the current state of the game.
    /// GetState method save the current state of the game in gameState variable.
    /// RestoreStateInEngine methd restores the game state based on the state parameter
    /// sent by function invoker as argument.
    /// </summary>
    internal class GameState
    {
        private IDictionary<string, string> gameState;

        public IDictionary<string, string> GetState()
        {
            string currentWord = Engine.Instance.CurrentWord;
            string playerWord = new string(Engine.Instance.PlayerWord);
            string mistakes = Engine.Instance.Mistakes.ToString();

            this.gameState = new Dictionary<string, string>()
            {
                { "word", currentWord },
                { "playersWord", playerWord },
                { "mistakes", mistakes }
            };

            return this.gameState;
        }

        public IDictionary<string, string> SetState()
        {
            return this.gameState;
        }

        public void RestoreStateInEngine(Dictionary<string, string> state)
        {
            string currentWord = state["word"];
            char[] playerWord = state["playersWord"].ToCharArray();
            int mistakes = int.Parse(state["mistakes"]);

            Engine.Instance.CurrentWord = currentWord;
            Engine.Instance.PlayerWord = playerWord;
            Engine.Instance.Mistakes = mistakes;
        }
    }
}