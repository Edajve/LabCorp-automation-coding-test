using LabCorp.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LabCorp.pages;

public class HomePage
{
    private IWebDriver _driver;
    private WebDriverWait wait;
    private Helpers _helpers;

    //First "By" type = XPath
    private By careerBtnLocator = By.XPath("//*[@id='login-container']/div[1]/ul/li[3]/a");

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _helpers = new Helpers(driver);
    }

    public void NavigateToCareerPage()
    {
        _helpers.ExplicitWaitForElement(careerBtnLocator);
        _driver.FindElement(careerBtnLocator).Click();
    }
}