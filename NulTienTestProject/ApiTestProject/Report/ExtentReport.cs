using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using System.Net;

namespace ApiTestProject.Report
{
    [SetUpFixture]
    public class Extent
    {

        public static ExtentReports extentReports;
        public static ExtentTest extentTest;
        public static ExtentHtmlReporter htmlReport;


        [OneTimeSetUp]
        public void SetUpTestReport()
        {


            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;

            Directory.CreateDirectory(projectPath.ToString() + "TestReport");
            Console.WriteLine(projectPath.ToString());
            var reportPath = projectPath + "TestReport\\Index.html";



            htmlReport = new ExtentHtmlReporter(reportPath);
            htmlReport.Config.Theme = Theme.Standard;


            string hosname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReport);
            extentReports.AddSystemInfo("Name", "API Test Freamwork");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("WebApi", "http://api.openweathermap.org/data/2.5/weather");
            extentReports.AddSystemInfo("Project Name", "NulTien Api Test Framework");
            extentReports.AddSystemInfo("Tester", "Marko Naumovic");
            extentReports.AddSystemInfo("OS", os.ToString());
            extentReports.AddSystemInfo("Platform", os.Platform.ToString());
            extentReports.AddSystemInfo("HostName", hosname);
            extentReports.AnalysisStrategy = AnalysisStrategy.Test;

            htmlReport.LoadConfig(projectPath + "extend-confing.xml");

        }

        [TearDown]
        public void AfterTest()
        {


            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    extentTest.Log(logstatus, "Test " + logstatus + " – " + errorMessage + stacktrace);
                    string logText = $"Test [{TestContext.CurrentContext.Test.Name}] ended with a status of {logstatus}";
                    logText += $"<br><br>Message: {errorMessage}<br>Stacktrace: {stacktrace}";
                    extentTest.Log(logstatus, logText);

                    break;

                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    extentTest.Log(logstatus, "Test" + logstatus + " _ " + errorMessage + stacktrace);

                    break;

                default:
                    logstatus = Status.Pass;
                    extentTest.Log(logstatus, "Test " + logstatus);

                    break;
            }

        }

        [OneTimeTearDown]
        public void AfterClass()
        {

            extentReports.Flush();

        }

    }
}
