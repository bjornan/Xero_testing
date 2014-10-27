using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Xero_testing.Selenium.PageObjects.Accounts;

namespace Xero_testing.Selenium.PageObjects
{
    public class DashBoardPage : BasePage
    {

#pragma warning disable
        [FindsBy(How = How.XPath, Using = "//form[@name='frmMain']//a[@href='/Accounts/Receivable/Dashboard/']")]
        [CacheLookup]
        public IWebElement goToSalesLink;

        [FindsBy(How = How.Id, Using = "OG_Glossary_AccountWatchlist")]
        [CacheLookup]
        public IWebElement goToChartOfAccountLink;

        [FindsBy(How = How.Id, Using = "OG_Glossary_GraphMoneyOut")]
        [CacheLookup]
        public IWebElement goToPurchaseLink;

#pragma warning restore
        public TopToolbar topToolBar;


        public DashBoardPage(IWebDriver driver)
            : base(driver, "Xero | Dashboard | Demo Company (NZ) ")
        {
            topToolBar = new TopToolbar(driver);
            PageFactory.InitElements(driver, topToolBar);
            this.WaitForElementById("Dashboard");
        }
        public SalesPage clickOnGoToSalesLink()
        {
            goToSalesLink.Click();
            var _SalesPage = new SalesPage(this.driver);
            PageFactory.InitElements(driver, _SalesPage);
            return _SalesPage;

        }

    }
}
