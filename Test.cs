using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections;

namespace JenkinsSelenium
{
    public class Test : BrowserFactory
    {
        string inputfile = @"C:\Users\amaurya\source\repos\JenkinsSelenium\TestData\Data.xlsx";
        string browser = "Chrome";
        string screenshotname = @"C:\Users\amaurya\source\repos\JenkinsSelenium\TestData\Screenshot.Png";

        [SetUp]
        public void start_Browser()
        {
            BrowserFactory.OpenBrowser(browser);
        }
        [TearDown]
        public void close_Browser()
        {
            BrowserFactory.CloseBrowser();
        }
        [Test]
        //public void Initiate(string url, string username, string password)
        public void Initiate()
        {
            var ExcelReaderFile = new ExcelReaderFile(inputfile);
            int row = ExcelReaderFile.getRowCount("Login");
            for (int i = 0; i < row; i++)
            {
                string url = ExcelReaderFile.getCellData("Login", "URL", 2);
                string username = ExcelReaderFile.getCellData("Login", "UserName", 2);
                string password = ExcelReaderFile.getCellData("Login", "Password", 2);
                Test.login(url, username, password);
                BrowserFactory.TakeFullScreenshot(screenshotname);
            }                 
        }             
        public static void login(string url, string username, string password)
        {
            BrowserFactory.OpenApplication(url);
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            driver.FindElement(By.Id("btnLogin")).Click();
        }
    }
}
