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
    public class AdminAtricleCategory
    {
        [FindsBy(How = How.Id, Using = "category-name-field")]
        private IWebElement fname;

        [FindsBy(How = How.Id, Using = "category-code-field")]
        private IWebElement fcode;

        //[FindsBy(How = How.CssSelector, Using = "select2-chosen")]
        //private SelectElement fparent;

        [FindsBy(How = How.Id, Using = "category-seoTitle-field")]
        private IWebElement ftitle;
        
        [FindsBy(How = How.Id, Using = "category-seoKeyword-field")]
        private IWebElement fkeyword;

        [FindsBy(How = How.Id, Using = "category-seoDesc-field")]
        private IWebElement fdesc;
        
        [FindsBy(How = How.Id, Using = "category-published-field")]
        private  IList<IWebElement> fpub;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"modal\"]/div/div/div[1]/button")]
        private IWebElement close;

        public void userInput(string name, string code, string pre, string title, string key, string desc, int pub)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));
            fname.SendKeys(name);
            fcode.SendKeys(code);
            //fparent.SelectByValue(pre);
            ftitle.SendKeys(title);
            fkeyword.SendKeys(desc);
            fdesc.SendKeys(key);
        }

        public void userEdit(string name, string code, string pre, string title, string key, string desc, int pub)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));
            fname.Clear();
            fcode.Clear();
            ftitle.Clear();
            fkeyword.Clear();
            fdesc.Clear();
            fname.SendKeys(name);
            fcode.SendKeys(code);
            //fparent.SelectByValue(pre);
            ftitle.SendKeys(title);
            fkeyword.SendKeys(desc);
            fdesc.SendKeys(key);
        }
        
    }
}
