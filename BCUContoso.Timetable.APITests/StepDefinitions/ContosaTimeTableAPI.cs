using System;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Reqnroll;
using RestSharp;

namespace Contoso.Timetable.ApiTests.StepDefinitions
{
    [Binding]
    public class ContosaTimeTableAPISteps
    {
        private readonly ApiUtils apiUtils;
        private RestResponse _response;
        private JsonDocument _jsonResponse;

        public ContosaTimeTableAPISteps(ScenarioContext scenarioContext)
        {
            apiUtils = (ApiUtils)scenarioContext["apiUtils"];
        }

             
        [When(@"I update the name of event with ID (.*) to ""(.*)""")]
        public void WhenIUpdateTheEventName(int eventId, string newName)
        {
            apiUtils.SendPutRequest($"/event/{eventId}/name?newName={newName}");
        }

        [When(@"I request the course with ID (.*)")]
        public void WhenIRequestTheCourseWithId(int courseId)
        {
            apiUtils.SendGetRequest($"/course/{courseId}");
        }

        [When(@"I request events page number (.*) with sort option ""(.*)""")]
        public void WhenIRequestEventsPageWithSort(int pageNumber, string sortOption)
        {
            apiUtils.SendGetRequest($"/event/page/{pageNumber}?sortOptions={sortOption}");
        }

        [When(@"I request the event with ID (.*)")]
        public void WhenIRequestTheEventWithId(int eventId)
        {
            apiUtils.SendGetRequest($"/event/{eventId}");
        }

        [When(@"I request students page number (.*) with sort option ""(.*)""")]
        public void WhenIRequestStudentsPageWithSort(int pageNumber, string sortOption)
        {
            apiUtils.SendGetRequest($"/student/page/{pageNumber}?sortOptions={sortOption}");
        }

        [When(@"I update the location of event with ID (.*) to ""(.*)""")]
        public void WhenIUpdateEventLocation(int eventId, string newLocation)
        {
            apiUtils.SendPutRequest($"/event/{eventId}/name?newName={newLocation}");
        }

        [When(@"I update the name of student with ID (.*) to ""(.*)""")]
        public void WhenIUpdateStudentName(int studentId, string newName)
        {
            apiUtils.SendPutRequest($"/student/{studentId}/name?newName={newName}");
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int statusCode)
        {
            _response = apiUtils.GetRawResponse();
            ((int)_response.StatusCode).Should().Be(statusCode);
        }

        [Then("the course should contain id, name, description, code, startDate, and endDate")]
        public void ThenTheCourseShouldHaveFields()
        {
            _jsonResponse = apiUtils.GetJsonResponse();
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
            _jsonResponse = apiUtils.GetJsonResponse();
            _jsonResponse.RootElement.TryGetProperty("items", out var items).Should().BeTrue();
            items.ValueKind.Should().Be(JsonValueKind.Array);
            items.GetArrayLength().Should().BeGreaterThan(0);
        }

        [Then("each (.*) should have id, name, startDate, and endDate")]
        public void ThenEachEventShouldHaveRequiredFields(string itemType)
        {
            _jsonResponse = apiUtils.GetJsonResponse();
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
            _jsonResponse = apiUtils.GetJsonResponse();
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
            _jsonResponse = apiUtils.GetJsonResponse();
            var items = _jsonResponse.RootElement.GetProperty("items").EnumerateArray();
            _jsonResponse.RootElement.GetProperty("items").GetArrayLength().Should().BeGreaterThan(0);

        }

        [When("I request courses page number {int} with sort option {string}")]
        public void WhenIRequestPageNumberWithSortOption(int pageNumber, string sortOption)
        {
            apiUtils.SendGetRequest($"/course/page/{pageNumber}?sortOptions={sortOption}");
        }


    }
}
