using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using TestProject1.Helpers;

namespace TestProject1.Drivers
{
    public class SeleniumDriver
    {
        private DriverHelper _driverHelper;
        public SeleniumDriver(DriverHelper driverHelper) => _driverHelper = driverHelper;

        public IWebDriver SelectDriver(string browser)
        {
            return browser switch
            {
                "Chrome" => CreateChromeWebDriver(),
                "IE" => CreateInternetExplorerWebDriver(),
                "Firefox" => CreateFirefoxWebDriver(),
                "Edge" => CreateEdgeWebDriver(),
                { } otherBrowser => throw new NotSupportedException($"{otherBrowser} is not a supported browser"),
                _ => throw new NotSupportedException("not supported browser: <null>")
            };
        }

        private IWebDriver CreateChromeWebDriver()
        {
            var headlessEnvVar = Environment.GetEnvironmentVariable("HeadlessBrowserTests");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            if (headlessEnvVar != null && headlessEnvVar.ToLower().Equals("true"))
                options.AddArgument("headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driverHelper.Driver = new ChromeDriver(options);

            return _driverHelper.Driver;
        }

        private IWebDriver CreateInternetExplorerWebDriver()
        {
            // Driver options go here
            return _driverHelper.Driver;
        }

        private IWebDriver CreateFirefoxWebDriver()
        {
            // Driver options go here
            return _driverHelper.Driver;
        }

        private IWebDriver CreateEdgeWebDriver()
        {
            // Driver options go here
            return _driverHelper.Driver;
        }

    }
}
