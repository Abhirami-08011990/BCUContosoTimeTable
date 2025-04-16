using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BCUContoso.Timetable.APITests.Utils
{
    public class WebDriverManager
    {
        public IWebDriver Driver { get; private set; }

        public void LaunchBrowser(string baseUrl)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(baseUrl);
        }

        public void QuitBrowser()
        {
            Driver.Quit();
        }
    }

}
