using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BCUContoso.Timetable.APITests.Page_Objects
{
    public class CoursesPage : BasePage
    {
        public CoursesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToCourses(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/courses");
        }

        public void AssertColumnsPresent()
        {
            FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Name']");
            FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Code']");
            FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Description']");
            FindByXpath("//span[@class='column-header' and text()='Start']");
        }

        public int GetRowsPerPage()
        {
            var input = FindByXpath("//p[text()='Rows per page:']/parent::div/div[@class='mud-select']//div/input");
            return int.Parse(input.GetAttribute("value"));
        }

        public int GetActualRowCount()
        {
            return FindAllByXpath("//table[@class='mud-table-root']//tr").Count - 2; // header + footer
        }

        public void ClickNextPage()
        {
            FindByXpath("//button[@aria-label='Next Page' and not(@disabled)]").Click();
        }

        public void ClickPreviousPage()
        {
            FindByXpath("//button[@aria-label='Previous Page']").Click();
        }
    }

}
