using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFighter.BL.Test
{
    [TestClass]
    public class GameTestFight
    {
        private Game game;
        [TestInitialize]
        public void Initialize()
        {
            game = new Game("Juan","Jose");
        }

        [TestMethod]
        public void GameStart()
        {
            Assert.AreEqual("Juan", game.NamePlayer1);
            Assert.AreEqual("Jose", game.NamePlayer2);
        }
    }
}