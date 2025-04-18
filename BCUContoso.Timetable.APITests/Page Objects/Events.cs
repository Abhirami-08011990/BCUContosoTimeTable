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

        public void NavigateToEvents(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/events");
        }

        public IWebElement nameColumn()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Name']");
        }

        public IWebElement locationColumn()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Location']");
        }

        public IWebElement startColumn()
        {
            return FindByXpath("//span[@class='column-header' and text()='Start']");
        }

        public IWebElement endColumn()
        {
            return FindByXpath("//span[@class='column-header' and text()='End']");
        }

        public int GetRowsPerPage()
        {
            var input = FindByXpath("//a[text()='View']/parent::td/parent::tr");
            return int.Parse(input.Text);
        }

        public int GetActualRowCount()
        {
            return FindAllByXpath("//table[@class='mud-table-root']//tr").Count - 1; // header + footer
        }

        public IWebElement idColumn()
        {
            return FindByXpath("//b[text()='Id: ']");
        }
        public IWebElement codeColumn()
        {
            return FindByXpath("//b[text()='Code: ']");
        }
        

        public IWebElement startDateColumn(int index)
        {
            return FindByXpath($"(//b[text()='Start Date: '])[{index}]");
        }

        public IWebElement endDateColumn(int index)
        {
            return FindByXpath($"(//b[text()='End Date: '])[{index}]");
        }

        public IWebElement locationColumn2(int index)
        {
            return FindByXpath($"(//b[text()='Location: '])[{index}]");
        }

        public IWebElement descriptionColumn(int index)
        {
            return FindByXpath($"(//b[text()='Description: '])[{index}]");
        }
        public IWebElement modifyLocationbutton()
        {
            return FindByXpath("//span[@class='mud-icon-button-label']");
        }
        public IWebElement enterLocation()
        {
            return FindByXpath("//input[@placeholder='Enter location']");
        }

        }

}
