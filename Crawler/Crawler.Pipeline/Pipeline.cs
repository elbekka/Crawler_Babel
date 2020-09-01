using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Pipeline
{
    public class Pipeline : IPipeline
    {
        public Task Run(IEnumerable<string> jsonList)
        {
            throw new NotImplementedException();
        }
    }
}
