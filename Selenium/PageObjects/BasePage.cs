using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections.ObjectModel;


namespace Xero_testing.Selenium.PageObjects
{
    public class BasePage
    {

        protected IWebDriver driver;
        private readonly string WebUrl = null;
        private int timeout = 60;

        protected BasePage(IWebDriver driver, String title)
        {
            this.driver = WebBrowser.Current;
            this.driver = driver;
        }

        public void GoToSite()
        {
            driver.Navigate().GoToUrl(WebUrl);
        }
        public void WaitForElementById(string el_id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.FindElement(By.Id(el_id)));
        }
        public void WaitForElementByXPath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.FindElement(By.XPath(xpath)));
        }
        public void WaitForTitle(string title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            //var titleOfPage = driver.Title;
            string existingWindowHandle = driver.CurrentWindowHandle;
            string popupHandle = string.Empty;
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    popupHandle = handle; break;
                }
            }

            //switch to new window 
            driver.SwitchTo().Window(popupHandle);
            wait.Until(d => d.Title == title);
        }
        public void WaitForTitleThatContains(string title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.Title.Contains(title));
        }
        public void WaitForTitleThatStartsWith(string title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.Title.StartsWith(title));
        }
        public void WaitForElementClickable(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ElementIsClickable(By.Id("id")));
            //wait.Until(d => d.FindElement(By.Id(id)));
            //wait.Until(ExpectedConditions.elementToBeClickable(ById("element"));
        }
        protected void clickOptionInList(string listControlId, string optionText)
        {
            driver.FindElement(By.XPath("//select[@id='" + listControlId + "']/option[contains(.,'" + optionText + "')]")).Click();
        }
        /// <summary>
        /// An expectation for checking whether an element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
        private static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}
