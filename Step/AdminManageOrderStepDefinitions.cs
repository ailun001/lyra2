using lyra2.Modles;
using lyra2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace lyra2
{
    [Binding]
    public class AdminManageOrderStepDefinitions
    {
        [Given(@"I login with admin")]
        public void GivenILoginWithAdmin()
        {
            Page.Home.selectLogin();
            Page.Login.userInput("admin", "5EstafeyEtre");
            Page.Login.login();
            Assert.IsFalse(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/login"));
        }

        [Given(@"I can see management background link")]
        public void GivenICanSeeManagementBackgroundLink()
        {
            IWebElement manage = Browser.WebDriver.FindElement(By.LinkText("管理后台"));
            Assert.IsTrue(manage.Displayed);
        }

        [Given(@"I select manage background")]
        public void GivenISelectManageBackground()
        {
            Browser.WebDriver.FindElement(By.LinkText("管理后台")).Click();
        }

        [Then(@"I am on the manage page")]
        public void ThenIAmOnTheManagePage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/admin/"));
        }

        [Given(@"I am on the manage page")]
        public void GivenIAmOnTheManagePage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/admin/"));
        }

        [Given(@"I goto order manage page")]
        public void GivenIGotoOrderManagePage()
        {
            Browser.WebDriver.FindElement(By.LinkText("订单")).Click();
        }

        [When(@"I can see course order link")]
        public void WhenICanSeeCourseOrderLink()
        {
            IWebElement courseOrder = Browser.WebDriver.FindElement(By.LinkText("课程订单"));
            Assert.IsTrue(courseOrder.Displayed);
        }

        [When(@"I select course order")]
        public void WhenISelectCourseOrder()
        {
            Browser.WebDriver.FindElement(By.LinkText("课程订单")).Click();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"user-search-form\"]/div[2]/button")));
            Browser.WebDriver.FindElement(By.XPath("//*[@id=\"user-search-form\"]/div[2]/button")).Click();
        }

        [Then(@"I can see some orders")]
        public void ThenICanSeeSomeOrders()
        {
            IWebElement table = Browser.WebDriver.FindElement(By.TagName("tbody"));
            Assert.IsTrue(table.Displayed);
        }

        [When(@"I can see class order link")]
        public void WhenICanSeeClassOrderLink()
        {
            IWebElement classOrder = Browser.WebDriver.FindElement(By.LinkText("班级订单"));
            Assert.IsTrue(classOrder.Displayed);
        }

        [When(@"I select class order")]
        public void WhenISelectClassOrder()
        {
            Browser.WebDriver.FindElement(By.LinkText("班级订单")).Click();
        }

        [When(@"I enter (.*) with (.*)")]
        public void WhenIEnterDateWith_(string filters, string detali)
        {
            IWebElement selecter = Browser.WebDriver.FindElement(By.Name(filters));
            selecter.SendKeys(detali);
        }
    }
}
