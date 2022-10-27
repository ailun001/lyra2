using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace lyra2.Pages
{
    public class Home
    {
        static string url = "http://lyratesting2.co.nz/";
        static string logoutLink = "http://lyratesting2.co.nz/logout";

        [FindsBy(How = How.LinkText, Using = "登录")]
        private IWebElement Login;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[1]/a/img")]
        private IWebElement avatar;

        [FindsBy(How = How.LinkText, Using = "退出登录")]
        private IWebElement logout;

        [FindsBy(How = How.LinkText, Using = "注册")]
        private IWebElement register;

        public void selectLogin()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("登录")));
            Login.Click();
        }

        public void Goto() { Browser.Goto(url); }

        public void GotoLogout() { Browser.Goto(logoutLink); }

        public void MouseOnAvatar()
        {
            Actions actions = new Actions(Browser.WebDriver);
            actions.MoveToElement(avatar).Perform();
        }

        public void selectLogout()
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("退出登录")));
            logout.Click();
        }

        public void selectRegister()
        {
            register.Click();
        }
    }
}
