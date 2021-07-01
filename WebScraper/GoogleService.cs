using System;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public  class GoogleService:IGoogleService
    {
        private IParser _googleParser { get; set; }
        private IHtmlService _htmlService { get; set; }

        private const int NumOfRecords = 100;
        public GoogleService(IParser googleParser, IHtmlService htmlService)
        {
            if (googleParser == null)
                throw new ArgumentNullException("googleParser");
            if(htmlService == null)
                throw new ArgumentNullException("htmlService");

            _googleParser = googleParser;
            _htmlService = htmlService;
         }
        public List<ParseResult> Scrape(ScrapeRequest seoRequest)
        {
            if (seoRequest == null)
                throw new ArgumentNullException();

            var num = seoRequest.Num ?? NumOfRecords;
            var url = $"https://www.google.com.au/search?num={num}&q={seoRequest.SearchKeyword}";
            var html = _htmlService.GetHtml(url);
            var result = _googleParser.Parse(new ParseRequest(html));
            return result.Where(s => (s.Value ?? "").Contains(seoRequest.ScrapeKeyword, StringComparison.InvariantCultureIgnoreCase)).ToList();
            
            
        }
    }
}
