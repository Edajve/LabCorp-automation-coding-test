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
    private IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private Dictionary<string, string> _individualJobApplicationDetails;
    private string allText;


    public TaskOneSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _individualJobApplicationDetails = new Dictionary<string, string>();
    }


    [Given(@"user is on Lab Corp website")]
    public void GivenUserIsOnLabCorpWebsite()
    {
        _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").getDriver();
        _driver.Url = "https://www.labcorp.com/";
        _driver.Url.Should().Be("https://www.labcorp.com/");
    }

    [Given(@"user navigates to career page")]
    public void GivenUserNavigatesToCareerPage()
    {
        HomePage homePage = new HomePage(_driver);
        homePage.NavigateToCareerPage();
    }

    [Then(@"user searches for ""(.*)"" Career position")]
    public void ThenUserSearchesForCareerPosition(string position)
    {
        CareerPage careerPage = new CareerPage(_driver);
        careerPage.SearchCareerPosition(position);
        careerPage.ClickFirstApplication();
    }

    [Then(@"user returns back to list of applications")]
    public void ThenUserReturnsBackToListOfApplications()
    {
        JobApplicationPage jobApplicationPage = new JobApplicationPage(_driver);
        _individualJobApplicationDetails = jobApplicationPage.GetAssertionMapForIndividualApplication();
        jobApplicationPage.ReturnToApplicationList();
        
        // foreach (var kvp in _individualJobApplicationDetails)
        // {
        //     Console.WriteLine(kvp.Value);
        // }
    }
}