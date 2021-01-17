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



        }

        [Test]
        public void KalbosPasirinkimas()
        {
            pirmasPuslapis.PasirinkKlaipeda()
                          .PasirinktiBarbora()
                          .SutikimoMygtukoPaspaudimas()
                          .KalbosPasirinkimoMygtukoPaspaudimas();
           
            pirmasPuslapis.AngluKalbosPasirinkimas();
            Thread.Sleep(3000);
            pirmasPuslapis.AngluKalbosPatikrinimas();
            pirmasPuslapis.KalbosPasirinkimoMygtukoPaspaudimas();
            pirmasPuslapis.LietuviuKalbosPasirinkimas();
            Thread.Sleep(3000);
            pirmasPuslapis.LietuviuKalbosPatikrinimas();

        }
       
    }
}