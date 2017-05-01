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
    /// Represents a page with a specific item on the website hotline.ua.
    /// </summary>
    public class ItemPage : HotlinePage
    {
        /// <summary>
        /// Link to show reviews tab on item page.
        /// </summary>
        [FindsBy(How = How.XPath, Using = REVIEWS_LINK_LOCATOR)]
        public IWebElement reviewsLink { get; set; }

        /// <summary>
        /// Link to show prices tab on item page.
        /// </summary>
        [FindsBy(How = How.XPath, Using = PRICES_LINK_LOCATOR)]
        public IWebElement pricesLink { get; set; }

        /// <summary>
        /// Button for sorting offers by price.
        /// </summary>
        [FindsBy(How = How.XPath, Using = SORT_BY_PRICE_BUTTON_LOCATOR)]
        public IWebElement sortByPriceButton { get; set; }

        /// <summary>
        /// List of links to the shops.
        /// </summary>
        [FindsBy(How = How.XPath, Using = SHOP_LINKS_LOCATOR)]
        public IList<IWebElement> shopLinks { get; set; }

        /// <summary>
        /// Initializes a new instance of the ItemPage class.
        /// </summary>
        /// <param name="driver">Driver which is going to be used in tests.</param>
        public ItemPage(IWebDriver driver)
            : base(driver)
        {
            if (!driver.Title.Contains("купить в интернет-магазине"))
            {
                throw new Exception("This is not item item page");
            }
        }

        /// <summary>
        /// Shows reviews tab on item page.
        /// </summary>
        /// <returns>Page with shown revies tab.</returns>
        public ItemPage viewReviews()
        {
            reviewsLink.Click();
            return this;
        }

        /// <summary>
        /// Shows offers tab on item page.
        /// </summary>
        /// <returns>Page with shown offers tab.</returns>
        public ItemPage viewPrices()
        {
            pricesLink.Click();
            return this;
        }

        /// <summary>
        /// Sorts all offers by price.
        /// </summary>
        /// <returns>Page with sorted offers.</returns>
        public ItemPage sortByPrices()
        {
            sortByPriceButton.Click();
            return this;
        }

        /// <summary>
        /// Goes to the store's website with the lowest price.
        /// </summary>
        public void goToTheCheapestShop()
        {
            shopLinks[0].Click();
        }

        /// <summary>
        /// XPath locator for link to show reviews tab on item page.
        /// </summary>
        public const string REVIEWS_LINK_LOCATOR = "//a[@data-id='discussion']";
        /// <summary>
        /// XPath locator for link to show prices tab on item page.
        /// </summary>
        public const string PRICES_LINK_LOCATOR = "//a[@data-id='prices']";
        /// <summary>
        /// XPath locator for sorting offers by price button.
        /// </summary>
        public const string SORT_BY_PRICE_BUTTON_LOCATOR = "//*[@class='sort-by-price']";
        /// <summary>
        /// XPath locator for a list of links to the shops.
        /// </summary>
        public const string SHOP_LINKS_LOCATOR = "//a[@id='gotoshop-price-button']";

    }
}
