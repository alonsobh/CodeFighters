using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFighter.BL.Test
{
    [TestClass]
    public class GameTestInitialLoad
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game("Juan", GameRoleList.Dev, "Jose", GameRoleList.PM);
        }

        [TestMethod]
        public void GameStart()
        {
            Assert.AreEqual("Juan", game.Player1.Name);
            Assert.AreEqual("Jose", game.Player2.Name);
        }

        [TestMethod]
        public void GameStartWithRole()
        {
            Assert.AreEqual(GameRoleList.Dev, game.Player1.Role);
            Assert.AreEqual(GameRoleList.PM, game.Player2.Role);
        }

        [TestMethod]
        public void GameStartLife200()
        {
            Assert.AreEqual(Player.MaxLife, game.Player1.Life);
            Assert.AreEqual(Player.MaxLife, game.Player2.Life);
        }

        [TestMethod]
        public void GameStartEnergy0()
        {
            Assert.AreEqual(0, game.Player1.Energy);
            Assert.AreEqual(0, game.Player2.Energy);
        }
    }
}