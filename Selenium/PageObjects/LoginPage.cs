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
    public class LoginPage:BasePage
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
#pragma warning restore
         public LoginPage(IWebDriver driver)
            : base(driver, "Login | Xero Accounting Software")
        {

            this.WaitForElementById("LoginForm");
        }
        public void SetEmail(string emailtxt)
        {
            email.SendKeys(emailtxt);
        }
        public void SetPassword(string passwordtxt)
        {
            password.SendKeys(passwordtxt);
        }
        public DashBoardPage ClickSave()
        {
            submitButton.Click();
            var _dashBoardPage = new DashBoardPage(this.driver);
            PageFactory.InitElements(driver, _dashBoardPage);
            return _dashBoardPage;
        }
    }
}
  
