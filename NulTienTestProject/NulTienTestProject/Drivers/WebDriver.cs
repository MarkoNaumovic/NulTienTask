using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace NulTienTestProject.Drivers
{
    public static class WebDriver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(45);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                Instance.Manage().Window.Maximize();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string TakeScreenShot(string testName)
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}",
            $"{testName}_{DateTime.UtcNow:yyyyMMMdd}.png");
                var screnShot = ((ITakesScreenshot)Instance).GetScreenshot();
                screnShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                return fileName;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static void CleanUp()
        {
            Instance?.Quit();
        }
    }
}
