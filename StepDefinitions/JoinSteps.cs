using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Assist;
using TestProject1.Helpers;

namespace TestProject1.StepDefinitions
{
    [Binding]
    public class JoinSteps
    {
        private DriverHelper _driverHelper;
        public JoinSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;

        //[Given(@"I navigate to join application")]
        //public void GivenINavigateToJoinApplication()
        //{
        //    _driverHelper.Driver.Navigate().GoToUrl("https://www.rewards4racing.com/my-account/profile");

        //    Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//body/div[1]/div/button[@class='wpcc-btn']")));
        //    _driverHelper.Driver.FindElement(By.XPath("//body/div[1]/div/button[@class='wpcc-btn']")).Click();
        //}

        [Given(@"I click the join link")]
        public void GivenIClickTheJoinLink()
        {
            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("btn-join")));

            _driverHelper.Driver.FindElement(By.Id("btn-join")).Click();
            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("name-join")));

        }

        [Given(@"I enter name, email and password")]
        public void GivenIEnterNameEmailAndPassword(Table table)
        {
            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {
                _driverHelper.Driver.FindElement(By.Id("name-join")).SendKeys(users.Name);
                _driverHelper.Driver.FindElement(By.Id("email-join")).SendKeys(users.Email);
                _driverHelper.Driver.FindElement(By.Id("custom-password-field")).SendKeys(users.Password);
            }
        }

        [Given(@"I click join now")]
        public void GivenIClickJoinNow()
        {
            _driverHelper.Driver.FindElement(By.Id("join")).Click();

            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("question-popup")));
        }

        [Then(@"I should see user has joined successfully")]
        public void ThenIShouldSeeUserHasJoinedSuccessfully()
        {
            _driverHelper.Driver.FindElement(By.XPath("//*[@id='question-popup']/div/div/div/div[1]/button")).Click();

            Wait(10).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("memberid")));

            IWebElement memberId = _driverHelper.Driver.FindElement(By.Id("memberid"));
            string memberNumber = memberId.GetAttribute("value");
            Assert.IsNotNull(memberNumber);
        }

        public WebDriverWait Wait(int sec)
        {
            WebDriverWait wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(sec));

            return wait;
        }
    }
}
