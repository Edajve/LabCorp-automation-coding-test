using LabCorp.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LabCorp.pages
{
    public class JobApplicationPage
    {
        private static Dictionary<string, string> _dictOfElementsToAssert = new();
        private static List<By> _elementsList = new();

        private IWebDriver _driver;
        private WebDriverWait wait;
        private Helpers _helpers;

        private static readonly By TitleOfJob = By.CssSelector(".job-title");
        private static readonly By IdOfJob = By.CssSelector(".au-target.jobId");
        private static readonly By JobType = By.CssSelector(".au-target.type");
        private static readonly By JobDepartment = By.CssSelector(".au-target.job-category");

        private static readonly By JobDescription =
            By.CssSelector("div.jd-info.au-target[data-ph-at-id='jobdescription-text']");

        private static readonly By LocationOfJob = By.CssSelector("span.au-target.job-location");
        
        static string cssSelector = "a.phs-back-search-results";
        By returnToApplicationsBtn = By.CssSelector(cssSelector);

        public JobApplicationPage(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(driver);
            AddByElementsToList();
            ExtractDetailsFromApplication();
        }

        public void ReturnToApplicationList()
        {
            _helpers.ExplicitWaitForElement(returnToApplicationsBtn);
            _driver.FindElement(returnToApplicationsBtn).Click();
        }

        private void AddByElementsToList()
        {
            _elementsList.Add(TitleOfJob);
            _elementsList.Add(LocationOfJob);
            _elementsList.Add(IdOfJob);
            _elementsList.Add(JobType);
            _elementsList.Add(JobDepartment);
            _elementsList.Add(JobDescription);
        }

        private string GetElementText(By byElement)
        {
            IWebElement element = _driver.FindElement(byElement);
            return element.Text;
        }

        private void ExtractDetailsFromApplication()
        {
            for (int i = 0; i < _elementsList.Count; i++)
            {
                _helpers.ExplicitWaitForElement(_elementsList[i]);
                By byElement = _elementsList[i];
                string elementText = GetElementText(byElement);
                _dictOfElementsToAssert[i.ToString()] = elementText;
            }
        }

        public Dictionary<string, string> GetAssertionMapForIndividualApplication()
        {
            return _dictOfElementsToAssert;
        }
    }
}