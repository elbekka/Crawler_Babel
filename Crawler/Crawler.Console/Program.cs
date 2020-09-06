using Crawler.Processor;
using System;
using Core = Crawler.Core;
namespace Crawler.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new Core.Crawler()
                .SetRequest(new Downloader.Request
                {
                    OriginalUrl = "https://babel.es",
                    Url = "https://babel.es/es/Personas/Ofertas",
                    Regex= @".*personas/ofertas.+",
                    TimeOut = 3000
                })
                .SetDownloader(new Downloader.Downloader())
                .SetProcessor(new Processor.Processor())
                .SetPipeline(new Pipeline.Pipeline());

            crawler.StartCrawler().GetAwaiter().GetResult();
        }
    }
}
