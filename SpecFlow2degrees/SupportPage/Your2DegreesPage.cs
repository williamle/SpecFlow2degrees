using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using SpecFlow2degrees.Driver;

namespace SpecFlow2degrees.SupportPage
{
    internal class Your2DegreesPage
    {
        private static String Url = "https://www.2degreesmobile.co.nz/your2degrees";
        public new static IWebDriver _WebDriver;

        // Web elements by Selenium
        [FindsBy(How = How.XPath, Using = "//*[@id='userid']")] private IWebElement FieldYourMobileNumberElement;
        [FindsBy(How = How.XPath, Using = "//*[@id='password']")] private IWebElement FieldYourPassworElement;
        [FindsBy(How = How.ClassName, Using = "top_welcome")] private IWebElement BannerTopWelcomeElement;
        [FindsBy(How = How.XPath, Using = "//*[@id='login']")] private IWebElement ButtonLoginElement;

        [FindsBy(How = How.XPath,
            Using = "/html/body/div[5]/div[7]/div/div/div/div/div/div/div/div/div/div/div/p/strong")] private
            IWebElement ProductTypeElement;

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[7]/div/div/div/div/div/div/div/div/div/div/div/p")] private IWebElement DisplayMobileNoElement;

        public Your2DegreesPage()
        {
            //_BaseWebDriver.LoadWebDriver();

            var baseWebDriver = new BaseWebDriver();
            baseWebDriver.LoadWebDriver(Url);
            PageFactory.InitElements(BaseWebDriver.Driver, this);
        }

        //--------------------------------------------------------------------------------------//
        /*** Validation **/
        public void ValidateBeforeLogin()
        {
            Assert.AreEqual("Your mobile number", FieldYourMobileNumberElement.GetAttribute("placeholder"));
            Assert.AreEqual(true, FieldYourMobileNumberElement.Displayed);
            Assert.AreEqual(true, FieldYourMobileNumberElement.Enabled);
            Assert.AreEqual("Your password", FieldYourPassworElement.GetAttribute("placeholder"));
            Assert.AreEqual(true, FieldYourPassworElement.Displayed);
            Assert.AreEqual(true, FieldYourPassworElement.Enabled);
            Assert.AreEqual(true, BannerTopWelcomeElement.Text.Contains("Welcome to\r\nYour 2degrees"));
            Assert.AreEqual(true, ButtonLoginElement.Enabled);
            //Console.WriteLine(TopBannerElement.Text);
        }

        public void ValidateLoginInput()
        {
            Assert.AreEqual(true, FieldYourMobileNumberElement.GetAttribute("value") != null);
            Assert.AreEqual(true, FieldYourPassworElement.GetAttribute("value") != null);
            Assert.AreEqual(true, ButtonLoginElement.Enabled);
            Assert.AreEqual("Log in to Your 2degrees Account", ButtonLoginElement.GetAttribute("value"));
        }

        public void ValidateProdTypeAfterLogin()
        {
            Assert.AreEqual(true, ProductTypeElement.Text.Contains("Prepay Plus"));
        }

        public void ValidateMobNoAfterLogin()
        {
            Assert.AreEqual(true, DisplayMobileNoElement.Text.Contains("022 040 6949"));
        }

        //-------------------------------------------------------------------------------------//
        /*** Methods to interact with site **/
        public void SendMobileNumber(string mobileNumber)
        {
            FieldYourMobileNumberElement.SendKeys(mobileNumber);
        }

        public void SendPassword(string pwd)
        {
            FieldYourPassworElement.SendKeys(pwd);
        }

        public void LoginYour2Degrees()
        {
            ButtonLoginElement.Click();
        }

    }
}