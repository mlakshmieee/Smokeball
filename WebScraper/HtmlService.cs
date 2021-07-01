using System;
using System.Net.Http;

namespace WebScraper
{
    public class HtmlService:IHtmlService
    {
        public string GetHtml(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(url).Result;

            return response;
        }
    }
}
