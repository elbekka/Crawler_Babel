using Crawler.Processor;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crawler.Pipeline
{
    public class Pipeline : IPipeline
    {

        /// <summary>
        /// Recive los POCOs y los pasa a un formato json.
        /// </summary>
        /// <param name="babelPocos">Lista de POCOs</param>
        /// <returns></returns>
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
