using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Malcaba.MovieCollector.Tests
{
    public class MovieJsonExtractor
    {
        private const string Url = "";
        private const int TwoSeconds = 2000;

        [Fact]
        public async Task ExtractTestAsync()
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

                await File.WriteAllTextAsync($@"..\..\..\..\Malcaba.MovieCollector.Data\Json\{title.Replace("'","").Replace(" ","-").ToLower()}.json", result);
            }


            browser.Quit();
        }

        [Fact]
        public void TestRead()
        {
            var test = Tools.ReadFile("MovieList.txt");

            Assert.True(test.Count > 0);

        }

        private string GetJsonResult(IWebDriver browser, string title)
        {
            var titleInput = browser.FindElement(By.Id("t"));
            titleInput.Click();
            titleInput.Clear();
            titleInput.SendKeys(title);

            var searchButton = browser.FindElement(By.Id("search-by-title-button"));
            searchButton.Click();

            // Wait for API to finish
            Thread.Sleep(TwoSeconds);

            var result = browser.FindElement(By.CssSelector("#search-by-title-response > .alert"));

            return result.Text;
        }

        private void SaveJsonToFile(string json)
        { 
        }
    }
}
