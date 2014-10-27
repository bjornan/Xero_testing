using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Xero_testing.Selenium.PageObjects.Accounts
{
    public class NewRepeatingInvoicePage:BasePage
    {
        #pragma warning disable
        [FindsBy(How = How.Id, Using = "PeriodUnit")]
        private IWebElement periodUnit;

        [FindsBy(How = How.Id, Using = "TimeUnit_value")]
        [CacheLookup]
        public IWebElement timeUnit_value;

        [FindsBy(How = How.Id, Using = "StartDate")]
        [CacheLookup]
        public IWebElement startDate;

        [FindsBy(How = How.Id, Using = "DueDateDay")]
        [CacheLookup]
        public IWebElement dueDateDay;

        [FindsBy(How = How.Id, Using = "DueDateType_value")]
        [CacheLookup]
        public IWebElement dueDateType_value;
       
        [FindsBy(How = How.Id, Using = "EndDate")]
        [CacheLookup]
        public IWebElement endDate;

        [FindsBy(How = How.Name, Using = "PaidToContactID")]
        [CacheLookup]
        public IWebElement invoiceTo;

        [FindsBy(How = How.XPath, Using = "//div[@=']/div/input")]
        [CacheLookup]
        public IWebElement reference;

#pragma warning restore

        public TopToolbar topToolBar;

        public NewRepeatingInvoicePage(IWebDriver driver)
            : base(driver, "Xero | Invoices | Demo Company (NZ) ")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            //this.WaitForTitle("Xero | Invoices | Demo Company (NZ) ");
            this.WaitForElementByXPath("//form[@id='frmMain']//[@text()='New Repeating Invoice']");
        }

        public void DatePicker(string idElement)
        {
            DateFormat dateFormat2 = new SimpleDateFormat("dd"); 
            Date date2 = new Date();

            String strToday = dateFormat2.format(date2); 
            int temptoday = Integer.parseInt(strToday); 
            String today =  String.valueOf(temptoday).toString();

            //find the calendar
            WebElement dateWidget = driver.findElement(By.id("dp-calendar"));  
            List<WebElement> columns=dateWidget.findElements(By.tagName("td"));  

            //comparing the text of cell with today's date and clicking it.
            for (WebElement cell : columns) {
            if (cell.getText().equals(today)) {
            cell.click();
            break;
            }
        }
    }
}
