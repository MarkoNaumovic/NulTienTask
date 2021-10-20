using NulTienTestProject.Helpers;
using NulTienTestProject.PageObject;
using NUnit.Framework;

namespace NulTienTestProject.Tests
{
    [TestFixture]
    public class HiPriceTest : BaseClass
    {

        [Test]
        public void FindSasmungHiPrice()
        {
           
            KupujemProdajem kppage = new KupujemProdajem();
            OpenPageKP open = new OpenPageKP();

            open.OpenKP();
            kppage.CloseLoginModal();
            kppage.CookiesAccept();
            kppage.SearchOnKP("Samasung");
            kppage.ClickOnSuggestion();
            kppage.OpenSort();
            kppage.HightPriceClick();
            kppage.SearchBtnClick();
            kppage.PrintTopFiveResults();
            kppage.VerfyTitlePage("Samsung");
            kppage.AssertPriceIsHigherThen100e();
        }
    }
}
