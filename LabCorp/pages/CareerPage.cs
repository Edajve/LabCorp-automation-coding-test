using LabCorp.utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;



namespace LabCorp.pages;

public class CareerPage
{
    
    private IWebDriver _driver;
    private WebDriverWait wait;
    private Helpers _helpers;
    
    //Second "By" type = ClassName
    private By careerPositionInput = By.ClassName("ph-a11y-search-box");
    
    //used this to sendKeys
    //[FindsBy(How = How.ClassName, Using = "ph-a11y-search-box")]
    private IWebElement positionInput;

    public CareerPage(IWebDriver driver)
    {
        _driver = driver;
        //PageFactory.InitElements(driver, this);
    }

    public void SearchCareerPosition(string careerPosition)
    {
        _helpers.ExplicitWaitForElement(careerPositionInput);
        positionInput.SendKeys(careerPosition);
        
    }
}