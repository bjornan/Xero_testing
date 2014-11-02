using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Xero_testing.Selenium.PageObjects
{
    public class AccountsPage:BasePage
    {
        #pragma warning disable
        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement email;

       [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        public IWebElement password;

         [FindsBy(How = How.Id, Using = "submitButton")]
        [CacheLookup]
        public IWebElement submitButton;

        public AccountsPage(IWebDriver driver)
            : base(driver, "Login | Xero Accounting Software")
        {          
            this.WaitForElementById("login");
        }
    }
}
