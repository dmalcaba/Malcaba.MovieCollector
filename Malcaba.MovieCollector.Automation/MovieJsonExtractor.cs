using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Malcaba.MovieCollector.Automation
{
    public static class MovieJsonExtractor
    {
        private const string Url = "";

        public static async Task ExtractTestAsync()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArgument("ignore-certificate-errors");
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            IWebDriver browser = new ChromeDriver(options)
            {
                Url = Url
            };

            var movieList = Tools.ReadFile("MovieList.txt");

            foreach (var title in movieList)
            {
                var result = GetJsonResult(browser, title);

                await File.WriteAllTextAsync($@"..\..\..\..\Malcaba.MovieCollector.Data\Json\{title.Replace("'", "").Replace(" ", "-").ToLower()}.json", result);
            }


            browser.Quit();
        }

        private static string GetJsonResult(IWebDriver browser, string title)
        {
            var titleInput = browser.FindElement(By.Id("t"));
            titleInput.Click();
            titleInput.Clear();
            titleInput.SendKeys(title);

            var searchButton = browser.FindElement(By.Id("search-by-title-button"));
            searchButton.Click();

            // Wait for API to finish
            Thread.Sleep(3000);

            var result = browser.FindElement(By.CssSelector("#search-by-title-response > .alert"));

            return result.Text;
        }


    }
}
