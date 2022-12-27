using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.Drivers;
using TestProject1.Helpers;

namespace TestProject1.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        private DriverHelper _driverHelper;
        private TestName _name;
        public HookInitialization(DriverHelper driverHelper, TestName name)
        {
            _driverHelper = driverHelper;
            _name = name;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
        }

        [BeforeScenario("@join")]
        public void Join()
        {
            _name.Name = "Join Test";
        }

        [BeforeScenario(Order =1)]
        public void FirstBeforeScenario(SeleniumDriver seleniumDriver, RemoteDriver remoteDriver)
        {
            var browser = Environment.GetEnvironmentVariable("TestBrowser");
            var environment = Environment.GetEnvironmentVariable("EnvironmentName");

            if (environment != null && browser!= null)
            {
                switch (environment)
                {
                    case "Local":
                        _driverHelper.Driver = seleniumDriver.SelectDriver(browser);
                        _driverHelper.Driver.Manage().Window.Maximize();
                        break;
                    case "Remote":
                        _driverHelper.Driver = remoteDriver.SelectDriver(browser);
                        break;
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }

    }
}