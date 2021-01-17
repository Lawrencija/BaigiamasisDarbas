using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

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


        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();



        }
    }
}
