using BoDi;
using LabCorp.Drivers;
using OpenQA.Selenium;

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
                // API set up
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
                // API cleann up
            }
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
        }

        [BeforeFeature("api")]
        public static void BeforeApiFeature()
        {
        }
    }
}