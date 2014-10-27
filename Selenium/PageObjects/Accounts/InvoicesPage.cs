using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Xero_testing.Selenium.PageObjects.Accounts
{
    public class InvoicesPage : BasePage
    {
#pragma warning disable
        [FindsBy(How = How.XPath, Using = "//a[@href='/RepeatTransactions/Edit.aspx?type=AR']")]
        [CacheLookup]
        private IWebElement newRepeatingInvoicesButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/AccountsReceivable/EditCreditNote.aspx']")]
        [CacheLookup]
        public IWebElement newCreditNoteButton;

        [FindsBy(How = How.Id, Using = "//a[@href='/AccountsReceivable/Statements.aspx']")]
        [CacheLookup]
        public IWebElement sendStatemensButton;

#pragma warning restore

        public TopToolbar topToolBar;

        public InvoicesPage(IWebDriver driver)
            : base(driver, "Xero | Invoices | Demo Company (NZ) ")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            //this.WaitForTitle("Xero | Invoices | Demo Company (NZ) ");
            this.WaitForElementByXPath("//span/[@text()='Invoices']");
        }

        public void clickNewRepeatingInvoice()
        {
            newRepeatingInvoicesButton.Click();
            var _InvoicesPage = new InvoicesPage(this.driver);
            PageFactory.InitElements(driver, _InvoicesPage);
            return _InvoicesPage;
        }
    }
}
