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
        public async Task<IEnumerable<string>> GetLinks( bool needMatch = true)
        {

                HtmlWeb web = new HtmlWeb();
                var htmlDocument = await web.LoadFromWebAsync(_request.Url);

                var linkList = htmlDocument.DocumentNode
                                   .Descendants("a")
                                   .Select(a => a.GetAttributeValue("href", null))
                                   .Where(u => !string.IsNullOrEmpty(u))
                                   .Distinct();

                if (needMatch &&  _regex != null)
                    linkList = linkList.Where(link => _regex.IsMatch(link));

                return linkList;
        }
    }
    public class Request
    {
        public string OriginalUrl { get; set; }
        public string Url { get; set; }
        public string Regex { get; set; }
        public long TimeOut { get; set; }
    }
}
