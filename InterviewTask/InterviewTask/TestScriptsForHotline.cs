using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace InterviewTask
{
    /// <summary>
    /// Class with test scripts for website hotline.ua
    /// </summary>
    /// <typeparam name="TWebDriver">Driver which will be used in tests.</typeparam>
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class TestScriptsForHotline<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        IWebDriver driver;
        ItemPage itemPage;
        HotlinePage anyPage;
        TimeSpan timeout;

        [SetUp]
        public void TestsSetUp()
        {
            this.driver = new TWebDriver();
            timeout = new TimeSpan(0, 0, 10);
        }

        /// <summary>
        /// Tests searching for any goods.
        /// </summary>
        [Test]
        public void TestSearch()
        {
            string searchQuery = "macbook";
            driver.Navigate().GoToUrl("http://hotline.ua/");
            try
            {
                anyPage = new HotlinePage(driver);
                PageFactory.InitElements(driver, anyPage);
                anyPage.searchFor(searchQuery);
            }
            finally
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Tests opening reviews tab on item page.
        /// </summary>
        [Test]
        public void TestViewAllReviewsForItem()
        {
            driver.Navigate().GoToUrl("http://hotline.ua/computer-noutbuki-netbuki/apple-macbook-air-13-mmgf2-2016/");
            try
            {
                itemPage = new ItemPage(driver);
                PageFactory.InitElements(driver, itemPage);
                itemPage.viewReviews();
            }
            finally
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Tests searching the shop with the lowest price and going to it's website.
        /// </summary>
        [Test]
        public void TestCheapestPriceForItem()
        {
            driver.Navigate().GoToUrl("http://hotline.ua/computer-noutbuki-netbuki/apple-macbook-air-13-mmgf2-2016/");
            try
            {
                itemPage = new ItemPage(driver);
                PageFactory.InitElements(driver, itemPage);
                itemPage.hideFooter();
                itemPage.viewPrices();
                DriverExtension.WaitAndClickable(driver, By.XPath(ItemPage.SORT_BY_PRICE_BUTTON_LOCATOR),timeout);
                itemPage.sortByPrices();
                itemPage.goToTheCheapestShop();
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
