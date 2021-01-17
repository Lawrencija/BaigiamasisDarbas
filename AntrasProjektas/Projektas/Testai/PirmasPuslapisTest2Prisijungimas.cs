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
    class PirmasPuslapisTest2Prisijungimas : Bazine1
    {
        private PirmasPuslapis pirmasPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            pirmasPuslapis = new PirmasPuslapis(driver);
            pirmasPuslapis.PasirinkKauna()
                          .PasirinktiBarbora()
                          .SutikimoMygtukoPaspaudimas()
                          .PaspaustiPrisijungti();
        }

        [Test]
        public void PrisijungimasGeras()
        {
            string vardas = "laurapavardaite@gmail.com";
            string passwordgood = "geras123";

            pirmasPuslapis.SuvestiMail(vardas)
                          .SuvestiSlaptazodi(passwordgood)
                          .Prisijungti();
           WebDriverWait waitas = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
           waitas.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".b - header--select--top > div > .b - header--select--text")));
           pirmasPuslapis.TuriPrisijungti(); // Assert, koks rezultatas jei teisinga slaptazodi suvedi

        }

        [Test]
        public void PrisijungimasBlogas()
        {
            string vardas = "laurapavardaite@gmail.com";
            string passwordbad = "blogas123";

            pirmasPuslapis.SuvestiMail(vardas)
                          .SuvestiSlaptazodi(passwordbad)
                          .Prisijungti();
            Thread.Sleep(3000);
            pirmasPuslapis.TuriNeprisijungti(); // Assert, koks rezultatas jei neteisingai slaptazodi suvedi

        }
    }
}