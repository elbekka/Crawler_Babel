using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Downloader
{
    public interface IDownloader
    {
        string DownloadPath { get; set; }
        Task<HtmlDocument> Download(string crawlUrl);

    }
}
