using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace AntrasProjektas.Projektas.Testai 
{
    class Bazine1
    {
        public IWebDriver driver;

        [SetUp]
        public void priesKiekvienaTesta()
        {
            PerduotiDriveri("chrome");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.barbora.lt/";
        }

        public void PerduotiDriveri(string driverPavadinimas)
        {
            if (driverPavadinimas == "chrome")
            {
                driver = new ChromeDriver(padidintiChromeLanga());
            }
            if (driverPavadinimas == "firefox")
            {
                driver = new FirefoxDriver();
            }
        }

        public ChromeOptions padidintiChromeLanga()
        {
            ChromeOptions langas = new ChromeOptions();
            langas.AddArgument("start-maximized");
            return langas;
        }

        public void PadarykScreenshota()
        {
            Screenshot screenshot = driver.TakeScreenshot();
            string screenshotKelia = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotKelia);
            string screenshotFailas = Path.Combine(screenshotKelia, $"{TestContext.CurrentContext.Test.Name}.png");
            screenshot.SaveAsFile(screenshotFailas, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFailas, "Mano screenshotas");
        }

        public void PadarykScreenshotaJeiguTestasFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                PadarykScreenshota();
            }
        }

        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
