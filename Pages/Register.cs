using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyra2.Pages
{
    public class Register
    {
        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement register_email;

        [FindsBy(How = How.Id, Using = "register_nickname")]
        private IWebElement register_nickname;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement register_password;

        [FindsBy(How = How.Id, Using = "captcha_code")]
        private IWebElement captcha_code;

        [FindsBy(How = How.Id, Using = "register-btn")]
        private IWebElement register_btn;

        [FindsBy(How = How.Id, Using = "register_email-error")]
        private IWebElement register_email_error;

        [FindsBy(How = How.Id, Using = "register_nickname-error")]
        private IWebElement register_nickname_error;

        [FindsBy(How = How.Id, Using = "register_password-error")]
        private IWebElement register_password_error;

        [FindsBy(How = How.Id, Using = "captcha_code-error")]
        private IWebElement captcha_code_error;

        public void userInput(string email, string name, string pass, string code)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_email")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_nickname")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_password")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("captcha_code")));

            register_email.Clear();
            register_nickname.Clear();
            register_password.Clear();
            captcha_code.Clear();
            register_email.Click();
            register_email.SendKeys(email);
            register_nickname.Click();
            register_nickname.SendKeys(name);
            register_password.Click();
            register_password.SendKeys(pass);
            captcha_code.Click();
            captcha_code.SendKeys(code);
        }

        public void register()
        {
            register_btn.Click();
        }

        public bool errorShows(string error, string message)
        {
            switch (error)
            {
                case "email":
                    return register_email_error.Displayed && register_email_error.Text.Contains(message);
                case "name":
                    return register_nickname_error.Displayed && register_nickname_error.Text.Contains(message);
                case "pass":
                    return register_password_error.Displayed && register_password_error.Text.Contains(message);
                case "code":
                    return captcha_code_error.Displayed && captcha_code_error.Text.Contains(message);
                case "all":
                    return (register_email_error.Displayed
                        && register_nickname_error.Displayed
                        && register_password_error.Displayed
                        && captcha_code_error.Displayed);
                    default: return false;
            }
        }
    }
}
