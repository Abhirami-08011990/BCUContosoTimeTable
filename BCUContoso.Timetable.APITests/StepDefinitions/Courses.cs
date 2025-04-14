using System;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Reqnroll;
using RestSharp;
/*
namespace Contoso.Timetable.ApiTests.StepDefinitions
{
    [Binding]
    public class CoursePaginationSteps
    {
        private RestClient _client;
        private RestResponse _response;
        private JsonDocument _jsonResponse;

        [Given("the API is available")]
        public void GivenTheApiIsAvailable()
        {
            _client = new RestClient("https://localhost:7437"); // Replace with your API base URL
        }

        [When("I request page number (.*) with sort option \"(.*)\"")]
        public void WhenIRequestPageNumberWithSortOption(int pageNumber, string sortOption)
        {
            var request = new RestRequest($"/course/page/{pageNumber}?sortOptions={sortOption}", Method.Get);
            Console.WriteLine(request.ToString());
           
            _response = _client.Execute<RestResponse>(request);
            if (string.IsNullOrWhiteSpace(_response.Content))
            {
                Console.WriteLine("Response content is null or empty.");
                Console.WriteLine($"Status Code: {_response.StatusCode}");
                Console.WriteLine($"Error Message: {_response.ErrorMessage}");
                return;
            }
            Console.WriteLine($"Status Code: {_response.StatusCode}");
            Console.WriteLine($"Response Content: {_response.Content}");
            Console.WriteLine($"Error Message: {_response.ErrorMessage}");
            _jsonResponse = JsonDocument.Parse(_response.Content);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            ((int)_response.StatusCode).Should().Be(expectedStatusCode);
        }

        [Then("the response should contain a list of courses")]
        public void ThenTheResponseShouldContainAListOfCourses()
        {
            _jsonResponse.RootElement.TryGetProperty("items", out var items).Should().BeTrue();
            items.ValueKind.Should().Be(JsonValueKind.Array);
            items.GetArrayLength().Should().BeGreaterThan(0);
        }

        [Then("each course should have id, name, description, code, startDate, and endDate")]
        public void ThenEachCourseShouldHaveRequiredFields()
        {
            var courses = _jsonResponse.RootElement.GetProperty("items").EnumerateArray();
            foreach (var course in courses)
            {
                course.TryGetProperty("id", out _).Should().BeTrue();
                course.TryGetProperty("name", out _).Should().BeTrue();
                course.TryGetProperty("description", out _).Should().BeTrue();
                course.TryGetProperty("code", out _).Should().BeTrue();
                course.TryGetProperty("startDate", out _).Should().BeTrue();
                course.TryGetProperty("endDate", out _).Should().BeTrue();
            }
        }
    }
}
*/

namespace Contoso.Timetable.ApiTests.StepDefinitions
{
    [Binding]
    public class EventsAndStudentsSteps
    {
        private RestClient _client;
        private RestResponse _response;
        private JsonDocument _jsonResponse;

        [Given("the API is available")]
        public void GivenTheApiIsAvailable()
        {
            _client = new RestClient("https://localhost:7437"); // Replace with your base URL
        }

        private void SendGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            _response = _client.Execute<RestResponse>(request);
            LogResponse();
            if (!string.IsNullOrWhiteSpace(_response.Content))
                _jsonResponse = JsonDocument.Parse(_response.Content);
        }

        private void SendPutRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Put);
            _response = _client.Execute<RestResponse>(request);
            LogResponse();
            if (!string.IsNullOrWhiteSpace(_response.Content))
                _jsonResponse = JsonDocument.Parse(_response.Content);
        }

        private void LogResponse()
        {
            Console.WriteLine($"Status Code: {_response.StatusCode}");
            Console.WriteLine($"Response: {_response.Content}");
            Console.WriteLine($"Error: {_response.ErrorMessage}");
        }

        [When(@"I update the name of event with ID (.*) to ""(.*)""")]
        public void WhenIUpdateTheEventName(int eventId, string newName)
        {
            SendPutRequest($"/event/{eventId}/name?newName={newName}");
        }

        [When(@"I request the course with ID (.*)")]
        public void WhenIRequestTheCourseWithId(int courseId)
        {
            SendGetRequest($"/course/{courseId}");
        }

        [When(@"I request events page number (.*) with sort option ""(.*)""")]
        public void WhenIRequestEventsPageWithSort(int pageNumber, string sortOption)
        {
            SendGetRequest($"/event/page/{pageNumber}?sortOptions={sortOption}");
        }

        [When(@"I request the event with ID (.*)")]
        public void WhenIRequestTheEventWithId(int eventId)
        {
            SendGetRequest($"/event/{eventId}");
        }

        [When(@"I request students page number (.*) with sort option ""(.*)""")]
        public void WhenIRequestStudentsPageWithSort(int pageNumber, string sortOption)
        {
            SendGetRequest($"/student/page/{pageNumber}?sortOptions={sortOption}");
        }

        [When(@"I update the location of event with ID (.*) to ""(.*)""")]
        public void WhenIUpdateEventLocation(int eventId, string newLocation)
        {
            SendPutRequest($"/event/{eventId}/location?newLocation={newLocation}");
        }

        [When(@"I update the name of student with ID (.*) to ""(.*)""")]
        public void WhenIUpdateStudentName(int studentId, string newName)
        {
            SendPutRequest($"/student/{studentId}/name?newName={newName}");
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int statusCode)
        {
            ((int)_response.StatusCode).Should().Be(statusCode);
        }

        [Then("the course should contain id, name, description, code, startDate, and endDate")]
        public void ThenTheCourseShouldHaveFields()
        {
            var root = _jsonResponse.RootElement;
            root.TryGetProperty("id", out _).Should().BeTrue();
            root.TryGetProperty("name", out _).Should().BeTrue();
            root.TryGetProperty("description", out _).Should().BeTrue();
            root.TryGetProperty("code", out _).Should().BeTrue();
            root.TryGetProperty("startDate", out _).Should().BeTrue();
            root.TryGetProperty("endDate", out _).Should().BeTrue();
        }

        [Then("the response should contain a list of (events|students)")]
        public void ThenTheResponseShouldContainAListOf(string type)
        {
            _jsonResponse.RootElement.TryGetProperty("items", out var items).Should().BeTrue();
            items.ValueKind.Should().Be(JsonValueKind.Array);
            items.GetArrayLength().Should().BeGreaterThan(0);
        }

        [Then("each event should have id, name, location, startDate, and endDate")]
        public void ThenEachEventShouldHaveRequiredFields()
        {
            var items = _jsonResponse.RootElement.GetProperty("items").EnumerateArray();
            foreach (var item in items)
            {
                item.TryGetProperty("id", out _).Should().BeTrue();
                item.TryGetProperty("name", out _).Should().BeTrue();
                item.TryGetProperty("location", out _).Should().BeTrue();
                item.TryGetProperty("startDate", out _).Should().BeTrue();
                item.TryGetProperty("endDate", out _).Should().BeTrue();
            }
        }

        [Then("the event should have id, name, location, startDate, and endDate")]
        public void ThenTheSingleEventShouldHaveRequiredFields()
        {
            ThenEachEventShouldHaveRequiredFields();
        }

        [Then("each student should have id, name, email, and enrolmentDate")]
        public void ThenEachStudentShouldHaveRequiredFields()
        {
            var items = _jsonResponse.RootElement.GetProperty("items").EnumerateArray();
            foreach (var item in items)
            {
                item.TryGetProperty("id", out _).Should().BeTrue();
                item.TryGetProperty("name", out _).Should().BeTrue();
                item.TryGetProperty("email", out _).Should().BeTrue();
                item.TryGetProperty("enrolmentDate", out _).Should().BeTrue();
            }
        }

        [Then("the response should contain a list of students")]
        public void ThenTheResponseShouldContainAListOfStudents()
        {
            
        }

        [When("I request page number {int} with sort option {string}")]
        public void WhenIRequestPageNumberWithSortOption(int p0, string nameAscending)
        {
            
        }

        [Then("the response should contain a list of courses")]
        public void ThenTheResponseShouldContainAListOfCourses()
        {

        }

        [Then("each course should have id, name, description, code, startDate, and endDate")]
        public void ThenEachCourseShouldHaveIdNameDescriptionCodeStartDateAndEndDate()
        {

        }


    }
}
