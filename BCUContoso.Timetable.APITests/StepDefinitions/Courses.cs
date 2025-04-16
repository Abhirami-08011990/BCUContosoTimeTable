using System;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Reqnroll;
using RestSharp;

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
            SendPutRequest($"/event/{eventId}/name?newName={newLocation}");
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

        [Then("each (.*) should have id, name, startDate, and endDate")]
        public void ThenEachEventShouldHaveRequiredFields(string itemType)
        {
            var root = _jsonResponse.RootElement;

            if (root.ValueKind == JsonValueKind.Array)
            {
                // Case 1: Root is an array
                foreach (var item in root.EnumerateArray())
                {
                    ValidateItemProperties(item);
                }
            }
            else if (root.ValueKind == JsonValueKind.Object)
            {
                if (root.TryGetProperty("items", out var itemsProperty) &&
                    itemsProperty.ValueKind == JsonValueKind.Array)
                {
                    // Case 2: Object with "items" array
                    foreach (var item in itemsProperty.EnumerateArray())
                    {
                        ValidateItemProperties(item);
                    }
                }
                else
                {
                    // Case 3: Single object with properties
                    ValidateItemProperties(root);
                }
            }

            void ValidateItemProperties(JsonElement item)
            {
                item.TryGetProperty("id", out _).Should().BeTrue();
                item.TryGetProperty("name", out _).Should().BeTrue();
                item.TryGetProperty("startDate", out _).Should().BeTrue();
                item.TryGetProperty("endDate", out _).Should().BeTrue();
            }


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
                item.TryGetProperty("enrollmentDate", out _).Should().BeTrue();
            }
        }

        [Then("the response should contain a list of (.*)")]
        public void ThenTheResponseShouldContainAListOfStudents(string type)
        {
            var items = _jsonResponse.RootElement.GetProperty("items").EnumerateArray();
            _jsonResponse.RootElement.GetProperty("items").GetArrayLength().Should().BeGreaterThan(0);

        }

        [When("I request courses page number {int} with sort option {string}")]
        public void WhenIRequestPageNumberWithSortOption(int pageNumber, string sortOption)
        {
            SendGetRequest($"/course/page/{pageNumber}?sortOptions={sortOption}");
        }


    }
}
