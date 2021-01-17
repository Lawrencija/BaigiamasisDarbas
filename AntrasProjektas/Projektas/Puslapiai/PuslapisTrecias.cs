
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AntrasProjektas.Projektas.Puslapiai
{
    class PuslapisTrecias : BazinePuslapiu
    {


        public PuslapisTrecias(IWebDriver driver) : base(driver) { }

        private IWebElement pasirinkimoVizualizacija => driver.FindElement(By.CssSelector(".b-search--page-heading-wrap"));
        private IWebElement pasirinktiKruasana => driver.FindElement(By.LinkText("Sviestinis kruasanas, 45 g"));
        private IWebElement pasirinktiBanana => driver.FindElement(By.LinkText("Bananai, 1 kg"));
        private IWebElement idetiIKrepseli => driver.FindElement(By.XPath("//div[2]/button/span"));
        private IWebElement ismetimoMygtukas => driver.FindElement(By.CssSelector(".c-btn:nth-child(2) use"));
        private IWebElement sutikimasSuIsmetimu => driver.FindElement(By.CssSelector(".col-sm-12:nth-child(1) span"));
        private IWebElement krepselist => driver.FindElement(By.CssSelector(".b-cart--empty-content"));
        private IWebElement krusanasKrepselyje => driver.FindElement(By.CssSelector(".b-cart--item-title"));
        private IWebElement DviejuKruasanuKaina => driver.FindElement(By.CssSelector(".b-next-cart-item--price"));
        private IWebElement KruasanuKiekisKrepseli => driver.FindElement(By.XPath("//input[@value='2']"));
        private IWebElement KruasanuKiekisPriePrekes => driver.FindElement(By.CssSelector(".b-next-quantity-select--input"));


        public PuslapisTrecias pasirinkimoPatikrinimas(string tekstas)
        {
            Assert.AreEqual(tekstas, pasirinkimoVizualizacija.Text);
            return this;
        }

        public PuslapisTrecias pazymetiKruasana()
        {
            pasirinktiKruasana.Click();
            return this;
        }

        public PuslapisTrecias pazymetiBanana()
        {
            pasirinktiBanana.Click();
            return this;
        }

        public PuslapisTrecias IdetiIPirkiniuKrepseli()
        {
            idetiIKrepseli.Click();
            return this;
        }

        public PuslapisTrecias Isimtivisasprekes()
        {
            ismetimoMygtukas.Click();
            sutikimasSuIsmetimu.Click();
            return this;
        }
        public PuslapisTrecias ArKrepselisTuscias()
        {
            Assert.AreEqual("Krepšelis tuščias\r\nIšsirinkite prekę ir spauskite\r\nmygtuką \"Į krepšelį\"", krepselist.Text);
            return this;
        }

        public PuslapisTrecias ArYraKruasanas()
        {
            Assert.AreEqual("Sviestinis kruasanas, 45 g", krusanasKrepselyje.Text); //Patikrinamas pavadinimas
            Assert.AreEqual("€0,58", DviejuKruasanuKaina.Text); //Patikrinama kaina.
            Assert.AreEqual(KruasanuKiekisPriePrekes.Text, KruasanuKiekisKrepseli.Text); //Patikrinamas Kiekis

            return this;

        }
    }
}