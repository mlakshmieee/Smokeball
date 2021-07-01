namespace Webscraper.Tests
{
    using WebScraper;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GoogleResultParserTests
    {
        private GoogleResultParser _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GoogleResultParser();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GoogleResultParser();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallParse()
        {
            var parseRequest = new ParseRequest("TestValue1424939644");
            var result = _testClass.Parse(parseRequest);
            Assert.True(result!=null);
        }

        [Test]
        public void TestSearchResultRegex()
        {
            var html = "<div><div class=\"test\"><a href=\"/url?something><h3>title Something</h3>I can be something</div></a></div>should not be parsed</div>";
            var parseRequest = new ParseRequest(html);
            var result = _testClass.Parse(parseRequest);
            Assert.True(result.Count == 1,"Expected 1 math but found none : Parse logic is not as expected");
            Assert.False(result[0].Value.Contains("should not be parsed"), "Parse logic is not as expected");
        }

        [Test]
        public void TestUrlRegex()
        {
            var html = "<div><div class=\"test\"><a href=\"/url?something.com.au&ampTHIS_SHOULD_NOT_BE_PRESENT_AS_LINK><h3>title Something</h3>I can be something</div></a></div>should not be parsed</div>";
            var parseRequest = new ParseRequest(html);
            var result = _testClass.Parse(parseRequest);         
            Assert.False(result[0].Value.Contains("THIS_SHOULD_NOT_BE_PRESENT_AS_LINK"), "Parse logic is not as expected");
        }

        [Test]
        public void CannotCallParseWithNullParseRequest()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Parse(default(ParseRequest)));
        }
    }
}