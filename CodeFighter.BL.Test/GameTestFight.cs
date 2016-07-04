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
            game = new Game("Juan", GameRoleList.Dev, "Jose", GameRoleList.PM);
        }

        [TestMethod]
        public void GameStart()
        {
            Assert.AreEqual("Juan", game.NamePlayer1);
            Assert.AreEqual("Jose", game.NamePlayer2);
        }

        [TestMethod]
        public void GameStartWithRole()
        {
            Assert.AreEqual(GameRoleList.Dev, game.RolePlayer1);
            Assert.AreEqual(GameRoleList.PM, game.RolePlayer2);
        }
    }
}