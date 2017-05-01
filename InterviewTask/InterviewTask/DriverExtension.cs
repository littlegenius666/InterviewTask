using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
    /// <summary>
    /// Class with methods that expand driver capabilities.
    /// </summary>
    public static class DriverExtension
    {
        /// <summary>
        /// Waits for a specific element to be clickable.
        /// </summary>
        /// <param name="driver">Driver which is used in test.</param>
        /// <param name="by">Locator for the coming element.</param>
        /// <param name="timeout">Time to TimeoutException.</param>
        public static void WaitAndClickable(IWebDriver driver, By by, TimeSpan timeout)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, timeout);
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }


    }
}
