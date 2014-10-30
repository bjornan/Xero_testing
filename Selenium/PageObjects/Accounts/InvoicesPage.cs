using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using System.Collections;


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

        [FindsBy(How = How.XPath, Using = "//a[@href='/AccountsReceivable/Statements.aspx']")]
        [CacheLookup]
        public IWebElement sendStatemensButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//a[@id='ext-gen39']")]
        [CacheLookup]
        public IWebElement saveAsDraftButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//a[@id='ext-gen41']")]
        [CacheLookup]
        public IWebElement approveButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//a[@id='ext-gen43']")]
        [CacheLookup]
        public IWebElement approveForSendingButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//a[@id='ext-gen45']")]
        [CacheLookup]
        public IWebElement deleteButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//a[@id='ext-gen47']")]
        [CacheLookup]
        public IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "ext-gen48")]
        [CacheLookup]
        public IWebElement invoicesTable;

#pragma warning restore

        public TopToolbar topToolBar;

        public InvoicesPage(IWebDriver driver)
            : base(driver, "Xero | Invoices | Demo Company (NZ) ")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            this.WaitForElementByXPath("//form[@id='frmMain']//div/span[@id='title']");
        }

        public NewRepeatingInvoicePage clickNewRepeatingInvoice()
        {
            newRepeatingInvoicesButton.Click();
            var _RepeatingInvoicePage = new NewRepeatingInvoicePage(this.driver);
            PageFactory.InitElements(driver, _RepeatingInvoicePage);
            return _RepeatingInvoicePage;
        }
        public int nrOfInvoices()
        {
            ReadOnlyCollection<IWebElement> allRows = invoicesTable.FindElements(By.XPath("/tbody/tr"));

            return allRows.Count;
        }
        public ReadOnlyCollection<IWebElement> getInvoiceTable()
        {
            ReadOnlyCollection<IWebElement> invoicesTable = driver.FindElements(By.XPath("//table[@id='ext-gen48']/tbody"));
            return invoicesTable;
        }
        //public List<IWebElement> getInvoiceTable()
        //{
        //    List<IWebElement> textfields = new List<IWebElement>();

        //    var table = driver.FindElements(By.XPath("//table[@id='highVolumeSearchResults_group']//tr/td"));
        //    return table.ToList();

        //}
    }
}
