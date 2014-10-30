using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;
using System.Collections.ObjectModel;

namespace Xero_testing.Selenium.PageObjects.Accounts
{
    public class NewRepeatingInvoicesPopUp : BasePage
    {
#pragma warning disable
        //button id="ext-gen80"
        [FindsBy(How = How.Id, Using = "ext-gen80")]
        [CacheLookup]
        public IWebElement okButton;

#pragma warning restore

        public NewRepeatingInvoicesPopUp(IWebDriver driver)
            : base(driver, "Xero | Invoices | Demo Company (NZ) ")
        {
            this.WaitForElementById("ext-gen77");
        }
        public void clickOk()
        {
            okButton.Click();
        }
    }
}
