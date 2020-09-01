using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Processor
{
    public class Processor : IProcessor
    {
        public Task<IEnumerable<string>> Process(HtmlDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
