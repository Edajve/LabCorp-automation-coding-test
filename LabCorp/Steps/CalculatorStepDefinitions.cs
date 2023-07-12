

using LabCorp.Drivers;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LabCorp.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private IWebDriver _webDriver;
    private ScenarioContext _scenarioContext;
    

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        _webDriver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").getDriver();
        _webDriver.Url = "https://www.labcorp.com/";
    }

    [Then(@"validate")]
    public void ThenValidate()
    {
        Assert.True(true);
    }
}