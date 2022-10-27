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
    public class Reset
    {
        [FindsBy(How = How.Id, Using = "form_email")]
        private IWebElement form_email;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"password-reset-form\"]/div[2]/div/button")]
        private IWebElement reset_btn;

        [FindsBy(How = How.Id, Using = "form_email-error")]
        private IWebElement form_email_error;

        [FindsBy(How = How.Id, Using = "alertxx")]
        private IWebElement alertxx;


        public void userInput(string email)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_email")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"password-reset-form\"]/div[2]/div/button")));
            form_email.Clear();
            form_email.Click();
            form_email.SendKeys(email);
        }

        public void reset()
        {
            reset_btn.Click();
        }

        public bool errorShows(string error,string message)
        {
            switch (error)
            {
                case "emailNotExist":
                    return alertxx.Displayed && alertxx.Text.Contains(message);
                case "":
                    return form_email_error.Displayed && form_email_error.Text.Contains(message);
                default: return false;
            }
            
        }
    }
}
