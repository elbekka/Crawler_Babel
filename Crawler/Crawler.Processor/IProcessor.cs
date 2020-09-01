using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Processor
{
   public interface IProcessor
    {
        Task<IEnumerable<string>> Process(HtmlDocument document);
    }
}
