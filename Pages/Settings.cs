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
    public class Settings
    {
        [FindsBy(How = How.Id, Using = "profile_truename")]
        private IWebElement profile_truename;

        [FindsBy(How = How.Id, Using = "profile_idcard")]
        private IWebElement profile_idcard;

        [FindsBy(How = How.Id, Using = "profile_mobile")]
        private IWebElement profile_mobile;

        [FindsBy(How = How.Id, Using = "profile_title")]
        private IWebElement profile_title;

        [FindsBy(How = How.Id, Using = "profile_site")]
        private IWebElement profile_site;

        [FindsBy(How = How.Id, Using = "weibo")]
        private IWebElement profile_weibo;

        [FindsBy(How = How.Id, Using = "profile_qq")]
        private IWebElement profile_qq;

        [FindsBy(How = How.Id, Using = "profile-save-btn")]
        private IWebElement profile_save_btn;

        [FindsBy(How = How.Id, Using = "profile_truename-error")]
        private IWebElement profile_truename_error;

        [FindsBy(How = How.Id, Using = "profile_idcard-error")]
        private IWebElement profile_idcard_error;

        [FindsBy(How = How.Id, Using = "profile_mobile-error")]
        private IWebElement profile_mobile_error;

        [FindsBy(How = How.Id, Using = "profile_title-error")]
        private IWebElement profile_title_error;

        [FindsBy(How = How.Id, Using = "profile_site-error")]
        private IWebElement profile_site_error;

        [FindsBy(How = How.Id, Using = "weibo-error")]
        private IWebElement profile_weibo_error;

        [FindsBy(How = How.Id, Using = "profile_qq-error")]
        private IWebElement profile_qq_error;

        public void userInput(string name, string id, string phone, string title, string profile, string weibo, string qq)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile-save-btn")));
            profile_truename.Clear();
            profile_idcard.Clear();
            profile_mobile.Clear();
            profile_title.Clear();
            profile_site.Clear();
            profile_weibo.Clear();
            profile_qq.Clear();
            profile_truename.SendKeys(name);
            profile_idcard.SendKeys(id);
            profile_mobile.SendKeys(phone);
            profile_title.SendKeys(title);
            profile_site.SendKeys(profile);
            profile_weibo.SendKeys(weibo);
            profile_qq.SendKeys(qq);
        }

        public void save()
        {
            profile_save_btn.Click();
        }
    }
}
