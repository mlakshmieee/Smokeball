using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebScraper
{
    public class GoogleResultParser:IParser
    {
        private const string SearchResultRegexString = "<div class=\"(.*?)\"><a href=\"/url?(.*?)</h3>(.*?)</div></a></div>";
        private const string UrlRegexString = "<a href=\"/url?(.*?)&amp";
        private Regex searchResultRegex => new Regex(SearchResultRegexString);
        private Regex urlRegex => new Regex(UrlRegexString);
        public List<ParseResult> Parse(ParseRequest parseRequest)
        {
            if (parseRequest == null)
                throw new ArgumentNullException();

            var matches = searchResultRegex.Matches(parseRequest.Html);
            var parseResult = matches.Select((s,i) => new ParseResult { Value = urlRegex.Match(s.Value).Value, Position = i+1 }).ToList();
            return parseResult;
        }
    }
}
