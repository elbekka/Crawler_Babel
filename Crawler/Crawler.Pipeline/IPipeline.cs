using Crawler.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Pipeline
{
   public interface IPipeline
    {
        Task Run(IEnumerable<BabelPoco>  babelPocos);
    }
}
