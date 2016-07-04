using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFighter.BL.Test
{
    [TestClass]
    public class GameTestAttack
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game("Juan", GameRoleList.Dev, "Jose", GameRoleList.PM);
        }

        [TestMethod]
        public void Player1Punch()
        {
            game.Punch(true);
            Assert.AreEqual(200, game.LifePLayer1);
            Assert.AreEqual(190, game.LifePLayer2);
            Assert.AreEqual(5, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Punch()
        {
            game.Punch(false);
            Assert.AreEqual(190, game.LifePLayer1);
            Assert.AreEqual(200, game.LifePLayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(5, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player1Kick()
        {
            game.Kick(true);
            Assert.AreEqual(200, game.LifePLayer1);
            Assert.AreEqual(180, game.LifePLayer2);
            Assert.AreEqual(8, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Kick()
        {
            game.Kick(false);
            Assert.AreEqual(180, game.LifePLayer1);
            Assert.AreEqual(200, game.LifePLayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(8, game.EnergyPlayer2);
        }
    }
}