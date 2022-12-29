using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestProject1.Helpers;
using OpenQA.Selenium.Remote;

namespace TestProject1.Drivers
{
    public class RemoteDriver
    {
        private DriverHelper _driverHelper;
        private TestName _name;
        public RemoteDriver(DriverHelper driverHelper, TestName name)
        {
            _driverHelper = driverHelper;
            _name = name;
        }

        static readonly string userName = "";
        static readonly string accessKey = "";
        static readonly string gridURL = "@hub.lambdatest.com/wd/hub";
        public IWebDriver SelectDriver(string browser)
        {
            return browser switch
            {
                "Chrome" => RemoteChromeWebDriver(),
                "IE" => RemoteInternetExplorerWebDriver(),
                "Firefox" => RemoteFirefoxWebDriver(),
                "Edge" => RemoteEdgeWebDriver(),
                { } otherBrowser => throw new NotSupportedException($"{otherBrowser} is not a supported browser"),
                _ => throw new NotSupportedException("not supported browser: <null>")
            };
        }

        private IWebDriver RemoteChromeWebDriver()
        {
            string testName = _name.Name;
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "106.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", userName);
            ltOptions.Add("accessKey", accessKey);
            ltOptions.Add("video", true);
            ltOptions.Add("platformName", "Windows 10");
            ltOptions.Add("build", "Build 1.0");
            ltOptions.Add("name", testName);
            ltOptions.Add("selenium_version", "4.0.0");
            ltOptions.Add("w3c", true);
            capabilities.AddAdditionalOption("LT:Options", ltOptions);

            _driverHelper.Driver = new RemoteWebDriver(new Uri("https://" + userName + ":" + accessKey + gridURL), capabilities);

            return _driverHelper.Driver;
        }

        private IWebDriver RemoteInternetExplorerWebDriver()
        {
            // Remote I.E settings goes here
            return _driverHelper.Driver;
        }

        private IWebDriver RemoteFirefoxWebDriver()
        {
            // Remote I.E settings goes here
            return _driverHelper.Driver;
        }

        private IWebDriver RemoteEdgeWebDriver()
        {
            // Remote I.E settings goes here
            return _driverHelper.Driver;
        }


    }
}
