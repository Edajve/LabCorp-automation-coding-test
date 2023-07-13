using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LabCorp.Drivers;
using TechTalk.SpecFlow;

namespace LabCorp.utils
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string[] frontendTags = { "frontend" };
            string[] apiTags = { "api" };

            bool isFrontEnd = _scenarioContext.ScenarioInfo.Tags.Intersect(frontendTags).Any();
            bool isApi = _scenarioContext.ScenarioInfo.Tags.Intersect(apiTags).Any();

            if (isFrontEnd)
            {
                SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
                _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
            }
            else if (isApi)
            {
                // Add any setup specific to API tests here
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            string[] frontendTags = { "frontend" };
            string[] apiTags = { "api" };

            bool isFrontEnd = _scenarioContext.ScenarioInfo.Tags.Intersect(frontendTags).Any();
            bool isApi = _scenarioContext.ScenarioInfo.Tags.Intersect(apiTags).Any();

            if (isFrontEnd)
            {
                _scenarioContext.Get<IWebDriver>("SeleniumDriver").Quit();
            }
            else if (isApi)
            {
                // Add any cleanup specific to each API scenario here
            }
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            // Add any setup specific to frontend tests here
        }

        [BeforeFeature("api")]
        public static void BeforeApiFeature()
        {
            // Add any setup specific to API tests here
        }
    }
}
