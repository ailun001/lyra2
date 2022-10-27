using lyra2.Modles;
using lyra2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace lyra2
{
    [Binding]
    public class UserLoginStepDefinitions
    {
        [Given(@"that I am in the home page")]
        public void GivenThatIAmInTheHomePage()
        {
            Page.Home.Goto();
            Page.Home.GotoLogout();
            Page.Home.Goto();

        }

        [Given(@"I can select Login")]
        public void GivenICanSelectLogin()
        {
            Page.Home.selectLogin();
        }

        [Given(@"select Login")]
        public void GivenSelectLogin()
        {
            Page.Login.login();
        }

        [Given(@"that I enter valid username and password")]
        public void GivenThatIEnterValidUsernameAndPassword(Table table)
        {
            var user = table.CreateInstance<User>();
            Page.Login.userInput(user.Name, user.Password);
        }


        [Then(@"the page jumped")]
        public void ThenThePageJumped()
        {
            Assert.IsFalse(Browser.WebDriver.Url.Equals("http://lyratesting2.co.nz/login"));
        }

        [Then(@"I can see my avatar")]
        public void ThenICanSeeMyAvatar()
        {
            IWebElement a = Browser.WebDriver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/a/img"));
            Assert.True(a.Displayed);
            Page.Home.GotoLogout();
        }

        [Given(@"select remember me")]
        public void GivenSelectRememberMe()
        {
            Page.Login.rememberSelect();
        }

        [Then(@"error meaasge shows up")]
        public void ThenErrorMeaasgeShowsUp()
        {
            Page.Login.errorShows();
        }

        [Given(@"that I enter invalid username and password")]
        public void GivenThatIEnterInvalidUsernameAndPassword(Table table)
        {
            var user = table.CreateInstance<User>();
            Page.Login.userInput(user.Name, user.Password);
        }

    }
}
