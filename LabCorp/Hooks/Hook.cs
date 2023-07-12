using LabCorp.Drivers;
using OpenQA.Selenium;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
        _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _scenarioContext.Get<IWebDriver>("webDriver").Quit();
    }
}