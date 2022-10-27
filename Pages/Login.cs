using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyra2.Pages
{
    public class Login
    {
        [FindsBy(How = How.Id, Using = "login_username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement password;

        [FindsBy(How = How.Name, Using = "_remember_me")]
        private IWebElement remember;

        [FindsBy(How = How.LinkText, Using = "用户名或密码错误")]
        private IWebElement error;

        [FindsBy(How = How.ClassName, Using = "js-btn-login")]
        private IWebElement loginBt;

        [FindsBy(How = How.LinkText, Using = "找回密码")]
        private IWebElement reset;

        public void userInput(string name, string pass)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_password")));

            username.Clear();
            password.Clear();
            username.Click();
            username.SendKeys(name);
            password.Click();
            password.SendKeys(pass);
        }

        public void rememberSelect()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("_remember_me")));

            if (!remember.Selected) { remember.Click(); }
        }

        public void login()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("js-btn-login")));
            loginBt.Click();
        }

        public void GoToReset()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("找回密码")));
            reset.Click();
        }

        public bool errorShows()
        {
            return remember.Displayed;
        }
    }
}
