using FluentAssertions;
using LabCorp.Drivers;
using LabCorp.pages;
using LabCorp.utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LabCorp.Steps
{
    [Binding]
    public sealed class TaskOneSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private Dictionary<string, string> _individualJobApplicationDetails;
        private Dictionary<string, string> _individualFromCareerPage;
        private Helpers _helpers;

        public TaskOneSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _individualJobApplicationDetails = new Dictionary<string, string>();
            _individualFromCareerPage = new Dictionary<string, string>();
            _driver = driver;
        }

        [Given(@"user is on Lab Corp website")]
        public void GivenUserIsOnLabCorpWebsite()
        {
            _driver.Url = "https://www.labcorp.com/";
            _driver.Url.Should().Be("https://www.labcorp.com/");
            _helpers = new Helpers(_driver);
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
            _individualFromCareerPage = careerPage.returnAllJobSpecifica();
        }

        [Then(@"user returns back to list of applications")]
        public void ThenUserReturnsBackToListOfApplications()
        {
            JobApplicationPage jobApplicationPage = new JobApplicationPage(_driver);
            _individualJobApplicationDetails = jobApplicationPage.GetAssertionMapForIndividualApplication();
            jobApplicationPage.ReturnToApplicationList();

            Assert.True(Helpers.DoesMapsMatch(_individualJobApplicationDetails, _individualFromCareerPage));
        }
    }
}