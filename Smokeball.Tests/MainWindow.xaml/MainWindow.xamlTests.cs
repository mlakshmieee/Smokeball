using NSubstitute;
using NUnit.Framework;
using System.Threading;
using WebScraper;

namespace Smokeball.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class MainWindowTests
    {
        private MainWindow _testClass;
        private IGoogleService _googleScraper;


        [SetUp]
        public void SetUp()
        {
            _googleScraper = Substitute.For<IGoogleService>();

            _googleScraper.Scrape(Arg.Any<ScrapeRequest>()).ReturnsForAnyArgs(new System.Collections.Generic.List<ParseResult>());
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new MainWindow(_googleScraper);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallGoogleScraperWithCorrectParameters()
        {
            var instance = new MainWindow(_googleScraper);
            
            _googleScraper.Received().Scrape(Arg.Is<ScrapeRequest>(x => x.Num == 100));
            _googleScraper.Received().Scrape(Arg.Is<ScrapeRequest>(x => x.ScrapeKeyword == "www.smokeball.com.au"));
            _googleScraper.Received().Scrape(Arg.Is<ScrapeRequest>(x => x.SearchKeyword == "conveyancing software"));
        }


    }
}