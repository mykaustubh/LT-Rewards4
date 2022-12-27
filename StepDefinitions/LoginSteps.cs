using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Assist;
using TestProject1.Helpers;

namespace TestProject1.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private DriverHelper _driverHelper;
        public LoginSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [Given(@"I navigate to (.*)")]
        public void GivenINavigateToHomepage(string homepage)
        {
            _driverHelper.Driver.Navigate().GoToUrl(homepage);

            WebDriverWait wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//body/div[1]/div/button[@class='wpcc-btn']")));
            _driverHelper.Driver.FindElement(By.XPath("//body/div[1]/div/button[@class='wpcc-btn']")).Click();
        }

        [Given(@"I click the Sign In link")]
        public void GivenIClickTheSignInLink()
        {
            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("btn-signin")));

            _driverHelper.Driver.FindElement(By.Id("btn-signin")).Click();
            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("email")));
        }

        [Given(@"I enter (.*) and (.*)")]
        public void GivenIEnterAnd(string email, string password)
        {
            _driverHelper.Driver.FindElement(By.Id("email")).SendKeys(email);
            _driverHelper.Driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            _driverHelper.Driver.FindElement(By.Id("login")).Click();
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("greeting-msg")));

            IWebElement greetingMsg = _driverHelper.Driver.FindElement(By.Id("greeting-msg"));
            string text = greetingMsg.Text;
            Assert.IsTrue(text.Contains("Example3"));
        }
        public WebDriverWait Wait(int sec)
        {
            WebDriverWait wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(sec));

            return wait;
        }

    }
}
