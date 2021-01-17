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
    class PirmasPuslapisTest5Kalba : Bazine1
    {
        private PirmasPuslapis pirmasPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            pirmasPuslapis = new PirmasPuslapis(driver);
            pirmasPuslapis.PasirinkKlaipeda()
                          .PasirinktiBarbora()
                          .SutikimoMygtukoPaspaudimas();
        }

        [Test]
        public void KalbosPasirinkimas() 
        {
            PadarykScreenshotaJeiguTestasFailed(); // kai testas leidziamas su Firefox būna failed, todėl daro printscreen.

            pirmasPuslapis.KalbosPasirinkimoMygtukoPaspaudimas()
                          .AngluKalbosPasirinkimas();
            Thread.Sleep(3000);
            pirmasPuslapis.AngluKalbosPatikrinimas()
                          .KalbosPasirinkimoMygtukoPaspaudimas()
                          .LietuviuKalbosPasirinkimas();
            Thread.Sleep(3000);
            pirmasPuslapis.LietuviuKalbosPatikrinimas();
        }
      
    }
}