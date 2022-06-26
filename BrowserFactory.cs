using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsSelenium
{
    public class BrowserFactory
    {
        public static IWebDriver driver;
        public static void OpenBrowser(string Browser)
        {
            switch(Browser)
            {
                case "Chromer":
                    BrowserFactory.ChromeBrowser();
                break;
                case "Edge":
                    BrowserFactory.EdgeBrowser();
                    break;
                case "Firefox":
                    BrowserFactory.FirefoxBrowser();
                break;
                default:
                    BrowserFactory.ChromeBrowser();
                break;
            }
        }
        private static void ChromeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();            
        }
        private static void EdgeBrowser()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        private static void FirefoxBrowser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
        public static void CloseBrowser()
        {
            driver.Quit();
        }
        public static void OpenApplication(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        public static void TakeFullScreenshot( string filename)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
        }
    }
}
