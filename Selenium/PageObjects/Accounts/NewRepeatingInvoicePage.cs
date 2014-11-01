using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;



namespace Xero_testing.Selenium.PageObjects.Accounts
{
    public class NewRepeatingInvoicePage : BasePage
    {
#pragma warning disable
        [FindsBy(How = How.Id, Using = "PeriodUnit")]
        private IWebElement periodUnit;

        [FindsBy(How = How.Id, Using = "TimeUnit_value")]
        [CacheLookup]
        public IWebElement timeUnit_value;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//img[@id='ext-gen42']")]
        [CacheLookup]
        public IWebElement invoiceDateCalendar;

        [FindsBy(How = How.Id, Using = "DueDateDay")]
        [CacheLookup]
        public IWebElement dueDateDay;

        [FindsBy(How = How.Id, Using = "DueDateType_value")]
        [CacheLookup]
        public IWebElement dueDateType_value;

        [FindsBy(How = How.Id, Using = "EndDate")]
        [CacheLookup]
        public IWebElement endDate;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//div[@id='ext-gen48']/input")]
        [CacheLookup]
        public IWebElement invoiceTo;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//input[@id='saveAsDraft']")]
        [CacheLookup]
        public IWebElement saveAsDraftRadio;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//input[@id='saveAsAutoApproved']")]
        [CacheLookup]
        public IWebElement approvedRadio;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//input[@id='saveAsAutoApprovedAndEmail']")]
        [CacheLookup]
        public IWebElement approveForSendingRadio;
        //*[@id="Reference_c19e4fcbba3c4b0f819f4c3e775b0432"]
        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//div[starts-with(@id, Reference)]/input")]
        [CacheLookup]
        public IWebElement reference;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//img[@id='ext-gen56']")]
        [CacheLookup]
        public IWebElement itemDropdown;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//textarea[@id='ext-comp-1002']")]
        [CacheLookup]
        public IWebElement descriptionText;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//textarea[@id='ext-comp-1004']")]
        [CacheLookup]
        public IWebElement quantity;

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//button[@tabindex='252']")]
        [CacheLookup]
        public IWebElement saveButton;



#pragma warning restore

        public TopToolbar topToolBar;

        public NewRepeatingInvoicePage(IWebDriver driver)
            : base(driver, "Xero | Invoices | Demo Company (NZ) ")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            this.WaitForElementByXPath("//form[@id='frmMain']//h1");
        }
        public void clickInvoiceCalendar()
        {
            invoiceDateCalendar.Click();
        }
        public void selectInvoiceDateToday()
        {
            this.clickInvoiceCalendar();
            var dateToday = driver.FindElement(By.XPath("//td[@title='Today']"));
            dateToday.Click();
            var _popup = new NewRepeatingInvoicesPopUp(this.driver);
            PageFactory.InitElements(driver, _popup);
            _popup.clickOk();

        }
        public void setInvoiceTo(string invoiceString)
        {
            invoiceTo.SendKeys(invoiceString);
        }
        public void setReference(string referenceString)
        {
            reference.SendKeys(referenceString);
        }
        public void setSaveAsDraft()
        {
            saveAsDraftRadio.Click();
        }
        public void setApproved()
        {
            approvedRadio.Click();
        }
        public void setApprovedForSending()
        {
            approveForSendingRadio.Click();
        }
        public void setDescription(string description)
        {
            WaitForElementByXPath("//form[@id='frmMain']//textarea[@id='ext-comp-1002']");
            descriptionText.SendKeys(description);
        }
        public void setQuantity(string quant)
        {
            quantity.SendKeys(quant);
        }

        public void ClickComboItem(IWebElement input, string target)
        {
            input.Click();
            IList<IWebElement> comboItems = driver.FindElements(By.CssSelector(".x-combo-list[style*='visibility: visible;'] .x-combo-list-item"));
            comboItems.First(item => item.Text.Trim() == target).Click();
        }
        public void ChooseItem(string target)
        {
            var element = driver.FindElement(By.XPath("//form[@id='frmMain']//table/tbody/tr/td[2]/div"));
            element.Click();
            var elementArrow = driver.FindElement(By.XPath("//form[@id='frmMain']//div[1]/div[2]/div[2]/div/img"));
            elementArrow.Click();
            IList<IWebElement> comboItems = driver.FindElements(By.CssSelector(".x-combo-list[style*='visibility: visible;'] .x-combo-list-item"));
            comboItems.First(item => item.Text.Trim() == target).Click();
        }
        public InvoicesPage clickSave()
        {
            saveButton.Click();
            var _InvoicesPage = new InvoicesPage(this.driver);
            PageFactory.InitElements(driver, _InvoicesPage);
            return _InvoicesPage;
        }

        public void setDueDate(string dueDate)
        {
            dueDateDay.SendKeys(dueDate);
        }
    }
}
