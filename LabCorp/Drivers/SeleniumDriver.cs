using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace LabCorp.Drivers;

public class SeleniumDriver
{
    private IWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public SeleniumDriver(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    public IWebDriver getDriver()
    {
        var chromeOptions = new ChromeDriver();
        
        _driver = new RemoteWebDriver(new Uri("www.labcorp.com"), chromeOptions.Capabilities);
        
        _scenarioContext.Set(_driver, "webDriver");
        
        _driver.Manage().Window.Maximize();

        return _driver;
    }
}