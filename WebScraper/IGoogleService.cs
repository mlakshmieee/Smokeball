using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public interface IGoogleService
    {
        List<ParseResult> Scrape(ScrapeRequest seoRequest);
    }
}
