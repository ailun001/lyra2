using lyra2.Modles;
using lyra2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace lyra2
{
    [Binding]
    public class EditUserInfoStepDefinitions
    {
        [Given(@"I already logged in")]
        public void GivenIAlreadyLoggedIn()
        {
            Page.Home.selectLogin();
            Page.Login.userInput("test001", "Test1234");
            Page.Login.login();
            Assert.IsFalse(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/login"));
        }

        [Given(@"I can see account seting link")]
        public void GivenICanSeeAccountSetingLink()
        {
            IWebElement setting = Browser.WebDriver.FindElement(By.LinkText("个人设置"));
            Assert.IsTrue(setting.Displayed);
        }

        [Given(@"I select account setting")]
        public void GivenISelectAccountSetting()
        {
            Browser.WebDriver.FindElement(By.LinkText("个人设置")).Click();
        }

        [Then(@"I am on the account setting page")]
        public void ThenIAmOnTheAccountSettingPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/settings/"));
        }

        [Given(@"I am on the account setting page")]
        public void GivenIAmOnTheAccountSettingPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/settings/"));
        }

        [Given(@"I can see avatar setting link")]
        public void GivenICanSeeAvatarSettingLink()
        {
            IWebElement setAvatar = Browser.WebDriver.FindElement(By.LinkText("头像设置"));
            Assert.IsTrue(setAvatar.Displayed);
        }

        [Given(@"I select avatat setting")]
        public void GivenISelectAvatatSetting()
        {
            Browser.WebDriver.FindElement(By.LinkText("头像设置")).Click();
        }

        [Then(@"I am on avatar setting page")]
        public void ThenIAmOnAvatarSettingPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("https://lyratesting2.co.nz/settings/avatar"));
        }

        [Given(@"I am on avatar setting page")]
        public void GivenIAmOnAvatarSettingPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("https://lyratesting2.co.nz/settings/avatar"));
        }

        [When(@"I upload a avatar")]
        public void WhenIUploadAAvatar()
        {
            IWebElement upload = Browser.WebDriver.FindElement(By.Name("file"));
            upload.SendKeys("E:/work/web_c#/1.png");

        }

        [When(@"I click save")]
        public void WhenIClickSave()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("upload-avatar-btn")));
            Browser.WebDriver.FindElement(By.Id("upload-avatar-btn")).Click();
        }

        [Then(@"button change to upload new avatar")]
        public void ThenButtonChangeToUploadNewAvatar()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("上传新头像")));
            Assert.IsTrue(Browser.WebDriver.FindElement(By.LinkText("上传新头像")).Displayed);
        }

        [When(@"I upload the info")]
        public void WhenIUploadTheInfo()
        {
            Page.Settings.save();
        }

        [Then(@"I can see success message")]
        public void ThenICanSeeSuccessMessage()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"user-profile-form\"]/div[1]")));
            Assert.IsTrue(Browser.WebDriver.FindElement(By.XPath("//*[@id=\"user-profile-form\"]/div[1]")).Displayed);
        }

        [When(@"I enter invalid info")]
        public void WhenIEnterInvalidInfo(Table table)
        {
            var info = table.CreateInstance<SettingInfo>();
            Page.Settings.userInput(info.Name, info.ID, info.Phone, info.Title, info.Profile, info.Weibo, info.QQ);
        }

        [Then(@"I can see error message in setting page")]
        public void ThenICanSeeErrorMessageInSettingPage(Table table)
        {
            var meaasges = table.CreateSet<SettingInfo>().Select(p => p.error);
            foreach(var meaasge in meaasges)
            {
                Assert.IsTrue(Browser.WebDriver.PageSource.Contains(meaasge));
            }
        }
    }
}
