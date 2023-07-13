using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--start-maximized");

        _driver = new ChromeDriver(chromeOptions);
        _scenarioContext.Set(_driver, "webDriver");

        return _driver;
    }
}