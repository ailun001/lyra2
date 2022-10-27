using lyra2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace lyra2
{
    [Binding]
    public class UserLogoutStepDefinitions
    {
        [Given(@"that I am in the login page")]
        public void GivenThatIAmInTheLoginPage()
        {
            Page.Home.Goto();
            Page.Home.GotoLogout();
            Page.Home.Goto();
            Page.Home.selectLogin();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("http://lyratesting2.co.nz/login"));
        }

        [Given(@"I can see my avatra")]
        public void GivenICanSeeMyAvatra()
        {
            IWebElement avatar = Browser.WebDriver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/a/img"));
            Assert.True(avatar.Displayed);
        }

        [Given(@"I move mouse hover on my avatar")]
        public void GivenIMoveMouseHoverOnMyAvatar()
        {
            Page.Home.MouseOnAvatar();
        }

        [When(@"I can see logout link")]
        public void WhenICanSeeLogoutLink()
        {
            IWebElement logout = Browser.WebDriver.FindElement(By.LinkText("ÍË³öµÇÂ¼"));
            Assert.True(logout.Displayed);
        }

        [When(@"I click the logout link")]
        public void WhenIClickTheLogoutLink()
        {
            Page.Home.selectLogout();
        }

        [Then(@"I an on the login page")]
        public void ThenIAnOnTheLoginPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/login"));
        }

    }
}
