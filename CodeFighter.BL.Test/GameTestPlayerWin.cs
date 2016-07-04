using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFighter.BL.Test
{
    [TestClass]
    public class GameTestPlayerWin
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game("Juan", GameRoleList.Dev, "Jose", GameRoleList.PM);
        }

        [TestMethod]
        public void Player2FatalityAndPerfect()
        {
            game.Player1.SetLife(0);
            game.Player2.FillEnergy();
            Assert.AreEqual("FATALITY!!! Jose wins Perfectly", game.GetWinner());
        }

        [TestMethod]
        public void Player2Perfect()
        {
            game.Player1.SetLife(0);
            Assert.AreEqual("Jose wins Perfectly", game.GetWinner());
        }

        [TestMethod]
        public void Player2Wins()
        {
            game.Player1.SetLife(0);
            game.Player2.SetLife(90);
            Assert.AreEqual("Jose wins", game.GetWinner());
        }

        [TestMethod]
        public void Player2Fatality()
        {
            game.Player1.SetLife(0);
            game.Player2.FillEnergy();
            game.Player2.SetLife(90);
            Assert.AreEqual("FATALITY!!! Jose wins", game.GetWinner());
        }
    }
}