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
}