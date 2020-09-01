using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler.Downloader
{
    public class LinkReader
    {
        private readonly Request _request;
        private readonly Regex _regex;
        public LinkReader(Request request)
        {

            _request = request;
            if (!string.IsNullOrWhiteSpace(request.Regex))
            {
                _regex = new Regex(request.Regex);
            }
        }
        private async Task<IEnumerable<string>> GetPageLinks(string url, bool needMatch = true)
        {

                HtmlWeb web = new HtmlWeb();
                var htmlDocument = await web.LoadFromWebAsync(url);

                var linkList = htmlDocument.DocumentNode
                                   .Descendants("a")
                                   .Select(a => a.GetAttributeValue("href", null))
                                   .Where(u => !string.IsNullOrEmpty(u))
                                   .Distinct();

                if (_regex != null)
                    linkList = linkList.Where(x => _regex.IsMatch(x));

                return linkList;
        }
    }
    public class Request
    {
        public string Url { get; set; }
        public string Regex { get; set; }
        public long TimeOut { get; set; }
    }
}
