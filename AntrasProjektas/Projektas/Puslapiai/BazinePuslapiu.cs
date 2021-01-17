using OpenQA.Selenium;

namespace AntrasProjektas.Projektas.Puslapiai
{
    public class BazinePuslapiu
    {
        protected IWebDriver driver; 
        public BazinePuslapiu(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
