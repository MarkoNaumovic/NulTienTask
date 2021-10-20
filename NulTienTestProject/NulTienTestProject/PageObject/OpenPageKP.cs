using OpenQA.Selenium;

namespace NulTienTestProject.PageObject
{
    public class OpenPageKP
    {
        private readonly IWebDriver driver = Drivers.WebDriver.Instance;

        public void OpenKP()
        {
            driver.Navigate().GoToUrl("https://novi.kupujemprodajem.com/");
        }
    }
}
