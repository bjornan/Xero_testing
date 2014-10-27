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
    public class TopToolbar:BasePage
    {
        #pragma warning disable
        [FindsBy(How = How.Id, Using = "Dashboard")]
        [CacheLookup]
        private IWebElement dashboard;

        [FindsBy(How = How.Id, Using = "Accounts")]
        [CacheLookup]
        private IWebElement accounts;

        [FindsBy(How = How.Id, Using = "Reports")]
        [CacheLookup]
        private IWebElement reports;

        [FindsBy(How = How.Id, Using = "Adviser")]
        [CacheLookup]
        private IWebElement adviser;

        [FindsBy(How = How.Id, Using = "Contacts")]
        [CacheLookup]
        private IWebElement contacts;

        [FindsBy(How = How.Id, Using = "Settings")]
        [CacheLookup]
        private IWebElement settings;

#pragma warning restore

       

        public TopToolbar(IWebDriver driver)
            : base(driver, "  ")
        {
    
        }
        public AccountsPage clickAccounts()
        {
            accounts.Click();
            var _accountsPage = new AccountsPage(this.driver);
            PageFactory.InitElements(driver, _accountsPage);
            return _accountsPage;
        }

        public DashBoardPage clickDashboard()
        {
            dashboard.Click();
            var _dashBoardPage = new DashBoardPage(this.driver);
            PageFactory.InitElements(driver, _dashBoardPage);
            return _dashBoardPage;
        }
    }
}
