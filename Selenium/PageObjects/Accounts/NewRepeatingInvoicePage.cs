using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;
using System.Collections.ObjectModel;
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

        [FindsBy(How = How.XPath, Using = "//form[@id='frmMain']//div[@class='controls']/input")]
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
            descriptionText.SendKeys(description);
        }
        public void setQuantity(string quant)
        {
            quantity.SendKeys(quant);
        }

        public void setRandomItem()
        {
            //html/body/form/div[2]/div[2]/div/div[2]/div[3]/div/div/div[3]/div/div/div/div/div/div[1]/div[2]/div[1]/div[1]/table/tbody/tr/td[2]/div
            var element = driver.FindElement(By.XPath("//form[@id='frmMain']//table/tbody/tr/td[2]/div"));
            element.Click();
            //html/body/form/div[2]/div[2]/div/div[2]/div[3]/div/div/div[3]/div/div/div/div/div/div[1]/div[2]/div[2]/div/img
            var elementArrow = driver.FindElement(By.XPath("//form[@id='frmMain']//div[1]/div[2]/div[2]/div/img"));
            elementArrow.Click();
            //itemDropdown.Click();
            //html/body/div[8]/div/div[6]
            //foreach (string handle in WebBrowser.Current.WindowHandles)
            //{
            //    IWebDriver popup = driver.SwitchTo().Window(handle);

            //    if (popup.Title.Contains("popup title"))
            //    {
            //        break;
            //    }
            //}
            //html/body/div[8]/div/div
            WaitForElementByXPath("/html/body/div[8]/div/div");
            ReadOnlyCollection<IWebElement> selectionRows = driver.FindElements(By.XPath("/html/body/div[8]/div/div"));
            Random rnd = new Random();
            int randomInteger = rnd.Next(2, selectionRows.Count);
            //IWebElement selection = driver.FindElement(By.XPath("/html/body/div[8]/div/div["+randomInteger.ToString()+"]"));
            //selection.SendKeys(Keys.Control); 
            //selection.Click();
            Thread.Sleep(1000);
            //selectionRows[randomInteger].SendKeys(Keys.Control);
            //selectionRows[randomInteger].SendKeys("");
            selectionRows[randomInteger].SendKeys(Keys.Space);
            //selectionRows[randomInteger].Submit();
            selectionRows[randomInteger].Click();
        }
        public InvoicesPage clickSave()
        {
            saveButton.Click();
            var _InvoicesPage = new InvoicesPage(this.driver);
            PageFactory.InitElements(driver, _InvoicesPage);
            return _InvoicesPage;
        }

        public void DatePicker(string idElement)
        {
            //DateFormat dateFormat2 = new SimpleDateFormat("dd"); 
            //Date date2 = new Date();

            //String strToday = dateFormat2.format(date2); 
            //int temptoday = Integer.parseInt(strToday); 
            //String today =  String.valueOf(temptoday).toString();

            ////find the calendar
            //WebElement dateWidget = driver.findElement(By.id("dp-calendar"));  
            //List<WebElement> columns=dateWidget.findElements(By.tagName("td"));  

            ////comparing the text of cell with today's date and clicking it.
            //for (WebElement cell : columns) {
            //if (cell.getText().equals(today)) {
            //cell.click();
            //break;
            //}
        }
        public void setDueDate(string dueDate)
        {
            dueDateDay.SendKeys(dueDate);
        }
    }
}
