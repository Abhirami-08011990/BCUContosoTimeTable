﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BCUContoso.Timetable.APITests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ContosaTimeTableAPIFeature : object, Xunit.IClassFixture<ContosaTimeTableAPIFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Contosa Time Table API", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Contosa Time table API.feature"
#line hidden
        
        public ContosaTimeTableAPIFeature(ContosaTimeTableAPIFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 3
#line hidden
#line 4
 await testRunner.GivenAsync("Contosa Time Table API is available", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3790-GET CourseSort Options")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3790-GET CourseSort Options")]
        public async System.Threading.Tasks.Task _3790_GETCourseSortOptions()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3790-GET CourseSort Options", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 7
    await testRunner.WhenAsync("I request courses page number 1 with sort option \"NameAscending\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 8
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 9
    await testRunner.AndAsync("the response should contain a list of courses", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 10
    await testRunner.AndAsync("each course should have id, name, startDate, and endDate", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3792-PUT Update New Course Name")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3792-PUT Update New Course Name")]
        public async System.Threading.Tasks.Task _3792_PUTUpdateNewCourseName()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3792-PUT Update New Course Name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 14
    await testRunner.WhenAsync("I update the name of event with ID 1 to \"Manchester\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 15
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3791 -GET Course Id")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3791 -GET Course Id")]
        public async System.Threading.Tasks.Task _3791_GETCourseId()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3791 -GET Course Id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 19
    await testRunner.WhenAsync("I request the course with ID 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 20
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 21
    await testRunner.AndAsync("the course should contain id, name, description, code, startDate, and endDate", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3793-GET Event Sort Options")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3793-GET Event Sort Options")]
        public async System.Threading.Tasks.Task _3793_GETEventSortOptions()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3793-GET Event Sort Options", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 23
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 25
    await testRunner.WhenAsync("I request events page number 1 with sort option \"NameDescending\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 26
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 27
    await testRunner.AndAsync("each event should have id, name, startDate, and endDate", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3794-GET Event ID")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3794-GET Event ID")]
        public async System.Threading.Tasks.Task _3794_GETEventID()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3794-GET Event ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 31
    await testRunner.WhenAsync("I request the event with ID 91", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 32
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 33
    await testRunner.AndAsync("each course should have id, name, startDate, and endDate", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3796-GET Student Sort Options")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3796-GET Student Sort Options")]
        public async System.Threading.Tasks.Task _3796_GETStudentSortOptions()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3796-GET Student Sort Options", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 37
    await testRunner.WhenAsync("I request students page number 1 with sort option \"NameAscending\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 38
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 39
    await testRunner.AndAsync("the response should contain a list of students", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 40
    await testRunner.AndAsync("each student should have id, name, email, and enrolmentDate", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3797-GET Student ID")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3797-GET Student ID")]
        public async System.Threading.Tasks.Task _3797_GETStudentID()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3797-GET Student ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 44
    await testRunner.WhenAsync("I update the location of event with ID 91 to \"London\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 45
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="3798-PUT Update New Student Name")]
        [Xunit.TraitAttribute("FeatureTitle", "Contosa Time Table API")]
        [Xunit.TraitAttribute("Description", "3798-PUT Update New Student Name")]
        public async System.Threading.Tasks.Task _3798_PUTUpdateNewStudentName()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("3798-PUT Update New Student Name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 47
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 49
    await testRunner.WhenAsync("I update the name of student with ID 1 to \"John Doe\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 50
    await testRunner.ThenAsync("the response status code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await ContosaTimeTableAPIFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await ContosaTimeTableAPIFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
