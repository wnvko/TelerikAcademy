namespace HangMan_Tests
{
    using System;
    using System.Collections.Generic;
    using HangMan.Command;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTests
    {
        private GameCommandInvoker testInvoker = new GameCommandInvoker();
        private GameState gameState = new GameState();

        [TestMethod]
        public void GameCommandInvokerExecuteRedoWithNoUndo()
        {
            this.testInvoker.ExecuteCommand("a");
            this.testInvoker.ExecuteCommand("e");
            this.testInvoker.ExecuteCommand("top");

            var beforeRedo = this.gameState.GetState();

            this.testInvoker.ExecuteCommand("redo");
            var afterRedo = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeRedo, afterRedo);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GameCommandInvokerExecuteRedo()
        {
            this.testInvoker.ExecuteCommand("a");
            this.testInvoker.ExecuteCommand("e");
            this.testInvoker.ExecuteCommand("top");

            var beforeUndo = this.gameState.GetState();
            this.testInvoker.ExecuteCommand("undo");

            this.testInvoker.ExecuteCommand("redo");
            var afterRedo = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeUndo, afterRedo);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GameCommandInvokerExecuteUndo()
        {
            this.testInvoker.ExecuteCommand("a");
            this.testInvoker.ExecuteCommand("e");

            var beforeUndo = this.gameState.GetState();
            this.testInvoker.ExecuteCommand("p");

            this.testInvoker.ExecuteCommand("undo");
            var afterUndo = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeUndo, afterUndo);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GameCommandInvokerExecuteUndoWithNothingToUndo()
        {
            var beforeUndo = this.gameState.GetState();

            this.testInvoker.ExecuteCommand("undo");
            var afterUndo = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeUndo, afterUndo);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GameCommandInvokerExecuteLoad()
        {
            this.testInvoker.ExecuteCommand("a");
            this.testInvoker.ExecuteCommand("c");

            var beforeLoad = this.gameState.GetState();
            this.testInvoker.ExecuteCommand("save");

            this.testInvoker.ExecuteCommand("p");
            this.testInvoker.ExecuteCommand("i");

            this.testInvoker.ExecuteCommand("load");
            var afterLoad = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeLoad, afterLoad);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GameCommandInvokerExecuteLoadWithNothingToLoad()
        {
            this.testInvoker.ExecuteCommand("a");
            this.testInvoker.ExecuteCommand("c");
            this.testInvoker.ExecuteCommand("i");
            this.testInvoker.ExecuteCommand("load");

            var beforeLoad = this.gameState.GetState();
            var afterLoad = this.gameState.GetState();

            bool areEqual = this.CompareStates(beforeLoad, afterLoad);
            Assert.IsTrue(areEqual);
        }

        public bool CompareStates(IDictionary<string, string> firstState, IDictionary<string, string> secondState)
        {
            bool areEqual = false;
            areEqual = firstState["word"] == secondState["word"] &&
                       firstState["playersWord"] == secondState["playersWord"] &&
                       firstState["mistakes"] == secondState["mistakes"];

            return areEqual;
        }
    }
}