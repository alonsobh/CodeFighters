using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace CodeFighter.UI.Web.Test
{
    [TestClass]
    public class MatchTest1
    {
        private const string Enviroment = "http://localhost/Tennis.Web/";

        IWebDriver[] _drivers;

        [TestInitialize]
        public void InitializeDrivers()
        {
            _drivers = new IWebDriver[]{
                new FirefoxDriver(),
                new InternetExplorerDriver(@"C:\Users\Alon\Source\Repos\tenniskata\packages\WebDriverIEDriver.2.45.0.0\tools"),
                new ChromeDriver(@"C:\Users\Alon\Source\Repos\tenniskata\packages\WebDriver.ChromeDriver.26.14.313457.1\tools")
            };

        }
        [TestMethod]
        public void Player1Punch()
        {

        }
    }
}