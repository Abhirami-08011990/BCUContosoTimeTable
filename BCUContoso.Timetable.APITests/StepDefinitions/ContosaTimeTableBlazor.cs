using System;
using System.Threading.Tasks;
using BCUContoso.Timetable.APITests.Page_Objects;
using BCUContoso.Timetable.APITests.Utils;
using OpenQA.Selenium;
using Reqnroll;
using Xunit;

namespace BCUContoso.Timetable.APITests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _web;
        CoursesPage courses;
        EventDetailsPage events;
        StudentsPage students;
        string url = "https://localhost:7092";

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _web = (WebDriverManager)_scenarioContext["web"];
            courses = new CoursesPage(_web.Driver); 
            events = new EventDetailsPage(_web.Driver);
            students = new StudentsPage(_web.Driver);
        }

        [When("user is navigated to courses page")]
        public void UserIsNavigatedToCoursesPage()
        {
            courses.NavigateToCourses(url);
            courses.WaitForPageLoad();
        }

        [Then("The page should display a table of courses with the following columns: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldDisplayATableOfCoursesWithTheFollowingColumnsIDNameDescriptionCodeStartDateEndDate_()
        {
            
            Assert.True(courses.courseName().Displayed, "'Name' column header is not displayed.");
            Assert.True(courses.courseDescription().Displayed, "'Description' column header is not displayed.");
            Assert.True(courses.courseCode().Displayed, "'Code' column header is not displayed.");
            Assert.True(courses.courseStart().Displayed, "'Start' column header is not displayed.");
        }

        [Then("The table should be paginated, with {int} items per page")]
        public void ThenTheTableShouldBePaginatedWithItemsPerPage_(int p0)
        {
            _web.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var rowsPerPageInput = courses.GetRowsPerPage();
            var tableRows = courses.GetActualRowCount();
            _web.CaptureScreenshot(_web.Driver, _scenarioContext);
            Assert.Equal(rowsPerPageInput, tableRows);

        }

        [Then("The page should include pagination controls to navigate between pages")]
        public void ThenThePageShouldIncludePaginationControlsToNavigateBetweenPages_()
        {
            courses.ClickNextPage();
            courses.ClickPreviousPage();
        }

        [When("user is navigated to a course page")]
        public void UserIsNavigatedToACoursePage()
        {
            courses.NavigateToCourseID(url,"41");
            courses.WaitForPageLoad();
        }

        [Then("The page should display the following course details: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldDisplayTheFollowingCourseDetailsIDNameDescriptionCodeStartDateEndDate_()
        {
            _web.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.True(courses.courseId().Displayed, "'ID' column header is not displayed.");
            Assert.True(courses.courseStart2().Displayed, "'Start' column header is not displayed.");
            Assert.True(courses.courseEnd().Displayed, "'End' column header is not displayed.");
        }

        [Then("The page should include a list of enrolled students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date")]
        public void ThenThePageShouldIncludeAListOfEnrolledStudentsWithTheFollowingColumnsIDNameEmailAddressPhoneNumberEnrollmentDate_()
        {
            Assert.True(courses.courseEnd().Displayed, "'End' column header is not displayed.");
            Assert.True(courses.enrollmentDate().Displayed, "'Enrollment Date' column header is not displayed.");
            Assert.True(courses.nameColumnSecond().Displayed, "Second 'Name' column header is not displayed.");
            Assert.True(courses.emailColumnFirst().Displayed, "First 'Email' column header is not displayed.");
            Assert.True(courses.addressColumn().Displayed, "'Address' column header is not displayed.");

        }

        [When("user is navigated to events page")]
        public void UserIsNavigatedToEventsPage()
        {
            events.NavigateToEvents(url);
            events.WaitForPageLoad();
        }

        [When("user is navigated to event details page")]
        public void UserIsNavigatedToEventDetailsPage()
        {
            events.NavigateToEvent(url, 31);
            events.WaitForPageLoad();
        }

        [Then("The page should display a table of events with the following columns: ID, Name, Description, Start Date, End Date, Location")]
        public void ThenThePageShouldDisplayATableOfEventsWithTheFollowingColumnsIDNameDescriptionStartDateEndDateLocation_()
        {
            Assert.True(events.nameColumn().Displayed, "'Name' column header is not displayed.");
            Assert.True(events.locationColumn().Displayed, "'Location' column header is not displayed.");
            Assert.True(events.startColumn().Displayed, "'Start' column header is not displayed.");
            Assert.True(events.endColumn().Displayed, "'End' column header is not displayed.");

        }

        [Then("Each event should have a link to view its details")]
        public void ThenEachEventShouldHaveALinkToViewItsDetails_()
        {
            var rowsPerPageInput = events.GetRowsPerPage();
            var tableRows = events.GetActualRowCount();
            Assert.Equal(rowsPerPageInput, tableRows);
        }
        [Then("The page should display the following event details: ID, Name, Description, Start Date, End Date, Location")]
        public void ThenThePageShouldDisplayTheFollowingEventDetailsIDNameDescriptionStartDateEndDateLocation_()
        {
            Assert.True(events.idColumn().Displayed, "'Id' column header is not displayed.");
            Assert.True(events.startDateColumn(1).Displayed, "'Start Date' column header is not displayed.");
            Assert.True(events.endDateColumn(1).Displayed, "'End Date' column header is not displayed.");
            Assert.True(events.locationColumn2(1).Displayed, "'Location' column header is not displayed.");
            Assert.True(events.descriptionColumn(1).Displayed, "'Description' column header is not displayed.");
        }

        [Then("The page should include the course details with the following properties: ID, Name, Description, Code, Start Date, End Date")]
        public void ThenThePageShouldIncludeTheCourseDetailsWithTheFollowingPropertiesIDNameDescriptionCodeStartDateEndDate_()
        {
            Assert.True(events.codeColumn().Displayed, "'Code' column header is not displayed.");
            Assert.True(events.startDateColumn(2).Displayed, "'Start Date' column header is not displayed.");
            Assert.True(events.descriptionColumn(2).Displayed, "'Description' column header is not displayed.");
        }

        [Then("The page should include a button to update the event location")]
        public void ThenThePageShouldIncludeAButtonToUpdateTheEventLocation_()
        {
            IWebElement location = events.modifyLocationbutton();
            location.Click();
        }

        [Then("The button should open a modal dialog to enter the new location")]
        public void ThenTheButtonShouldOpenAModalDialogToEnterTheNewLocation_()
        {
            Assert.True(events.enterLocation().Displayed, "'Location Dialog is not displayed.");
        }

        [When("user is navigated to students page")]
        public void UserIsNavigatedToStudentsPage()
        {
            students.NavigateToStudents(url);
            events.WaitForPageLoad();
        }

        [When("user is navigated to student details page")]
        public void UserIsNavigatedToStudentDetailsPage()
        {
            students.NavigateToStudentId(url,23);
            events.WaitForPageLoad();
        }

        [Then("The page should display a table of students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date")]
        public void ThenThePageShouldDisplayATableOfStudentsWithTheFollowingColumnsIDNameEmailAddressPhoneNumberEnrollmentDate_()
        {
           Assert.True(students.enrollmentDate().Displayed, "'Enrollment Date' column header is not displayed.");
            Assert.True(students.studentName().Displayed, "Name' column header is not displayed.");
            Assert.True(students.studentEmail().Displayed, "Student 'Email' column header is not displayed.");
            Assert.True(students.studentAddress().Displayed, "Student 'Address' column header is not displayed.");
        }

        [Then("Each student should have a link to view their details")]
        public void ThenEachStudentShouldHaveALinkToViewTheirDetails_()
        {
            var viewsCount = students.GetViewLnkCount();
            var tableRows = students.GetActualRowCount();
            Assert.Equal(viewsCount, tableRows);
        }


        [When("The page should include a list of enrolled courses with the following columns Name, Description, Code, Start Date")]
        public void WhenThePageShouldIncludeAListOfEnrolledCoursesWithTheFollowingColumnsIDNameDescriptionCodeStartDateEndDate_()
        {
            _web.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.True(students.studentName().Displayed, "'Name' column header is not displayed.");
            Assert.True(students.courseCode().Displayed, "'Code' column header is not displayed.");
            Assert.True(students.courseDescription().Displayed, "'Description' column header is not displayed.");
            Assert.True(students.courseStart().Displayed, "'Start' column header is not displayed.");
        }

        [Then("The page should include a button to update the student name")]
        public void ThenThePageShouldIncludeAButtonToUpdateTheStudentsName()
        {
            Assert.True(students.viewLink().Displayed, "'View Link is not displayed.");
        }
    }


}
