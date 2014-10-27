using System;
using TechTalk.SpecFlow;
using Xero_testing.Selenium;
using Xero_testing.Selenium.PageObjects;
using Xero_testing.Selenium.PageObjects.Accounts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Xero_testing.BDDTests
{
    [Binding]
    public class RepeatingInvoicesSteps
    {
        IWebDriver driver;
        LoginPage loginPage;



        [Given(@"I have created a new repeating invoice")]
        public void GivenIHaveCreatedANewRepeatingInvoice()
        {
            WebBrowser.Current.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            WebBrowser.Current.Navigate().GoToUrl("https://login.xero.com/");
            driver = WebBrowser.Current;
            loginPage = new LoginPage(driver);
            PageFactory.InitElements(driver, loginPage);
            loginPage.SetEmail("all.good.names.are.occupied@gmail.com");
            loginPage.SetPassword("123Xero1");
            DashBoardPage dashBoard = loginPage.ClickSave();
            dashBoard = dashBoard.topToolBar.clickDashboard();
            SalesPage salesPage = dashBoard.clickOnGoToSalesLink();
            InvoicesPage invoicePage = salesPage.clickOnRepeating();

        }

        [Given(@"I have entered all required parameters")]
        public void GivenIHaveEnteredAllRequiredParameters()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be an repeating invoice with correct data")]
        public void ThenTheResultShouldBeAnRepeatingInvoiceWithCorrectData()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
