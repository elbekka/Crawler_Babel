using HtmlAgilityPack;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Crawler.Downloader
{
    public class Downloader : IDownloader
    {
        public string DownloadPath { get; set; }

        public async Task<HtmlDocument> Download(string crawlUrl)
        {
            var htmlDocument = new HtmlDocument();
            using WebClient client = new WebClient();
            string htmlCode = await client.DownloadStringTaskAsync(crawlUrl);
            htmlDocument.LoadHtml(htmlCode);
            return htmlDocument;
        }
    }
}
