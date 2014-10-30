using System;
using TechTalk.SpecFlow;
using Xero_testing.Selenium;
using Xero_testing.Selenium.PageObjects;
using Xero_testing.Selenium.PageObjects.Accounts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections;
using NUnit.Framework;


namespace Xero_testing.BDDTests
{
    [Binding]
    public class RepeatingInvoicesSteps
    {
        IWebDriver driver;
        LoginPage loginPage;
        InvoicesPage invoicePage;
        NewRepeatingInvoicePage newRepeatingInvoicePage;
        string invoiceName = "";
        string refNumber = "123456";
        string invoiceDueDate = "5";
        int nrOfInvoices;
        string description = "A description";



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
            invoicePage = salesPage.clickOnRepeating();
            nrOfInvoices = invoicePage.nrOfInvoices();
            newRepeatingInvoicePage = invoicePage.clickNewRepeatingInvoice();

        }

        [Given(@"I have entered all required parameters")]
        public void GivenIHaveEnteredAllRequiredParameters()
        {
            
            newRepeatingInvoicePage.selectInvoiceDateToday();
            newRepeatingInvoicePage.setDueDate(invoiceDueDate);
            newRepeatingInvoicePage.setInvoiceTo(invoiceName);
            newRepeatingInvoicePage.setReference(refNumber);
            newRepeatingInvoicePage.setRandomItem();
            newRepeatingInvoicePage.setDescription(description);
            newRepeatingInvoicePage.setQuantity("1");

            invoicePage = newRepeatingInvoicePage.clickSave();


        }

        [Then(@"the result should be an repeating invoice with correct data")]
        public void ThenTheResultShouldBeAnRepeatingInvoiceWithCorrectData()
        {

            ReadOnlyCollection<IWebElement> invoiceTable = invoicePage.getInvoiceTable();
            //Assert.AreEqual("",invoiceTable[2].)
            Thread.Sleep(5000);
        }
    }
}
