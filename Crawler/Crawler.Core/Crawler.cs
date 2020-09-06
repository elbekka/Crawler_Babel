using Crawler.Downloader;
using Crawler.Pipeline;
using Crawler.Processor;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler.Core
{
    public class Crawler : ICrawler
    {
        public Request Request { get; private set; }
        public IDownloader Downloader { get; private set; }
        public IProcessor Processor { get; private set; }
        public IPipeline Pipeline { get; set; }
        public Crawler()
        {

        }
        public async Task StartCrawler()
        {
            var reader = new LinkReader(Request);
            var links = await reader.GetLinks();
            var listPocos = new List<BabelPoco>();
            foreach(var item in links)
            {
                var url = item;
                if (url.Contains(Request.Url).Equals(false))
                {
                    url = Request.OriginalUrl + url;
                }
                var htmlDocument = await Downloader.Download(url);
                var babelPoco = await Processor.Process(htmlDocument);
                listPocos.Add(babelPoco);
                
            }
            await Pipeline.Run(listPocos);
        }

        public Crawler SetRequest(Request request)
        {
            Request = request;
            return this;
        }
        public Crawler SetDownloader(IDownloader downloader)
        {
            Downloader = downloader;
            return this;
        }
        public Crawler SetProcessor(IProcessor processor)
        {
            Processor = processor;
            return this;
        }
        public Crawler SetPipeline(IPipeline pipeline)
        {
            Pipeline = pipeline;
            return this;
        }
    }
}
