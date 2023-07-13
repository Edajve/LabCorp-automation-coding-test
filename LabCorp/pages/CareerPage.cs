using LabCorp.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorp.pages;

public class CareerPage
{
    private static Dictionary<string, string> _dictOfElementsToAssert = new();
    private static List<By> _elementsList = new();

    private static IWebDriver _driver;
    private WebDriverWait _wait;
    private Helpers _helpers;
    private Actions _actions;
    private string allSpecificsOfJob;

    //Second "By" type = ClassName
    private readonly By _careerPositionInput = By.ClassName("ph-a11y-search-box");

    //Third "By" type = CssSelector
    private readonly By _searchButton = By.Id("ph-search-backdrop");

    private static By _listItem = By.CssSelector(
        "body > div.ph-page > div.body-wrapper.ph-page-container > div > div > div > div.col-md-8.col-sm-7 > section:nth-child(3) > div > div > div > div.phs-jobs-list > div.content-block > ul > li:nth-child(1) > div.information > span > a > div > span");

    private static By jobSearchBtn =
        By.CssSelector(
            "body > div.ph-header > section.ph-widget.ph-widget-layout.ppc-section.ph-widget-target > div > div > header > div.top-nav.hidden-sm.hidden-xs > div > div.nav-right-list > ul > li.job-map > a");

    private static readonly By HeaderOfJob = By.CssSelector(
        "body > div.ph-page > div.body-wrapper.ph-page-container > div > div > div > div.col-md-8.col-sm-7 > section:nth-child(3) > div > div > div > div.phs-jobs-list > div.content-block > ul > li:nth-child(1) > div.information > span > a");

    private static By jobListItem = By.CssSelector("li.jobs-list-item[data-ph-at-id='jobs-list-item']");

    private static By jobTitle = By.CssSelector("span[data-ph-id='ph-page-element-page11-Zk12Zp']");
    private static By jobCategory = By.CssSelector("span.job-category");
    private static By jobAddress = By.CssSelector("span.job-location");
    private static By jobId = By.CssSelector("span[data-ph-id='ph-page-element-page11-P93Wlp']");
    //get the type full time or part time (for some reason this returns the job id)
    private static By jobDescription = By.CssSelector("p.job-description");

    private static readonly By JobCategory;
    private static readonly By JobLocation;
    private static readonly By JobNumberId;
    private static readonly By JobType;
    private static readonly By JobDescription;

    public CareerPage(IWebDriver driver)
    {
        _driver = driver;
        _helpers = new Helpers(driver);
        _actions = new Actions(_driver);
        // AddByElementsToList();
        // ExtractDetailsFromApplication();
    }

    public void SearchCareerPosition(string careerPosition)
    {
        _helpers.ExplicitWaitForElement(_careerPositionInput);
        _driver.FindElement(_careerPositionInput).SendKeys(careerPosition);

        _helpers.ExplicitWaitForElement(_searchButton);
        Thread.Sleep(1000);
        _driver.FindElement(_searchButton).Click();

        _helpers.ExplicitWaitForElement(jobSearchBtn);

        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
        IWebElement firstPosition = _driver.FindElement(_listItem);
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", firstPosition);
    }

    public void ClickFirstApplication()
    {
        _helpers.ExplicitWaitForElement(HeaderOfJob);
        _driver.FindElement(HeaderOfJob).Click();
    }

    private void AddByElementsToList()
    {
        _elementsList.Add(jobTitle);
        _elementsList.Add(jobCategory);
        _elementsList.Add(jobAddress);
        _elementsList.Add(jobDescription);
        _elementsList.Add(jobId);
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
            if (elementText == null || elementText == String.Empty)
            {
                _dictOfElementsToAssert[i.ToString()] = elementText;
            }
        }
    }

    public Dictionary<string, string> returnAllJobSpecifica()
    {
        return _dictOfElementsToAssert;
    }
}