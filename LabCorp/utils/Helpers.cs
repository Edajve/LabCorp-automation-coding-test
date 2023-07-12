using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorp.utils;

public class Helpers
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public Helpers(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void ExplicitWaitForElement(By locator)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}