using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Xero_testing.Selenium.PageObjects.Accounts
{
    public class SalesPage : BasePage
    {

#pragma warning disable
        [FindsBy(How = How.XPath, Using = "//a[@href='/AccountsReceivable/Search.aspx?invoiceStatus=INVOICESTATUS%2fPAID&graphSearch=False']")]
        [CacheLookup]
        private IWebElement paidLink;

        [FindsBy(How = How.XPath, Using = "//a[@href='/AccountsReceivable/SearchRepeating.aspx']")]
        [CacheLookup]
        public IWebElement repeatingLink;

        [FindsBy(How = How.Id, Using = "//div/a[@text()='See all']")]
        [CacheLookup]
        public IWebElement goToPurchaseLink;
#pragma warning restore


        public TopToolbar topToolBar;
        public SalesPage(IWebDriver driver)
            : base(driver, "Xero | Sales | Demo Company (NZ)")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            this.WaitForTitle("Xero | Sales | Demo Company (NZ)");
        }
        public InvoicesPage clickOnRepeating()
        {
            repeatingLink.Click();
            var _InvoicesPage = new InvoicesPage(this.driver);
            PageFactory.InitElements(driver, _InvoicesPage);
            return _InvoicesPage;
        }

    }
}
