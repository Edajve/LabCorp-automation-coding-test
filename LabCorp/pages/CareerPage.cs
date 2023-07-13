using LabCorp.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorp.pages;

public class CareerPage
{
    private static IWebDriver _driver;
    private WebDriverWait _wait;
    private Helpers _helpers;
    private Actions _actions;
    private string allSpecificsOfJob;

    //Second "By" type = ClassName
    private readonly By _careerPositionInput = By.ClassName("ph-a11y-search-box");

    //Third "By" type = CssSelector
    private readonly By _searchButton = By.Id("ph-search-backdrop");

    private readonly By listContainer =
        By.CssSelector(
            "body > div.ph-page > div.body-wrapper.ph-page-container > div > div > div > div.col-md-8.col-sm-7 > section:nth-child(3) > div > div > div > div.phs-jobs-list > div.content-block > ul > li:nth-child(1)");

    private static By _listItem = By.CssSelector(
        "body > div.ph-page > div.body-wrapper.ph-page-container > div > div > div > div.col-md-8.col-sm-7 > section:nth-child(3) > div > div > div > div.phs-jobs-list > div.content-block > ul > li:nth-child(1) > div.information > span > a > div > span");

    private static By jobSearchBtn =
        By.CssSelector(
            "body > div.ph-header > section.ph-widget.ph-widget-layout.ppc-section.ph-widget-target > div > div > header > div.top-nav.hidden-sm.hidden-xs > div > div.nav-right-list > ul > li.job-map > a");

    private static readonly By HeaderOfJob = By.CssSelector(
        "body > div.ph-page > div.body-wrapper.ph-page-container > div > div > div > div.col-md-8.col-sm-7 > section:nth-child(3) > div > div > div > div.phs-jobs-list > div.content-block > ul > li:nth-child(1) > div.information > span > a");


    //this is the list container
    private static By jobListItem = By.CssSelector("li.jobs-list-item[data-ph-at-id='jobs-list-item']");

    //get the job title
    //get the category of job
    //get the address
    //get the job id
    //get the type full time or part time
    //get the job description

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

        _helpers.ExplicitWaitForElement(jobListItem);
        //right here is where you where passing the elements to get the name of the element
        //pass it in the .FindElement()
        IWebElement spanElement = _driver.FindElement(jobListItem);
        string spanText = spanElement.Text;


        _driver.FindElement(HeaderOfJob).Click();
    }

    public string returnAllJobSpecifica()
    {
        return allSpecificsOfJob;
    }
}