using System.Collections.Generic;

namespace WebScraper
{
    public interface IParser
    {
        List<ParseResult> Parse(ParseRequest parseRequest);
    }
}
