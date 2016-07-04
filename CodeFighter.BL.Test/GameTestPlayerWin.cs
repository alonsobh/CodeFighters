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
        public void Player1Punch()
        {
            game.Punch(true);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(190, game.LifePlayer2);
            Assert.AreEqual(5, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Punch()
        {
            game.Punch(false);
            Assert.AreEqual(190, game.LifePlayer1);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(5, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player1Kick()
        {
            game.Kick(true);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(180, game.LifePlayer2);
            Assert.AreEqual(8, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Kick()
        {
            game.Kick(false);
            Assert.AreEqual(180, game.LifePlayer1);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(8, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player1Special()
        {
            game.FillEnergy(true);
            game.Special(true);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(170, game.LifePlayer2);
            Assert.AreEqual(15, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Special()
        {
            game.FillEnergy(false);
            game.Special(false);
            Assert.AreEqual(170, game.LifePlayer1);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(15, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player1Heal()
        {
            game.FillEnergy(true);
            game.SetLife(true, 150);
            Assert.AreEqual(150, game.LifePlayer1);
            Assert.AreEqual(100, game.EnergyPlayer1);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(0, game.EnergyPlayer2);
            game.Heal(true);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
        }

        [TestMethod]
        public void Player2Heal()
        {
            game.FillEnergy(false);
            game.SetLife(false, 150);
            Assert.AreEqual(150, game.LifePlayer2);
            Assert.AreEqual(100, game.EnergyPlayer2);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(0, game.EnergyPlayer1);
            game.Heal(false);
            Assert.AreEqual(200, game.LifePlayer2);
            Assert.AreEqual(200, game.LifePlayer1);
            Assert.AreEqual(0, game.EnergyPlayer2);
            Assert.AreEqual(0, game.EnergyPlayer1);
        }
    }
}