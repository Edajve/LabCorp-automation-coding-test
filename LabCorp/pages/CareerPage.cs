using LabCorp.utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace LabCorp.pages;

public class CareerPage
{
    
    private static IWebDriver _driver;
    private WebDriverWait wait;
    private Helpers _helpers;
    private Actions _actions;
    
    //Second "By" type = ClassName
    private By careerPositionInput = By.ClassName("ph-a11y-search-box");
    
    //Third "By" type = CssSelector
    By firstOpenPosition = By.CssSelector("li[aria-posinset=\"1\"]");
    By searchButton = By.CssSelector("button.btn.primary-button.btn-lg.phs-search-submit.au-target[data-ph-at-id='globalsearch-button']");
    private static By listItem = By.CssSelector("li.jobs-list-item[data-ph-at-id='jobs-list-item']");

    private IWebElement positionInput;

    public CareerPage(IWebDriver driver)
    {
        _driver = driver;
        _helpers = new Helpers(driver);
        _actions = new Actions(_driver);
    }

    public void SearchCareerPosition(string careerPosition)
    {
        _helpers.ExplicitWaitForElement(careerPositionInput);
        _driver.FindElement(careerPositionInput).SendKeys(careerPosition);
        
         _helpers.ExplicitWaitForElement(firstOpenPosition);
        _driver.FindElement(searchButton).Click();
        
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
        IWebElement firstPosition = _driver.FindElement(listItem);
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", firstPosition);
        
        _helpers.ExplicitWaitForElement(listItem);
        _driver.FindElement(listItem).Click();
    }
}