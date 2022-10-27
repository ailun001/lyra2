using lyra2.Pages;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using System.Timers;

namespace lyra2
{
    [Binding]
    public class AdminManageOperationStepDefinitions
    {
        [Given(@"I goto operation page")]
        public void GivenIGotoOperationPage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[3]/a")));
            Browser.WebDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[3]/a")).Click();
        }

        [Then(@"I am on the operation page")]
        public void ThenIAmOnTheOperationPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/admin/article"));
        }

        [Given(@"I am on the operation page")]
        public void GivenIAmOnTheOperationPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/admin/article"));
        }

        [When(@"I can see Information management link")]
        public void WhenICanSeeInformationManagementLink()
        {
            IWebElement manageInfo = Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[1]/a"));
            Assert.IsTrue(manageInfo.Displayed);
        }

        [When(@"I select Information management")]
        public void WhenISelectInformationManagement()
        {
            Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[1]/a")).Click();
        }

        [When(@"I click search button in Information management page")]
        public void WhenIClickSearchButtonInInformationManagementPage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/form/button")));
            Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/form/button")).Click();
        }

        [Then(@"(.*) order match result")]
        public void ThenOrderMatchResult(string id)
        {
            IWebElement result = Browser.WebDriver.FindElement(By.Id("article-"+id));
            Assert.IsTrue(result.Displayed);
        }

        [When(@"I click cayegory")]
        public void WhenIClickCayegory()
        {
            Browser.WebDriver.FindElement(By.CssSelector(".select2-chosen")).Click();
        }

        [When(@"I enter keyword (.*)")]
        public void WhenIEnterKeywordEduSoho(string word)
        {
            IWebElement input = Browser.WebDriver.FindElement(By.CssSelector(".select2-input"));
            input.SendKeys(word);
        }

        [When(@"I select match result (.*)")]
        public void WhenISelectMatchResult(string result)
        {
            Browser.WebDriver.FindElement(By.Id("select2-result-"+result)).Click();
        }

        [When(@"I change (.*) article status to (.*)")]
        public void WhenIChangeArticleStatusTo(string id, string status)
        {
            string currentStatus = Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[6]")).Text;
            if (currentStatus == "未发布")
            {
                if (status == "发布")
                {
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/a[2]")).Click();
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/ul/li[1]/a")).Click();
                }
                else if (status.Contains("回收"))
                {
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/a[2]")).Click();
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/ul/li[2]/a")).Click();
                }
            }
            else if (currentStatus == "已发布")
            {
                if (status.Contains("取消"))
                {
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/a[2]")).Click();
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/ul/li[1]/a")).Click();
                }
                else if (status.Contains("回收"))
                {
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/a[2]")).Click();
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/ul/li[2]/a")).Click();
                }
            }
            else
            {
                if (status == "发布")
                {
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/a[2]")).Click();
                    Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[7]/div/ul/li[1]/a")).Click();
                }
            }
        }

        [Then(@"I can see (.*) article status change to (.*)")]
        public void ThenICanSeeArticleStatusChangeTo(string id, string status)
        {
            Thread.Sleep(3000);
            string currentStatus = Browser.WebDriver.FindElement(By.XPath("//*[@id=\"article-" + id + "\"]/td[6]")).Text;
            Assert.IsTrue(currentStatus.Equals(status));
        }

        [When(@"I can see category management link")]
        public void WhenICanSeeCategoryManagementLink()
        {
            IWebElement managecate = Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[2]/a"));
            Assert.IsTrue(managecate.Displayed);
        }

        [When(@"I select category management")]
        public void WhenISelectCategoryManagement()
        {
            Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[2]/a")).Click();
        }

        [When(@"I select add category")]
        public void WhenISelectAddCategory()
        {
            Browser.WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/a")).Click();
        }

        [When(@"I enter name (.*), code (.*), pre (.*), title (.*), keyword (.*), desc (.*), publish (.*)")]
        public void WhenIEnterNameCodePreTitleKeywordDescPublish(string name, string code, string pre, string title, string key, string desc, int pub)
        {
            string time = DateTime.Now.ToString("yyyyMMddhhmmss");
            Page.adminAtricleCategory.userInput(name+time, code + time, pre, title + time, key + time, desc + time, pub);
        }

        [When(@"I save category")]
        public void WhenISaveCategory()
        {
            Browser.WebDriver.FindElement(By.Id("category-save-btn")).Click();
        }

        [Then(@"I can see new category added (.*)")]
        public void ThenICanSeeNewCategoryAdded(string name)
        {
            string time = DateTime.Now.ToString("yyyyMMddhhmm");
            Browser.WebDriver.PageSource.Contains(name+time);
        }

        [When(@"I select edit (.*)")]
        public void WhenISelectEdit(int id)
        {
            Browser.WebDriver.FindElement(By.XPath("//*[@id=\"" + id + "\"]/div/div[4]/a[1]")).Click();
        }

        [When(@"I change name (.*), code (.*), pre (.*), title (.*), keyword (.*), desc (.*), publish (.*)")]
        public void WhenIChangeNameCodePreTitleKeywordDescPublish(string name, string code, string pre, string title, string key, string desc, int pub)
        {
            string time = DateTime.Now.ToString("yyyyMMddhhmmss");
            Page.adminAtricleCategory.userEdit(name + time, code + time, pre, title + time, key + time, desc + time, pub);
        }
        [Then(@"I can see category changed (.*) (.*)")]
        public void ThenICanSeeCategoryChangedTest_(int id, string name)
        {
            Thread.Sleep(3000);
            string time = DateTime.Now.ToString("yyyyMMddhh");
            string categoryName = Browser.WebDriver.FindElement(By.XPath("//*[@id=\""+id+"\"]/div/div[1]")).Text;
            Assert.IsTrue(categoryName.Contains(name+time));
        }

    }
}
