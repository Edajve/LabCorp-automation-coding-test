using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace LabCorp.utils
{
    public class Helpers
    {
        private WebDriverWait _wait;

        public Helpers(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ExplicitWaitForElement(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool DoesMapsMatch(Dictionary<string, string> firstMap, Dictionary<string, string> secondMap)
        {
            foreach (var kvp in firstMap)
            {
                bool hasMatch = false;

                foreach (var value in secondMap.Values)
                {
                    if (value.Contains(kvp.Value))
                    {
                        hasMatch = true;
                        break;
                    }
                }

                if (!hasMatch)
                {
                    return false;
                }
            }

            foreach (var kvp in secondMap)
            {
                bool hasMatch = false;

                foreach (var value in firstMap.Values)
                {
                    if (value.Contains(kvp.Value))
                    {
                        hasMatch = true;
                        break;
                    }
                }

                if (!hasMatch)
                {
                    return false;
                }
            }

            return false;
        }
    }
}