
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AntrasProjektas.Projektas.Puslapiai
{
    class PuslapisAntras : BazinePuslapiu
    {


        public PuslapisAntras(IWebDriver driver) : base(driver) { }

        private IWebElement IsiskleiziantiLentele => driver.FindElement(By.CssSelector(".b-orderby"));
        private IWebElement pasirinkimasLenteleje => driver.FindElement(By.CssSelector("body > div.b-app > div > div.container-fluid > div > div.b-page-specific-content > div.b-category-children--wrap.b-pseudoselect > div.b-category-children.b-pseudoselect--items > div.b-filter-order > div.row > div.col-xs-6.col-md-3.col-md-push-5 > select > option:nth-child(2)"));

        public PuslapisAntras pasirinktiElementa(string tekstas)
        {
            SelectElement pasirinktiReiksmeIsDropdowno = new SelectElement(IsiskleiziantiLentele);
            pasirinktiReiksmeIsDropdowno.SelectByText(tekstas);
            return this;
        }

        public PuslapisAntras patikrintiPasirinktaElementa(string tekstasKurioTikiuosi)
        {
           
           Assert.AreEqual(tekstasKurioTikiuosi, pasirinkimasLenteleje.Text);
           return this;
           
        }
    }
}

    