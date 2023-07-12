

using FluentAssertions;
using LabCorp.Drivers;
using LabCorp.pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LabCorp.Steps;

[Binding]
public sealed class TaskOneSteps
{
    private IWebDriver _webDriver;
    private ScenarioContext _scenarioContext;
    

    public TaskOneSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

   

    [Given(@"user is on Lab Corp website")]
    public void GivenUserIsOnLabCorpWebsite()
    {
        _webDriver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").getDriver();
        _webDriver.Url = "https://www.labcorp.com/";
        _webDriver.Url.Should().Be("https://www.labcorp.com/");
    }

    [Given(@"user navigates to career page")]
    public void GivenUserNavigatesToCareerPage()
    {
        HomePage homePage = new HomePage(_webDriver);
        homePage.NavigateToCareerPage();
    }
}