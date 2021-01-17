using AntrasProjektas.Projektas.Puslapiai;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntrasProjektas.Projektas.Testai
{
    class PirmasPuslapisTest1 : Bazine1
    {
        private PirmasPuslapis pirmasPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            pirmasPuslapis = new PirmasPuslapis(driver);
            
        }

        [Test]

        public void PanaikintiZalialentele()
        {
            pirmasPuslapis.PasirinkKlaipeda()
                          .PasirinktiBarbora()
                          .PatikrintiSutikimoLentelesBuvima() //Assert patikrina ar yra sutikimo lentelė
                          .SutikimoMygtukoPaspaudimas() // Išjungia sutikimo lentelę
                          .PatikrintiSutikimoLentelesNebuvima(); // Assert patikrina ar lentelės nėra

        }
    }
}