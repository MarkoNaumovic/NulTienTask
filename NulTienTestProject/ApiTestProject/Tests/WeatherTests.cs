using ApiTestProject.Helpers;
using ApiTestProject.Model;
using ApiTestProject.Report;
using NUnit.Framework;

namespace ApiTestProject.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class WeatherTests : Extent
    {
        public const string city = "Belgrade";
        public const string appId = "f1e28e53cf448062928bb611aac3f7cb";

        [Test]
        public void VerfyBelgradeName()
        {
            extentTest = extentReports.CreateTest("Verfy Belgrade Name");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That("Belgrade", Is.EqualTo(response.name));
            extentTest.Info("City Name: " + response.name);
        }

        [Test]
        public void VerfyContryCode()
        {
            extentTest = extentReports.CreateTest("Verfy Contry Code");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(200, Is.EqualTo(response.cod));
            extentTest.Info("Contry Code: " + response.cod);
        }
        [Test]
        public void VerfyId()
        {
            extentTest = extentReports.CreateTest("Verify Id");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(792680, Is.EqualTo(response.id));
            extentTest.Info("ID: " + response.id);
        }
        [Test]
        public void VerfyTimeZone()
        {
            extentTest = extentReports.CreateTest("Verify Time Zone");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(7200, Is.EqualTo(response.timezone));
            extentTest.Info("Time Zone: " + response.timezone);
        }
        [Test]
        public void VerfyContry()
        {
            extentTest = extentReports.CreateTest("Verify Contry Domen");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That("RS", Is.EqualTo(response.Sys.country));
            extentTest.Info("Contry Domen: " + response.Sys.country);
        }
        [Test]
        public void GetSunriseInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Data Of Sunrise In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Sys.sunrise.ToString(), Is.Not.Empty);
            extentTest.Info("Sunrise In Belgrade: " + response.Sys.sunrise);
        }
        [Test]
        public void GetSunsetInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Date Of Sunset In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Sys.sunset.ToString(), Is.Not.Empty);
            extentTest.Info("Sunset In Belgrade: " + response.Sys.sunset);
        }

        [Test]
        public void GetMaxTemperatureInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Max Temperature In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Main.temp_max.ToString(), Is.Not.Empty);
            extentTest.Info("Max Temperature: " + response.Main.temp_max);
        }

        [Test]
        public void VerifyMinTemperatureInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Min Temperature In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Main.temp_min.ToString(), Is.Not.Empty);
            extentTest.Info("Min Temperature: " + response.Main.temp_min);
        }

        [Test]
        public void VerifyTemperatureInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Temperature In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Main.temp.ToString(), Is.Not.Empty);
            extentTest.Info("Temperture: " + response.Main.temp);
        }

        [Test]
        public void VerifyPressureInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Pressure In Belgarde");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Main.pressure.ToString(), Is.Not.Empty);
            extentTest.Info("Pressure: " + response.Main.pressure);
        }


        [Test]
        public void VerifyHumidityInBelgrade()
        {
            extentTest = extentReports.CreateTest("Get Humidty In Belgrade");
            var data = new Api<WeatherDTO>();
            var response = data.CreateGetRequest($"?q={city}&appId={appId}");
            Assert.That(response.Main.humidity.ToString(), Is.Not.Empty);
            extentTest.Info("Humidity: " + response.Main.humidity);

        }
    }
}
