using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace BCUContoso.Timetable.APITests.Page_Objects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitForPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").ToString() == "complete");
        }


        protected IWebElement FindByXpath(string xpath) => Driver.FindElement(By.XPath(xpath));
        protected IReadOnlyCollection<IWebElement> FindAllByXpath(string xpath) => Driver.FindElements(By.XPath(xpath));
       
    }

}
