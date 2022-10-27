using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyra2.Pages
{
    public class Page
    {
        public static Home Home
        {
            get
            {
                var home = new Home();
                PageFactory.InitElements(Browser.SearchContext, home);
                return home;
            }
        }

        public static Login Login
        {
            get
            {
                var login = new Login();
                PageFactory.InitElements(Browser.SearchContext, login);
                return login;
            }
        }

        public static Register Register
        {
            get
            {
                var register = new Register();
                PageFactory.InitElements(Browser.SearchContext, register);
                return register;
            }
        }

        public static Reset Reset
        {
            get
            {
                var reset = new Reset();
                PageFactory.InitElements(Browser.SearchContext, reset);
                return reset;
            }
        }

        public static Settings Settings
        {
            get
            {
                var settings = new Settings();
                PageFactory.InitElements(Browser.SearchContext, settings);
                return settings;
            }
        }

        public static AdminAtricleCategory adminAtricleCategory
        {
            get
            {
                var adminAtricleCategory = new AdminAtricleCategory();
                PageFactory.InitElements(Browser.SearchContext, adminAtricleCategory);
                return adminAtricleCategory;
            }
        }
    }
}
