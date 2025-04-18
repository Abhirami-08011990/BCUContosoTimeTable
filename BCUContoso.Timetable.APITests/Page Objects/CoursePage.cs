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

        public void NavigateToCourseID(string baseUrl,string courseId)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/course/"+courseId);
        }

        public IWebElement courseName()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Name']");
        }
        public IWebElement courseName2()
        {
            return FindByXpath("(//span[@class='sortable-column-header cursor-pointer' and text()='Name'])[1]");
        }
        public IWebElement courseCode()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Code']");
        }
        public IWebElement courseStart()
        {
            return FindByXpath("//span[@class='column-header' and text()='Start']");
        }

        public IWebElement courseDescription()
        {
            return FindByXpath("//span[@class='column-header' and text()='Description']");
        }

        public IWebElement courseId()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Id']");
        }

        public IWebElement courseStart2()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Start']");
        }

        public IWebElement courseEnd()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='End']");
        }

        public IWebElement enrollmentDate()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Enrollment Date']");
        }

        public IWebElement nameColumnSecond()
        {
            return FindByXpath("(//span[@class='sortable-column-header cursor-pointer' and text()='Name'])[2]");
        }

        public IWebElement emailColumnFirst()
        {
            return FindByXpath("(//span[@class='sortable-column-header cursor-pointer' and text()='Email'])[1]");
        }

        public IWebElement addressColumn()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Address']");
        }


        public int GetRowsPerPage()
        {
            var input = FindByXpath("(//p[text()='Rows per page:']/parent::div/div[@class='mud-select']//div/input/parent::div/div)[1]");
            return int.Parse(input.Text);
        }

        public int GetActualRowCount()
        {
            return FindAllByXpath("//table[@class='mud-table-root']//tr").Count - 1; // header + footer
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
