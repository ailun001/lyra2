using lyra2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace lyra2
{
    [Binding]
    public class ForgotPasswordInputStepDefinitions
    {
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            Page.Home.Goto();
            Page.Home.GotoLogout();
            Page.Home.selectLogin();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("http://lyratesting2.co.nz/login"));
        }

        [Given(@"I select forgot password link")]
        public void GivenISelectForgotPasswordLink()
        {
            Page.Login.GoToReset();
        }

        [Then(@"I am on the reset password page")]
        public void ThenIAmOnTheResetPasswordPage()
        {

            Assert.IsTrue(Browser.WebDriver.Url.Contains("http://lyratesting2.co.nz/password/reset"));
        }

        [Given(@"I am on the reset password page")]
        public void GivenIAmOnTheResetPasswordPage()
        {
            Assert.IsTrue(Browser.WebDriver.Url.Contains("http://lyratesting2.co.nz/password/reset"));
        }

        [When(@"I can see email input box")]
        public void WhenICanSeeEmailInputBox()
        {
            IWebElement form_email = Browser.WebDriver.FindElement(By.Id("form_email"));
            Assert.IsTrue(form_email.Displayed);
        }

        [When(@"I enter (.*) in resetpage" )]
        public void WhenIEnter(string email)
        {
            Page.Reset.userInput(email);
        }

        [When(@"I click reset password")]
        public void WhenIClickResetPassword()
        {
            Page.Reset.reset();
        }

        [Then(@"I can see (.*) message (.*) in reset page")]
        public void ThenICanSeeTheEmailNotExistErrorMessageInResetPage(string error,string message)
        {
            Page.Reset.errorShows(error,message);
        }

    }
}
