using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace BCUContoso.Timetable.APITests.Utils
{
    public class WebDriverManager
    {
        public IWebDriver Driver { get; private set; }

        public void LaunchBrowser(string baseUrl)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void QuitBrowser()
        {
            Driver.Quit();
        }

        public void CaptureScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            Directory.CreateDirectory(screenshotsDir);

            string fileName = $"{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine(screenshotsDir, fileName);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);

            Console.WriteLine($"Screenshot saved: {filePath}");
        }

    }

}
