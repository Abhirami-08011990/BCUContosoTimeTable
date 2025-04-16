using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;


namespace BCUContoso.Timetable.APITests.Page_Objects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement FindByXpath(string xpath) => Driver.FindElement(By.XPath(xpath));
        protected IReadOnlyCollection<IWebElement> FindAllByXpath(string xpath) => Driver.FindElements(By.XPath(xpath));
    }

}
