using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCUContoso.Timetable.APITests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace BCUContoso.Timetable.APITests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
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
            web.LaunchBrowser("https://localhost:7092/students");

        }

        [AfterScenario]
        public void AfterScenario()
        {
                                    
            if (_featureContext.FeatureInfo.Tags.Contains("web"))
            {
                var web = (WebDriverManager)_scenarioContext["web"];
                web.QuitBrowser();
            }
        }


    }

}
