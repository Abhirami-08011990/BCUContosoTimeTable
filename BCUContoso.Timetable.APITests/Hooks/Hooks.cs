using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCUContoso.Timetable.APITests.Utils;
using Reqnroll;

namespace BCUContoso.Timetable.APITests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Contosa Time Table API is available")]
        public void GivenTheApiIsAvailable()
        {
            var apiUtils = new ApiUtils();
            apiUtils.SetClient("https://localhost:7437"); // Replace with your base URL
            _scenarioContext["apiUtils"] = apiUtils;
        }

        [Given("Contosa Time Table Blazor is available")]
        public void GivenContosaTimeTableBlazorIsAvailable()
        {
            var web = new WebDriverManager();
            _scenarioContext["web"] = web;
            web.LaunchBrowser("https://localhost:7437");

        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    var web = (WebDriverManager)_scenarioContext["web"];
        //    web.QuitBrowser();
        //}
    }

}
