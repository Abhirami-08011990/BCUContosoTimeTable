using System.Diagnostics;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace BCUContoso.Timetable.ApiTests.StepDefinitions
{
    [Binding]
    public class CourseSteps
    {
        private RestResponse _response;
        private Stopwatch _timer;

        private readonly string _baseUrl = "http://localhost:5000"; // Change to your running API

        [Given("the API is available")]
        public void GivenTheApiIsAvailable()
        {
            // Could ping /health if needed
        }

        [When(@"I request page number (.*) with sort option ""(.*)""")]
        public void WhenIRequestPageWithSort(string pageNumber, string sortOption)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"/course/page/{pageNumber}?sortOptions={sortOption}", Method.Get);
            _timer = Stopwatch.StartNew();
            _response = client.Execute(request);
            _timer.Stop();
        }

        [When(@"I request an invalid page number ""(.*)""")]
        public void WhenIRequestInvalidPage(string pageNumber)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"/course/page/{pageNumber}", Method.Get);
            _response = client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenResponseShouldBe(int code)
        {
            ((int)_response.StatusCode).Should().Be(code);
        }

        [Then("the response should contain course objects")]
        public void ThenShouldContainCourses()
        {
            var json = JObject.Parse(_response.Content);
            var items = json["items"];
            items.Should().NotBeNull();
            items.Type.Should().Be(JTokenType.Array);
        }
    }
}
