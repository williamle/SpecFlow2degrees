using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SpecFlow2degrees.Driver;
using SpecFlow2degrees.SupportPage;
using TechTalk.SpecFlow;

namespace SpecFlow2degrees.StepsDefinition
{
    [Binding]
    public class LoginSteps: BaseWebDriver
    {
        private static Your2DegreesPage _your2DegreesPage;
        private static IWebDriver _driver;

        [BeforeScenario("Login")]
        public static void SetUp()
        {
            _your2DegreesPage = new Your2DegreesPage();
        }

        [AfterScenario("Login")]
        public static void TearDown()
        {
            BaseWebDriver.CloseWebDriver();
        }

        [Given(@"I am on Your2degrees login page")]
        public void GivenIAmOnYourdegreesLoginPage()
        {
            _your2DegreesPage.ValidateBeforeLogin();
        }
        
        [Given(@"I have my login credentials as below")]
        public void GivenIHaveMyLoginCredentialsAsBelow(Table table)
        {
            //Console.WriteLine(table.Rows[0]["Your Mobile Number"] + table.Rows[0]["Password"]);
            foreach (TableRow row in table.Rows)
            {
                if (row["Your Mobile Number"].Contains("0220406949"))
                {
                    _your2DegreesPage.SendMobileNumber(row["Your Mobile Number"]);
                    _your2DegreesPage.SendPassword(row["Password"]);
                }
            }
        }
        
        [When(@"I enter my login details")]
        public void WhenIEnterMyLoginDetails()
        {
            _your2DegreesPage.ValidateLoginInput();
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string p0)
        {
            _your2DegreesPage.LoginYour2Degrees();
        }
        
        [Then(@"I should see my product type")]
        public void ThenIShouldSeeMyProductType()
        {
           _your2DegreesPage.ValidateProdTypeAfterLogin();
        }
        
        [Then(@"I should see my mobile number")]
        public void ThenIShouldSeeMyMobileNumber()
        {
            _your2DegreesPage.ValidateMobNoAfterLogin();
        }
        
        [Then(@"I should see the summary of my balances as below")]
        public void ThenIShouldSeeTheSummaryOfMyBalancesAsBelow(Table table)
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
