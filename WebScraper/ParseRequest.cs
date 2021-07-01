namespace WebScraper
{
    public class ParseRequest
    {
        public string Html { get; }
    
        public ParseRequest(string html)
        {
            Html = html;
        }
    }
}
