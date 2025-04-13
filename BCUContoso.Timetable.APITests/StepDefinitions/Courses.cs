using System;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Reqnroll;
using RestSharp;

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
