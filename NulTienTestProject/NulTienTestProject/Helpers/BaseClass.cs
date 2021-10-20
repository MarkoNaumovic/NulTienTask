using NUnit.Framework;
using OpenQA.Selenium;

namespace NulTienTestProject.Helpers
{
    public class BaseClass
    {
        public static IWebDriver Instance { get; set; }


        [SetUp]
        public void BeforeScenario()
        {
            Drivers.WebDriver.Initialize();

        }

        [TearDown]
        public void AfterSecanario()
        {
            Drivers.WebDriver.CleanUp();

        }

    }
}
