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
    class PuslapisTreciasTest4 : Bazine1
    {
        private PirmasPuslapis pirmasPuslapis;
        private PuslapisTrecias treciasPuslapis;


        [SetUp]
        public void PriesKiekvienaTesta()
        {

            string vardas = "laurapavardaite@gmail.com";
            string passwordgood = "geras123";

            pirmasPuslapis = new PirmasPuslapis(driver);
            treciasPuslapis = new PuslapisTrecias(driver);
            pirmasPuslapis.PasirinkKauna()
                          .PasirinktiBarbora()
                          .SutikimoMygtukoPaspaudimas()
                          .PaspaustiPrisijungti()
                          .SuvestiMail(vardas)
                          .SuvestiSlaptazodi(passwordgood)
                          .Prisijungti()
                          .TuriPrisijungti();
            WebDriverWait waitas = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitas.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".b - zigzag - heading")));

            pirmasPuslapis.YpatingasPasiulymas();
        }

        [Test]

        public void surastiPreke()
        {
            string ieskomapreke = "vanduo";
            pirmasPuslapis.suvestiIeskomaPreke(ieskomapreke)
                          .paspaustiIeskoti();
            Thread.Sleep(3000);
            treciasPuslapis.pasirinkimoPatikrinimas($"Paieškos rezultatai pagal užklausą: \"{ieskomapreke}\"");
        }

        [Test]

        public void PatikrintiArIsidėjauKruasana()
        {
            string uzsisakomaPreke = "Sviestinis kruasanas";
            pirmasPuslapis.suvestiIeskomaPreke(uzsisakomaPreke)
                          .paspaustiIeskoti();
            treciasPuslapis.pasirinkimoPatikrinimas($"Paieškos rezultatai pagal užklausą: \"{uzsisakomaPreke}\"")
                           .pazymetiKruasana()
                           .IdetiIPirkiniuKrepseli()
                           .ArYraKruasanas()
                           .Isimtivisasprekes();        
        }

        [Test]
        public void PAtikrintiArPrekesIsimtos()
        {
            string uzsisakomaPreke = "bananai";
            pirmasPuslapis.suvestiIeskomaPreke(uzsisakomaPreke)
                          .paspaustiIeskoti();
            treciasPuslapis.pasirinkimoPatikrinimas($"Paieškos rezultatai pagal užklausą: \"{uzsisakomaPreke}\"")
                           .pazymetiBanana()
                           .IdetiIPirkiniuKrepseli();
            Thread.Sleep(3000);
            treciasPuslapis.Isimtivisasprekes();
            Thread.Sleep(3000);
            treciasPuslapis.ArKrepselisTuscias();
        }

    }
}