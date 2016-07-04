using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

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
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(190, game.Player2.Life);
            Assert.AreEqual(5, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Punch()
        {
            game.Punch(false);
            Assert.AreEqual(190, game.Player1.Life);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(5, game.Player2.Energy);
        }

        [TestMethod]
        public void Player1Kick()
        {
            game.Kick(true);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(180, game.Player2.Life);
            Assert.AreEqual(8, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Kick()
        {
            game.Kick(false);
            Assert.AreEqual(180, game.Player1.Life);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(8, game.Player2.Energy);
        }

        [TestMethod]
        public void Player1CanApplySpecial()
        {
            Assert.AreEqual(false, game.Player1.CanApplySpecial());
            game.Player1.FillEnergy();
            Assert.AreEqual(true, game.Player1.CanApplySpecial());
        }

        [TestMethod]
        public void Player1CanApplyHeal()
        {
            Assert.AreEqual(false, game.Player1.CanApplyHeal());
            game.Player1.FillEnergy();
            Assert.AreEqual(true, game.Player1.CanApplyHeal());
        }

        [TestMethod]
        public void Player1Special()
        {
            game.Player1.FillEnergy();
            game.Special(true);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(170, game.Player2.Life);
            Assert.AreEqual(15, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Special()
        {
            game.Player2.FillEnergy();
            game.Special(false);
            Assert.AreEqual(170, game.Player1.Life);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(15, game.Player2.Energy);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException))]
        public void Player1SpecialFail()
        {
            game.Special(true);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException))]
        public void Player2SpecialFail()
        {
            game.Special(false);
        }

        [TestMethod]
        public void Player1Heal()
        {
            game.Player1.FillEnergy();
            game.Player1.SetLife(150);
            Assert.AreEqual(150, game.Player1.Life);
            Assert.AreEqual(100, game.Player1.Energy);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            game.Heal(true);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Heal()
        {
            game.Player2.FillEnergy();
            game.Player2.SetLife(150);
            Assert.AreEqual(150, game.Player2.Life);
            Assert.AreEqual(100, game.Player2.Energy);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            game.Heal(false);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            Assert.AreEqual(0, game.Player1.Energy);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException))]
        public void Player1HealFail()
        {
            game.Heal(true);
        }

        [TestMethod]
        public void Player2HealOver200()
        {
            game.Player2.FillEnergy();
            game.Player2.SetLife(170);
            game.Heal(false);
            Assert.AreEqual(200, game.Player2.Life);
            Assert.AreEqual(200, game.Player1.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            Assert.AreEqual(0, game.Player1.Energy);
        }

        [TestMethod]
        public void Player2EnergyOver100()
        {
            game.Player2.FillEnergy();
            game.Punch(false);
            Assert.AreEqual(100, game.Player2.Energy);
        }
    }
}