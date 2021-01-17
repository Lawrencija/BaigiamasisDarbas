
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AntrasProjektas.Projektas.Puslapiai
{
    class PirmasPuslapis : BazinePuslapiu
    {
        public PirmasPuslapis(IWebDriver driver) : base(driver) { }

        private IWebElement Kaunas => driver.FindElement(By.CssSelector("#counties-data > div:nth-child(2) > div > button"));
        private IWebElement Klaipeda => driver.FindElement(By.CssSelector("#counties-data > div:nth-child(3) > div > button"));
        private IWebElement BarboraSimple => driver.FindElement(By.CssSelector("#counties-data > div:nth-child(1) > div > button"));
        private IWebElement sutinkuMygtukas => driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
        private IWebElement prisijungtiPasirinkimas => driver.FindElement(By.XPath("//span[contains(.,'Prisijungti')]"));
        private IWebElement elpastas => driver.FindElement(By.Id("b-login-email"));
        private IWebElement slaptazodis => driver.FindElement(By.Id("b-login-password"));
        private IWebElement prisijungimoMygtukas => driver.FindElement(By.CssSelector("#b-user-login > form > div:nth-child(4) > div > button"));
        private IWebElement neteisingoSlaptazodzioLentele => driver.FindElement(By.CssSelector("#b-user-login > p.b-warning"));
        private IWebElement pavykoPrisijungti => driver.FindElement(By.CssSelector(".b-header--select--top > div > .b-header--select--text"));
        private IWebElement akcijosMygtukas => driver.FindElement(By.LinkText("Akcijos"));
        private IWebElement akcijuPuslapis => driver.FindElement(By.XPath("//ol/li[2]"));
        public IWebElement paieskosLaukelis => driver.FindElement(By.XPath("(//input[@type='text'])[2]"));
        public IWebElement paieskosMygtukas => driver.FindElement(By.CssSelector(".c-btn:nth-child(4)"));
        private IWebElement kalbosPasirinkimoLentele => driver.FindElement(By.CssSelector(".b-header--select--text"));
        private IWebElement angluKalba => driver.FindElement(By.XPath("//span[contains(.,'English')]"));
        private IWebElement KalbosZodziai => driver.FindElement(By.CssSelector(".b-text-overflow-ellipsis--wrap"));
        private IWebElement lietuviukalba => driver.FindElement(By.XPath("//span[contains(.,'Lietuvių')]"));


        private IWebElement sutinkuZinute
        {
            get
            {
                try
                {
                    return driver.FindElement(By.LinkText("čia"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        public PirmasPuslapis PasirinkKauna()
        {
            Kaunas.Click();
            return this;
        }

        public PirmasPuslapis PasirinkKlaipeda()
        {
            Klaipeda.Click();
            return this;
        }

        public PirmasPuslapis PasirinktiBarbora()
        {
            BarboraSimple.Click();
            return this;
        }


        public PirmasPuslapis SutikimoMygtukoPaspaudimas()
        {
            sutinkuMygtukas.Click();
            return this;
        }

        public PirmasPuslapis PaspaustiPrisijungti()
        {
            prisijungtiPasirinkimas.Click();
            return this;
        }

        public PirmasPuslapis SuvestiMail(string irasomaselpastas)
        {
            elpastas.SendKeys(irasomaselpastas);
            return this;
        }

        public PirmasPuslapis SuvestiSlaptazodi(string irasomaselpastas)
        {
            slaptazodis.SendKeys(irasomaselpastas);
            return this;
        }

        public PirmasPuslapis Prisijungti()
        {
            prisijungimoMygtukas.Click();
            return this;
        }

        public PirmasPuslapis TuriNeprisijungti()
        {
            Assert.AreEqual("Neteisingi prisijungimo duomenys", neteisingoSlaptazodzioLentele.Text);
            return this;
        }

        public PirmasPuslapis TuriPrisijungti()
        {
            Assert.AreEqual("Laura", pavykoPrisijungti.Text);
            return this;
        }

        public PirmasPuslapis PatikrintiSutikimoLentelesBuvima()
        {
            Assert.IsNotNull(sutinkuZinute);
            return this;
        }

        public PirmasPuslapis PatikrintiSutikimoLentelesNebuvima()
        {
            Assert.IsNull(sutinkuZinute);
            return this;
        }

        public PirmasPuslapis akcijosMygtukoPaspaudimas()
        {
            akcijosMygtukas.Click();
            return this;
        }

        public PirmasPuslapis patikrinaAkcijuPuslapioBuvima()
        {
            Assert.AreEqual("Akcijos", akcijuPuslapis.Text);
            return this;
        }

        public void YpatingasPasiulymas()
        {
            try
            {
                driver.FindElement(By.CssSelector(".b-zigzag-heading .b-icon")).Click();
            }
            catch (WebDriverException)
            {

            }
        }
        public PirmasPuslapis suvestiIeskomaPreke(string tekstas)
        {
             paieskosLaukelis.Click();
             paieskosLaukelis.SendKeys(tekstas);
             return this;
        }

        public PirmasPuslapis paspaustiIeskoti()
        {
             paieskosMygtukas.Click();
             return this;
        }

        public PirmasPuslapis KalbosPasirinkimoMygtukoPaspaudimas()
        {
            kalbosPasirinkimoLentele.Click();
            return this;
        }

        public PirmasPuslapis AngluKalbosPasirinkimas()
        {
            angluKalba.Click();
            return this;
        }

        public PirmasPuslapis AngluKalbosPatikrinimas()
        {
            Assert.AreEqual("Main Barbora", KalbosZodziai.Text);
            return this;
        }

        public PirmasPuslapis LietuviuKalbosPasirinkimas()
        {
            lietuviukalba.Click();
            return this;
        }

        public PirmasPuslapis LietuviuKalbosPatikrinimas()
        {
            Assert.AreEqual("Pagrindinė Barbora", KalbosZodziai.Text);
            return this;
        }
    }
}


