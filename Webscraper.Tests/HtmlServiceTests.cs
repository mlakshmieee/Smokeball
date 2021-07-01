using WebScraper;
using System;
using NUnit.Framework;

namespace Webscraper.Tests
{
    [TestFixture]
    public class HtmlServiceTests
    {
        private HtmlService _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new HtmlService();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new HtmlService();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallHtmlClientAndThrows()
        {
            var url = "123";
            Assert.Throws<InvalidOperationException>(()=>_testClass.GetHtml(url));
          
        }

        
    }
}