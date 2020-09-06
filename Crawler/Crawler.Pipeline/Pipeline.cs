using Crawler.Processor;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crawler.Pipeline
{
    public class Pipeline : IPipeline
    {


        public async Task Run(IEnumerable<BabelPoco> babelPocos)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var prueba = JsonSerializer.Serialize(babelPocos,options);

            Console.WriteLine(prueba);
        }
    }
}
