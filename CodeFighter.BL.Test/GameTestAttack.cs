using System;
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
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife-10, game.Player2.Life);
            Assert.AreEqual(10, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Punch()
        {
            game.Punch(false);
            Assert.AreEqual(Player.MaxLife-10, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(10, game.Player2.Energy);
        }

        [TestMethod]
        public void Player1Kick()
        {
            game.Kick(true);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife-20, game.Player2.Life);
            Assert.AreEqual(16, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Kick()
        {
            game.Kick(false);
            Assert.AreEqual(Player.MaxLife-20, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(16, game.Player2.Energy);
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
            game.Kick(false);
            game.Player1.FillEnergy();
            Assert.AreEqual(true, game.Player1.CanApplyHeal());
        }

        [TestMethod]
        public void Player1Special()
        {
            game.Player1.FillEnergy();
            game.Special(true);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife-30, game.Player2.Life);
            Assert.AreEqual(30, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Special()
        {
            game.Player2.FillEnergy();
            game.Special(false);
            Assert.AreEqual(Player.MaxLife-30, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(30, game.Player2.Energy);
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
            game.Player1.SetLife(Player.MaxLife-50);
            Assert.AreEqual(Player.MaxLife-50, game.Player1.Life);
            Assert.AreEqual(Player.MaxEnergy, game.Player1.Energy);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            game.Heal(true);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }

        [TestMethod]
        public void Player2Heal()
        {
            game.Player2.FillEnergy();
            game.Player2.SetLife(Player.MaxLife-50);
            Assert.AreEqual(Player.MaxLife-50, game.Player2.Life);
            Assert.AreEqual(Player.MaxEnergy, game.Player2.Energy);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(0, game.Player1.Energy);
            game.Heal(false);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            Assert.AreEqual(0, game.Player1.Energy);
        }

        [TestMethod]
        public void GameHasAWinner()
        {
            game.Player2.SetLife(10);
            game.Kick(true);
            Assert.AreEqual(true, game.HasWinner());
            try
            {
                game.Kick(true);
                Assert.Fail("no move should be allowed");
            }
            catch (DataException ex)
            {
                Assert.IsTrue(ex.Message.Contains("winner"));
            }
            catch (Exception)
            {
                Assert.Fail("wrong exception");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException))]
        public void Player1HealFail()
        {
            game.Heal(true);
        }

        [TestMethod]
        public void Player2HealOverFull()
        {
            game.Player2.FillEnergy();
            game.Player2.SetLife(Player.MaxLife-30);
            game.Heal(false);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(0, game.Player2.Energy);
            Assert.AreEqual(0, game.Player1.Energy);
        }

        [TestMethod]
        public void Player2EnergyOver100()
        {
            game.Player2.FillEnergy();
            game.Punch(false);
            Assert.AreEqual(Player.MaxEnergy, game.Player2.Energy);
        }
    }
}