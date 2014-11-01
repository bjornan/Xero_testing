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
        string invoiceName = "Bank West";
        string invoiceDueDate = "5";
        int nrOfInvoices;



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
            newRepeatingInvoicePage.setSaveAsDraft();
            newRepeatingInvoicePage.ChooseItem("BOOK");
            //invoicePage = newRepeatingInvoicePage.clickSave();


        }
        [When(@"I press save")]
        public void WhenIPressSave()
        {
            invoicePage = newRepeatingInvoicePage.clickSave();
        }

        [Then(@"the result should be an repeating invoice with correct data")]
        public void ThenTheResultShouldBeAnRepeatingInvoiceWithCorrectData()
        {
            ReadOnlyCollection<IWebElement> invoiceTable = invoicePage.getInvoiceTable();
            int nrOfInvoicesAfter = invoiceTable.Count;
            Assert.AreNotEqual(nrOfInvoices, nrOfInvoicesAfter, "Repeating invoice has not been added");
            Assert.AreEqual(nrOfInvoices+1, nrOfInvoicesAfter,"Repeating invoice has not been added");
            Boolean found = false;
            int i = 0;
            string hrefString = null;
            string invoiceId;
            foreach (IWebElement row in invoiceTable)
            {
                ReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                i++;
                if(cells[1].Text.Equals(invoiceName))
                {
                    found = true;
                    hrefString = cells[1].GetAttribute("href");
                    invoicePage.SelectInvoice(i);
                }
                foreach (IWebElement cell in cells)
                {
                    Console.WriteLine("\t" + cell.Text);
                }
            }
            Assert.IsTrue(found, "Couldn't find the object");
            //href="/RepeatTransactions/Edit.aspx?invoiceID=30997468-1b95-4948-891b-1766cfd94fec
            if(hrefString != null)
            {
                int start = hrefString.IndexOf("=");
                invoiceId = hrefString.Substring(start + 1, hrefString.Length);
            //TODO: Call api with the invoice id....
            }
            
            Thread.Sleep(5000);
            invoicePage.ClickDelete();

            
        }
    }
}
