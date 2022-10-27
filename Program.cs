using lyra2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyra2
{
    internal class Program
    {
        static void Main()
        {
            Page.Home.Goto();
            Browser.Quit();
        }
    }
}
