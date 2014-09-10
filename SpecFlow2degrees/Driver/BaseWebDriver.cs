using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlow2degrees.Driver
{
    public class BaseWebDriver
    {
        public static IWebDriver Driver;

        public string TargetUrl; 

        //Load Webdriver
        public void LoadWebDriver(String loadUrl = "")
        {
            Driver = new FirefoxDriver();
            TargetUrl = loadUrl;
            Driver.Navigate().GoToUrl(TargetUrl);
        }

        //Close Webdriver
        public static void CloseWebDriver()
        {
            Driver.Close();
        }
    }
}
