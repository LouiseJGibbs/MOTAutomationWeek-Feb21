using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Challenge_3.PageObjects
{
    public class HomePage : BasePage
    {

        private IWebElement imgHotelLogo
        {
            get { return Driver.FindElement(By.CssSelector(".hotel-logoUrl")); }
        }

        private IWebElement welcomeText
        {
            get { return Driver.FindElement(By.ClassName("row room-header")); }
        }

        private IWebElement hotelRoomInfo
        {
            get { return Driver.FindElement(By.ClassName("hotel-room-info")); }
        }

        private IWebElement hotelRoomType
        {
            get { return hotelRoomInfo.FindElement(By.XPath("//h3")); }
        }

        private IWebElement hotelRoomInformation
        { 
            get { return hotelRoomInfo.FindElement(By.XPath("//p")); }
        }

        private IReadOnlyCollection<IWebElement> hotelRoomFeatures
        {
            get { return hotelRoomInfo.FindElements(By.XPath("//ul/li")); }
        }

        private IWebElement bookThisroomButton
        {
            get { return hotelRoomInfo.FindElement(By.ClassName("openBooking")); }
        }

        private IWebElement contactForm
        {
            get { return Driver.FindElement(By.ClassName("contact")); }
        }

        private IWebElement contactName
        {
            get { return contactForm.FindElement(By.Id("Name")); }
        }

        private IWebElement contactEmail
        {
            get { return contactForm.FindElement(By.Id("Email")); }
        }

        private IWebElement contactPhone
        {
            get { return contactForm.FindElement(By.Id("Phone")); }
        }

        private IWebElement contactSubject
        {
            get { return contactForm.FindElement(By.Id("Subject")); }
        }

        private IWebElement contactMessage
        {
            get { return contactForm.FindElement(By.Id("Message")); }
        }

        private IWebElement contactSubmitButton
        {
            get { return contactForm.FindElement(By.Id("submitContact")); }
        }

        private IReadOnlyCollection<IWebElement> contactDetails
        {
            get { return contactForm.FindElements(By.XPath("//p")); }
        }
        











        private IReadOnlyCollection<IWebElement> imgRooms
        {
            get { return Driver.FindElements(By.CssSelector(".hotel-img")); }
        }

        private IReadOnlyCollection<IWebElement> imgMaps
        {
            get { return Driver.FindElements(By.CssSelector(".map img")); }
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                return driver.FindElement(By.ClassName("container-fluid")).Displayed;
            });
        }

        public IWebElement GetHotelLogo()
        {
            return imgHotelLogo;
        }

        public int GetRoomImageCount()
        {
            return imgRooms.Count;
        }

        public int GetMapImageCount()
        {
            return imgMaps.Count;
        }
    }
}
