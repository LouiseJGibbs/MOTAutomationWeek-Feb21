using Challenge_3.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Challenge_3
{
    //    Welcome to UI Automation Challenge 3
    //
    //    For this challenge the focus is improving the assertion for an existing
    //    UI automation test. Rather than asserting on the DOM's state, update the
    //    the test below to do a visual check of the page. Once you've completed
    //    the sample check, create your own example check.

    public class Challenge3Tests
    {
        IWebDriver driver;
        string url = "https://automationintesting.online/";

        [SetUp]
        public void StartDriver()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

        [Test]
        public void CheckHomePageData()
        {
            driver.Url = url;
            HomePage homePage = new HomePage(driver);

            string imgUrl = homePage.GetHotelLogo().GetAttribute("src");
            Assert.AreEqual("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);

            int roomImageCount = homePage.GetRoomImageCount();
            Assert.AreEqual(1, roomImageCount);



            int mapCounts = homePage.GetMapImageCount();
            Assert.AreEqual(16, mapCounts);
        }

        [Test]
        public void CheckAdminLoginPage()
        {
            driver.Url = url + "/#/admin";
            AdminPage adminPage = new AdminPage(driver);

            Assert.AreEqual("Log into your account", adminPage.getLoginHeader());

            Assert.True(adminPage.checkUserNameTextboxDisplayed(), "Username textbox is not visble");
            Assert.True(adminPage.checkPasswordTextboxDisplayed(), "Password textbox is not visible");

            Assert.True(adminPage.checkLoginButtonVisible(), "Login button is not visible");
        
        }
    }
}