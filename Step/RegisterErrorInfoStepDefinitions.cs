using lyra2.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace lyra2
{
    [Binding]
    public class RegisterErrorInfoStepDefinitions
    {
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            Page.Home.Goto();
            Page.Home.GotoLogout();
            Page.Home.selectRegister();
            Assert.IsTrue(Browser.WebDriver.Url.Contains("http://lyratesting2.co.nz/register"));
        }

        [When(@"I enter email with (.*), username with (.*), password with (.*), verification with (.*)")]
        public void WhenIEnterEmailWithUsernameWithPasswordWithVerificationWith(string email, string name, string pass, string ver)
        {
            Page.Register.userInput(email, name, pass, ver);
        }


        [When(@"I click register")]
        public void WhenIClickRegister()
        {
            Page.Register.register();
        }

        [Then(@"I can see (.*) error message (.*)")]
        public void ThenICanSeeErrorMessage(string error, string message)
        {
            Assert.True(Page.Register.errorShows(error,message));
        }

        [Then(@"verification error message")]
        public void ThenVerificationErrorMessage()
        {
            Assert.True(Page.Register.errorShows("code","ÑéÖ¤Âë´íÎó"));
        }

    }
}
