using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
    /// <summary>
    /// Represents any page on a website hotline.ua.
    /// </summary>
    public class HotlinePage
    {
        /// <summary>
        /// Driver which is used in test.
        /// </summary>
        protected readonly IWebDriver driver;

        /// <summary>
        /// A textbox for a search query.
        /// </summary>
        [FindsBy(How = How.XPath, Using = SEARCH_BOX_LOCATOR)]
        public IWebElement searchBox { get; set; }

        /// <summary>
        /// Button for performing a search.
        /// </summary>
        [FindsBy(How = How.XPath, Using = SEARCH_BUTTON_LOCATOR)]
        public IWebElement searchButton { get; set; }

        /// <summary>
        /// Button for hiding a footer.
        /// </summary>
        [FindsBy(How = How.XPath, Using = HIDE_FOOTER_BUTTON_LOCATOR)]
        public IWebElement hideFooterButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the HotlinePage class.
        /// </summary>
        /// <param name="driver">Driver which is going to be used in tests.</param>
        public HotlinePage(IWebDriver driver)
           {
               this.driver = driver;
           }

        /// <summary>
        /// Enters text into the search box.
        /// </summary>
        /// <param name="text">Text to be typed in search box.</param>
        /// <returns>Page with text in search box.</returns>
        public HotlinePage typeInSearchBox(String text)
        {
            searchBox.Click();
            searchBox.SendKeys(text);
            return this;
        }

        /// <summary>
        /// Performs search of a good on the website.
        /// </summary>
        /// <param name="text">A product to be searched for.</param>
        /// <returns>A page with search results.</returns>
        public HotlinePage searchFor(String text)
        {
            typeInSearchBox(text);
            searchButton.Click();
            return new HotlinePage(driver);
        }

        /// <summary>
        /// Hides the footer on the page.
        /// </summary>
        /// <returns>Page with hidden footer.</returns>
        public HotlinePage hideFooter()
        {
            hideFooterButton.Click();
            return this;
        }

        /// <summary>
        /// XPath locator for a textbox for a search query.
        /// </summary>
        public const string SEARCH_BOX_LOCATOR = "//input[@value='Что вы хотите купить?']";
        /// <summary>
        /// XPath locator for a button for performing a search.
        /// </summary>
        public const string SEARCH_BUTTON_LOCATOR = "//input[@type='submit' and contains(@id,'Search')]";
        /// <summary>
        /// XPath locator for a button for hiding a footer.
        /// </summary>
        public const string HIDE_FOOTER_BUTTON_LOCATOR = "//a[@data-statistic-key='stat113']";


    }
}
