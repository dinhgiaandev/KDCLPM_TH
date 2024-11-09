using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;

namespace Test_KDCLPM
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
        }
        [Test]
        public void GetDataFromVNExpress()
        {

            driver.Navigate().GoToUrl("https://vnexpress.net/khoa-hoc");
            Thread.Sleep(2000);

            //driver.FindElement(By.ClassName("container ")).Click();


            var searchResults = new List<SearchResultFromVNExpress>();

            var results = driver.FindElements(By.CssSelector("ul.list-sub-feature li"));

            for (int i = 0; i < 10 && i < results.Count; i++)
            {
                var result = results[i];

                //title
                var titleElement = result.FindElements(By.CssSelector("h4.title_news a"));
                string title = titleElement.Count > 0 ? titleElement[0].Text : "Không có tiêu đề";

                //link
                string link = titleElement.Count > 0 ? titleElement[0].GetAttribute("href") : "Không có đường dẫn";

                //des
                var descriptionElement = result.FindElements(By.CssSelector("a"));
                string description = descriptionElement.Count > 0 ? descriptionElement[0].GetAttribute("title") : "Không có mô tả";

                //img
                var imgElement = result.FindElements(By.CssSelector("img"));
                string imageUrl = imgElement.Count > 0 ? imgElement[0].GetAttribute("src") : "Không có hình ảnh";


                searchResults.Add(new SearchResultFromVNExpress
                {
                    Title = title,
                    Link = link,
                    Description = description,
                    Image = imageUrl
                });
            }

            SaveToCSV(searchResults, @"D:\DinhGiaAn.csv");

        }

        private void SaveToCSV(List<SearchResultFromVNExpress> results, string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Title, Description, Link, Image");

            foreach (var result in results)
            {
                var line = $"\"{result.Title}\",\"{result.Description}\",\"{result.Link}\",\"{result.Image}\"";
                csv.AppendLine(line);
            }

            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public class SearchResultFromVNExpress
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public string Image { get; set; }
        }
    }
}
