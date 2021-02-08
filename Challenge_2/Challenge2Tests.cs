using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Challenge_2
{
    //    Welcome to UI Automation Challenge 2
    //
    //    For this challenge it's all about creating clean, readable and maintainable code. Below
    //    are five tests that work (just about) but require cleaning up. Update this code base
    //    so that it's easier to maintain, more readable, and has sensible ways of asserting
    //    data. You might want to research different approaches to improving UI automation such as
    //    Page Object Models and implicit vs. explicit waits, as well as NUnit features that can make things
    //    easier to maintain

    public class Challenge2Tests
    {
        IWebDriver driver;
        string baseUrl = "https://automationintesting.online";

        IWebElement adminFooterLink => driver.FindElement(By.CssSelector("footer p a:nth-child(5)"));

        //Admin
        IWebElement adminNameTextbox => driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input"));
        IWebElement adminPasswordTextbox => driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input"));
        IWebElement adminLoginButton => driver.FindElement(By.ClassName("float-right"));
        IWebElement adminHeader => driver.FindElement(By.ClassName("navbar-collapse"));

        //Admin Room
        IWebElement createRoomPage_roomNumber => driver.FindElement(By.CssSelector(".room-form > div:nth-child(1) input"));
        IWebElement createRoomPage_roomPrice => driver.FindElement(By.CssSelector(".room-form > div:nth-child(4) input"));
        IWebElement createRoomPage_Button => driver.FindElement(By.ClassName("btn-outline-primary"));
        IReadOnlyCollection<IWebElement> createRoomPage_RoomList => driver.FindElements(By.XPath("//div[@data-type='room']"));


        //Branding
        IWebElement BrandName => driver.FindElement(By.ClassName("form-control"));
        IWebElement SubmitNewBranding => driver.FindElement(By.ClassName("btn-outline-primary"));
        IReadOnlyCollection<IWebElement> CloseBrandingUpdatedButton => driver.FindElements(By.XPath("//button[text()=\"Close\"]"));


        //ContactUs Form
        IWebElement ContactUsName => driver.FindElement(By.CssSelector("input[placeholder=Name]"));
        IWebElement ContactUsEmail => driver.FindElement(By.CssSelector("input[placeholder=Email]"));
        IWebElement ContactUsPhone => driver.FindElement(By.CssSelector("input[placeholder=Phone]"));
        IWebElement ContactUsSubject => driver.FindElement(By.CssSelector("input[placeholder=Subject]"));
        IWebElement ContactUsText => driver.FindElement(By.CssSelector("textarea"));
        IWebElement ContactUsSubmitButton => driver.FindElement(By.XPath("//button[text()=\"Submit\"]"));
        IWebElement ContactUsSuccessfulMessage => driver.FindElement(By.CssSelector(".contact"));

        //Admin messages
        IReadOnlyCollection<IWebElement> UnreadMessages => driver.FindElements(By.CssSelector(".read-false"));

        [SetUp]
        public void SetupWebDriver()
        {
            driver = new ChromeDriver();
            GoToBasePage();
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }

        //  Test one: Check to see if you can log in with valid credentials
        [Test]
        public void VerifyCanLoginWithValidCredentials()
        {
            LoginToAdmin();
            Thread.Sleep(5000);
            Assert.IsTrue(adminHeader.Text.Contains("Rooms"));

            #region original code

            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Url = "https://automationintesting.online/#/admin";
            //driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            //Thread.Sleep(1000);
            //driver.FindElement(By.ClassName("float-right")).Click();

            //Thread.Sleep(5000);

            //IWebElement webElement = driver.FindElement(By.ClassName("navbar-collapse"));
            //Console.WriteLine(webElement.Text);
            //Boolean title = webElement.Text.Contains("Rooms");

            //Assert.IsTrue(title);
            //driver.Close();

            #endregion
        }

        //  Test two: Check to see if rooms are saved and displayed in the UI
        [Test]
        public void VerifyRoomsAreSavedAndDisplayedInUI()
        {
            LoginToAdmin();

            Thread.Sleep(2000);

            int countBefore = createRoomPage_RoomList.Count;

            CreateRoom();

            Thread.Sleep(5000);

            int countAfter = createRoomPage_RoomList.Count;

            Assert.AreEqual(countBefore + 1, countAfter);

            #region original code
            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Url = "https://automationintesting.online/#/admin";
            //driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            //Thread.Sleep(1000);
            //driver.FindElement(By.ClassName("float-right")).Click();

            //Thread.Sleep(5000);

            //driver.FindElement(By.CssSelector(".room-form > div:nth-child(1) input")).SendKeys("101");
            //driver.FindElement(By.CssSelector(".room-form > div:nth-child(4) input")).SendKeys("101");
            //Thread.Sleep(1000);
            //driver.FindElement(By.ClassName("btn-outline-primary")).Click();

            //Thread.Sleep(5000);

            //Assert.That(driver.FindElements(By.ClassName(".detail")).Count != 1);
            //driver.Close();

            #endregion
        }


        //  Test three: Check to see the confirm message appears when branding is updated
        [Test]
        public void VerifyConfirmMessageAppearsWhenBrandingIsUpdated()
        {
            LoginToAdmin();

            GoToBrandingPage();

            Thread.Sleep(5000);

            BrandName.SendKeys("Test");
            SubmitNewBranding.Click();

            Thread.Sleep(1000);

            Assert.AreEqual(1, CloseBrandingUpdatedButton.Count);

            #region original code

            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Url = "https://automationintesting.online/#/admin";
            //driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            //Thread.Sleep(1000);
            //driver.FindElement(By.ClassName("float-right")).Click();

            //driver.Url = "https://automationintesting.online/#/admin/branding";

            //Thread.Sleep(5000);

            //driver.FindElement(By.ClassName("form-control")).SendKeys("Test");
            //driver.FindElement(By.ClassName("btn-outline-primary")).Click();

            //Thread.Sleep(1001);

            //int count = driver.FindElements(By.XPath("//button[text()=\"Close\"]")).Count;

            //if (count == 1)
            //{
            //    Assert.Pass();
            //}
            //else
            //{
            //    Assert.Fail();
            //}
            //driver.Close();

            #endregion
        }

        //  Test four: Check to see if the contact form shows a success message
        [Test]
        public void VerifyContactFormShowsSuccessMessage()
        {
            GoToBasePage();
            Thread.Sleep(1000);
            CompleteContactUsForm();
            Thread.Sleep(2000);
            Assert.IsTrue(ContactUsSuccessfulMessage.Text.Contains("Thanks for getting in touch"));

            #region original code

            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Url = "https://automationintesting.online/";
            //Thread.Sleep(1000);
            //driver.FindElement(By.CssSelector("input[placeholder=Name]")).SendKeys("TEST123");
            //driver.FindElement(By.CssSelector("input[placeholder=Email]")).SendKeys("TEST123@TEST.COM");
            //driver.FindElement(By.CssSelector("input[placeholder=Phone]")).SendKeys("01212121311");
            //driver.FindElement(By.CssSelector("input[placeholder=Subject]")).SendKeys("TEsTEST");
            //driver.FindElement(By.CssSelector("textarea")).SendKeys("TEsTESTTEsTESTTEsTEST");
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//button[text()=\"Submit\"]")).Click();

            //Thread.Sleep(4000);
            //Assert.True(driver.FindElement(By.CssSelector(".contact")).Text.Contains("Thanks for getting in touch"));
            //driver.Close();

            #endregion
        }

        //  Test five: Check to see if unread messages are bolded
        [Test]
        public void VerifyUnreadMessagesAreBolded()
        {
            CompleteContactUsForm();
            LoginToAdmin();
            GoToMessagesPage();
            Thread.Sleep(3000);
            Assert.GreaterOrEqual(UnreadMessages.Count, 1);

            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Url = "https://automationintesting.online/#/admin/messages";
            
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            //Thread.Sleep(1000);
            //driver.FindElement(By.ClassName("float-right")).Click();

            //Thread.Sleep(3000);
            //Assert.True(CheckCount(driver.FindElements(By.CssSelector(".read-false"))));
            //driver.Close();
        }

        private bool CheckCount(IReadOnlyCollection<IWebElement> elements)
        {
            if (elements.Count >= 1)
            {
                return true;
            }

            return false;
        }

        #region Navigate to pages

        public void GoToBasePage()
        {
            driver.Url = baseUrl;
        }

        public void GoToAdminPage()
        {
            driver.Url = baseUrl + "/#/admin";
        }

        public void GoToBrandingPage()
        {
            driver.Url = baseUrl + "/#/admin/branding";
        }

        public void GoToMessagesPage()
        {
            driver.Url = baseUrl + "/#/admin/messages";
        }

        #endregion

        public void LoginToAdmin()
        {
            GoToAdminPage();

            adminNameTextbox.SendKeys("admin");
            adminPasswordTextbox.SendKeys("password");
            adminLoginButton.Click();
        }

        public void CreateRoom()
        {
            createRoomPage_roomNumber.SendKeys("101");
            createRoomPage_roomPrice.SendKeys("101");
            createRoomPage_Button.Click();
        }

        public void CompleteContactUsForm()
        {
            ContactUsName.SendKeys("TEST123");
            ContactUsEmail.SendKeys("TEST123@TEST.COM");
            ContactUsPhone.SendKeys("01212121311");
            ContactUsSubject.SendKeys("TEsTEST");
            ContactUsText.SendKeys("TEsTESTTEsTESTTEsTEST");

            ContactUsSubmitButton.Click();
        }
    }
}