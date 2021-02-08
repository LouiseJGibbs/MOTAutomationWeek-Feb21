using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Challenge_3.PageObjects
{

    public class AdminPage : BasePage
    {

        private IWebElement loginHeader
        {
            get { return Driver.FindElement(By.XPath("//h2[@data-testid='login-header']")); }
        }

        private IWebElement adminUsernameTextbox
        {
            get { return Driver.FindElement(By.Id("username")); }
        }
        private IWebElement adminPasswordTextbox
        {
            get { return Driver.FindElement(By.Id("password")); }
        }

        private IWebElement adminLoginButton
        {
            get { return Driver.FindElement(By.Id("doLogin")); }
        }


        public AdminPage(IWebDriver driver) : base(driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                return driver.FindElement(By.Id("root")).Displayed;
            });
        }


        public string getLoginHeader()
        {
            return loginHeader.Text;
        }

        public bool checkUserNameTextboxDisplayed()
        {
            return adminUsernameTextbox.Displayed;
        }

        public bool checkPasswordTextboxDisplayed()
        {
            return adminPasswordTextbox.Displayed;
        }

        public string getUserNameTextbox()
        {
            return adminLoginButton.GetAttribute("placeholder");
        }

        public bool checkLoginButtonVisible()
        {
            return adminLoginButton.Displayed;
        }

        public string getLoginButtonText()
        {
            return adminLoginButton.Text;
        }
    }
}
