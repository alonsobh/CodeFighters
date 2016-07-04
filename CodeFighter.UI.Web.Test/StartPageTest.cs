using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Test
{
    [TestClass]
    public class StartPageTest
    {

        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }

        [TestCleanup]
        public void Clean()
        {
            driver.Quit();
        }


        [TestMethod]
        public void VerifyTwoPlayerAreRequired()
        {
            driver.Url = "http://localhost/CodeFighter.UI.Web/Home/Index";
           var player1 = driver.FindElement(By.Id("Player1")).Text;
            var player2 = driver.FindElement(By.Id("Player2")).Text; 
            Assert.AreEqual("",player1);
            Assert.AreEqual("", player2);
            
        }

        [TestMethod]
        public void VerifyExistsRole()
        {
            driver.Url = "http://localhost/CodeFighter.UI.Web/Home/Index";
            var player1Type = driver.FindElement(By.Id("Player1type")).Text;
            var player2Type = driver.FindElement(By.Id("Player2type")).Text;
            Assert.AreEqual(true, player1Type.Contains(GameRoleList.Dev.ToString()));
            Assert.AreEqual(true, player1Type.Contains(GameRoleList.BA.ToString()));
            Assert.AreEqual(true, player1Type.Contains(GameRoleList.PM.ToString()));
            Assert.AreEqual(true, player1Type.Contains(GameRoleList.QA.ToString()));
            Assert.AreEqual(true, player2Type.Contains(GameRoleList.Dev.ToString()));
            Assert.AreEqual(true, player2Type.Contains(GameRoleList.BA.ToString()));
            Assert.AreEqual(true, player2Type.Contains(GameRoleList.PM.ToString()));
            Assert.AreEqual(true, player2Type.Contains(GameRoleList.QA.ToString()));

        }

    }
}