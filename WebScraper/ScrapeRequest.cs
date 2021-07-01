namespace WebScraper
{
    public class ScrapeRequest
    {
        public int? Num { get; }
        public string SearchKeyword { get; }
        public string ScrapeKeyword { get; }
        public ScrapeRequest(string searchKeyword,string scrapeKeyword, int? num=null)
        {
            Num = num;
            SearchKeyword = searchKeyword;
            ScrapeKeyword = scrapeKeyword;
        }
    }
}