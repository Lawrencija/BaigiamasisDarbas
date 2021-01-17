using AntrasProjektas.Projektas.Puslapiai;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AntrasProjektas.Projektas.Testai
{
    class PuslapisAntrasTest3Akcijos : Bazine1
    {
        private PirmasPuslapis pirmasPuslapis;
        private PuslapisAntras antrasPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            pirmasPuslapis = new PirmasPuslapis(driver);
            antrasPuslapis = new PuslapisAntras(driver);
            pirmasPuslapis.PasirinkKauna()
                          .PasirinktiBarbora()
                          .SutikimoMygtukoPaspaudimas()
                          .akcijosMygtukoPaspaudimas();
        }

        [Test]
        public void AkcijųPuslapioAtidarymas()
        {
            Thread.Sleep(3000);
            pirmasPuslapis.patikrinaAkcijuPuslapioBuvima();
        }

        [Test]
        public void pasirinkimasPagalPopuliarumą()
        {
            string tekstas = "Populiarumą";

            antrasPuslapis.pasirinktiElementa(tekstas)
                          .patikrintiPasirinktaElementa(tekstas);
        }
    }
}