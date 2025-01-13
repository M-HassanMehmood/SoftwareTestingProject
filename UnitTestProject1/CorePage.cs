using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Threading;
using Status = AventStack.ExtentReports.Status;

namespace SoftwareTestingProject
{
    public class CorePage
    {
        public static IWebDriver driver;
        public static TestContext testContext;
        public static string ExecutionBrowser { get; set; }
        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Step;


        public static void SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                // chromeOptions.AddArguments("--start-maximized");
                IWebDriver chromDriver = new ChromeDriver();
                driver = chromDriver;

            }
            else if (browser == "FireFox")
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("--start-maximized");

                driver = new FirefoxDriver(options);
            }
        }
        public static void SeleniumInit()
        {
            driver = new ChromeDriver();
        }

        public void write(By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenShot(Status.Pass, "Data Entered Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenShot(Status.Fail, "Failed:" + ex);
            }
        }
        public void click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenShot(Status.Pass, "Clicked Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenShot(Status.Fail, "Failed:" + ex);
            }
        }
        public void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public void CloseSelenium()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        public static void TakeScreenShot(Status status, string stepDetail)
        {
            string path = @"C:\ExtentReports\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            Step.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
        }

        public static void CreateReport(string path)
        {
            extentReports = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(path);
            extentReports.AttachReporter(sparkReporter);
        }

    }
}
