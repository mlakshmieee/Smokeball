using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace Webscraper.Tests
{
    using WebScraper;
    using System;
    using NUnit.Framework;
    using NSubstitute;

    [TestFixture]
    public class GoogleServiceTests
    {
        private GoogleService _testClass;
        private IParser _googleParser;
        private IHtmlService _htmlService;

        [SetUp]
        public void SetUp()
        {
            _googleParser = Substitute.For<IParser>();
            _htmlService = Substitute.For<IHtmlService>();
            _testClass = new GoogleService(_googleParser, _htmlService);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GoogleService(_googleParser, _htmlService);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullGoogleParser()
        {
            Assert.Throws<ArgumentNullException>(() => new GoogleService(default(IParser), Substitute.For<IHtmlService>()));
        }

        [Test]
        public void CannotConstructWithNullHtmlService()
        {
            Assert.Throws<ArgumentNullException>(() => new GoogleService(Substitute.For<IParser>(), default(IHtmlService)));
        }

        [Test]
        public void CanCallGetHtmlAndScrape()
        {
            var seoRequest = new ScrapeRequest("TestValue1884547280", "TestValue2137313469", 182347513);
            _htmlService.GetHtml(Arg.Any<string>()).ReturnsForAnyArgs("TestHtml");
            _googleParser.Parse(Arg.Any<ParseRequest>()).ReturnsForAnyArgs(new List<ParseResult>());
            var result = _testClass.Scrape(seoRequest);
            _htmlService.Received().GetHtml(Arg.Any<string>());
            _googleParser.Received().Parse(Arg.Any<ParseRequest>());
        }

        [Test]
        public void CannotCallScrapeWithNullSeoRequest()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Scrape(default(ScrapeRequest)));
        }
    }
}