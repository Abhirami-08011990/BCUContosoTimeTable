using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BCUContoso.Timetable.APITests.Page_Objects
{
    public class StudentsPage : BasePage
    {
        public StudentsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToStudents(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/students");
        }

        public void NavigateToStudentId(string baseUrl, int studentId)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/student/{studentId}");
        }

        public IWebElement enrollmentDate()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Enrollment Date']");
        }

        public IWebElement studentName()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Name']");
        }

        public IWebElement studentEmail()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Email']");
        }

        public IWebElement studentAddress()
        {
            return FindByXpath("//span[@class='column-header' and text()='Address']");
        }

        public IWebElement courseDescription()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Description']");
        }
        public IWebElement courseCode()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Code']");
        }
        public IWebElement courseStart()
        {
            return FindByXpath("//span[@class='sortable-column-header cursor-pointer' and text()='Start']");
        }

        public IWebElement viewLink()
        {
            return FindByXpath("(//a[text()='View'])[1]");
        }

        

        public int GetActualRowCount()
        {
            return FindAllByXpath("//td[@class='d-flex justify-end mud-table-cell']").Count;
        }

        public int GetViewLnkCount()
        {
            return FindAllByXpath("//a[text()='View']").Count;
        }
        

    }

}
