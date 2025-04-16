using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BCUContoso.Timetable.APITests.Page_Objects
{
    public class EventDetailsPage : BasePage
    {
        public EventDetailsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToEvent(string baseUrl, int eventId)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/event/{eventId}");
        }

        public void AssertEventDetailColumns()
        {
            FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Name']");
            FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Location']");
            FindByXpath("//span[@class='column-header' and text()='Start']");
            FindByXpath("//span[@class='column-header' and text()='End']");
        }
    }

}
