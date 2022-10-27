using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyra2.Pages
{
    public static class Browser
    {
        static IWebDriver webDriver = new ChromeDriver();

        public static string Title { get { return webDriver.Title; } }

        public static ISearchContext SearchContext { get { return webDriver; } }

        public static IWebDriver WebDriver { get { return webDriver; } }

        public static void Goto(string url) { webDriver.Url = url; }

        public static void Quit() { webDriver.Quit(); }

    }
}
