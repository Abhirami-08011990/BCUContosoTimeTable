using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCUContoso.Timetable.APITests.Page_Objects;
using BCUContoso.Timetable.APITests.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;

namespace BCUContoso.Timetable.APITests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _web;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _web = (WebDriverManager)_scenarioContext["web"];
        }

        [When("user is navigated to courses page")]
        public void UserIsNavigatedToCoursesPage()
        {
            //Navigate to baseUrl from scenariocontext /courses
            var courses = new CoursesPage(_web.Driver);
            courses.NavigateToCourses("https://localhost:7437");
            courses.AssertColumnsPresent();
        }

        [Then("The page should display a table of courses with the following columns: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldDisplayATableOfCoursesWithTheFollowingColumnsIDNameDescriptionCodeStartDateEndDate_()
        {
            //span[@class='column-header' and text()='Start']
            //span[@class='sortable-column-header cursor-pointer' and text()='Name']
            //span[@class='sortable-column-header cursor-pointer' and text()='Code']
            //span[@class='sortable-column-header cursor-pointer' and text()='Description']
        }

        [Then("The table should be paginated, with {int} items per page")]
        public void ThenTheTableShouldBePaginatedWithItemsPerPage_(int p0)
        {
            //p[text()='Rows per page:']/parent::div/div[@class='mud-select']//div/input -Take the value attribute 
            //table[@class='mud-table-root']//tr - 2 Assert this with value
        }

        [Then("The page should include pagination controls to navigate between pages")]
        public void ThenThePageShouldIncludePaginationControlsToNavigateBetweenPages_()
        {
            //button[@aria-label='Next Page' and not @disabled]
            //click on Next
            //button[@aria-label='Previous Page']
            //click on previous
        }

        [When("user is navigated to a course page")]
        public void UserIsNavigatedToACoursePage()
        {
            //Navigate to baseUrl from scenariocontext /course/41
        }

        [Then("The page should display the following course details: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldDisplayTheFollowingCourseDetailsIDNameDescriptionCodeStartDateEndDate_()
        {
            //span[@class='sortable-column-header cursor-pointer' and text()='Id']
            //(//span[@class='sortable-column-header cursor-pointer' and text()='Name'])[1]
            //Code and Description not present
            //span[@class='sortable-column-header cursor-pointer' and text()='Start']
            //span[@class='sortable-column-header cursor-pointer' and text()='End']
        }

        [Then("The page should include a list of enrolled students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date")]
        public void ThenThePageShouldIncludeAListOfEnrolledStudentsWithTheFollowingColumnsIDNameEmailAddressPhoneNumberEnrollmentDate_()
        {
            //span[@class='sortable-column-header cursor-pointer' and text()='Enrollment Date']
            //(//span[@class='sortable-column-header cursor-pointer' and text()='Name'])[2]
                //(//span[@class='sortable-column-header cursor-pointer' and text()='Email'])[1]
                //span[@class='sortable-column-header cursor-pointer' and text()='Address']
        }

        [When("user is navigated to events page")]
        public void UserIsNavigatedToEventsPage()
        {
            //Navigate to baseUrl from scenariocontext /events
        }

        [When("user is navigated to event details page")]
        public void UserIsNavigatedToEventDetailsPage()
        {
            //Navigate to baseUrl from scenariocontext /event/31
        }

        [Then("The page should display a table of events with the following columns: ID, Name, Description, Start Date, End Date, Location")]
        public void ThenThePageShouldDisplayATableOfEventsWithTheFollowingColumnsIDNameDescriptionStartDateEndDateLocation_()
        {
            //span[@class='column-header' and text()='End']
            //span[@class='column-header' and text()='Start']
            //span[@class='sortable-column-header cursor-pointer' and text()='Name']
            //span[@class='sortable-column-header cursor-pointer' and text()='Location']
        }

        [Then("Each event should have a link to view its details")]
        public void ThenEachEventShouldHaveALinkToViewItsDetails_()
        {
            //a[text()='View']/parent::td/parent::tr
            //table[@class='mud-table-root']//tr take count and subtract 2 since header n footer to be ignored
            var rows = _web.Driver.FindElements(By.XPath("//a[text()='View']/parent::td/parent::tr"));
            var allRows = _web.Driver.FindElements(By.XPath("//table[@class='mud-table-root']//tr"));
            rows.Count.Should().Be(allRows.Count - 2); // header + footer removed
        }
        [Then("The page should display the following event details: ID, Name, Description, Start Date, End Date, Location")]
        public void ThenThePageShouldDisplayTheFollowingEventDetailsIDNameDescriptionStartDateEndDateLocation_()
        {
           
        }

        [Then("The page should include the course details with the following properties: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldIncludeTheCourseDetailsWithTheFollowingPropertiesIDNameDescriptionCodeStartDateEndDate_()
        {
            
        }

        [Then("The page should include a button to update the event location")]
        public void ThenThePageShouldIncludeAButtonToUpdateTheEventLocation_()
        {
            
        }

        [Then("The button should open a modal dialog to enter the new location")]
        public void ThenTheButtonShouldOpenAModalDialogToEnterTheNewLocation_()
        {
            
        }
   

    [Then("The page should display a table of students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date")]
        public void ThenThePageShouldDisplayATableOfStudentsWithTheFollowingColumnsIDNameEmailAddressPhoneNumberEnrollmentDate_()
        {
            
        }

        [Then("Each student should have a link to view their details")]
        public void ThenEachStudentShouldHaveALinkToViewTheirDetails_()
        {
            
        }
   

     [Then("The page should display the following student details: ID, Name, Email, Address, Phone Number, Enrollment Date")]
        public void ThenThePageShouldDisplayTheFollowingStudentDetailsIDNameEmailAddressPhoneNumberEnrollmentDate_()
        {
            
        }

        [Then("The page should include a list of enrolled courses with the following columns: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldIncludeAListOfEnrolledCoursesWithTheFollowingColumnsIDNameDescriptionCodeStartDateEndDate_()
        {
            
        }

        [Then("The page should include a button to update the student's name")]
        public void ThenThePageShouldIncludeAButtonToUpdateTheStudentsName_()
        {
            
        }
    }


}
