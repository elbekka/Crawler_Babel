using Crawler.Processor;
using System;
using Core = Crawler.Core;
namespace Crawler.ConsoleApplication
{
    class Program
    {
        /// <summary>
        /// Url original de la página web
        /// </summary>
        public const string ORIGINAL_URL = "https://babel.es";
        /// <summary>
        /// Url de la página
        /// </summary>
        public const string URL = "https://babel.es/es/Personas/Ofertas";
        /// <summary>
        /// Expresion regular para filtrar las urls
        /// </summary>
        public const string REGEX = @".*personas/ofertas.+";
        /// <summary>
        /// TimeOut para la peticion.
        /// </summary>
        public const long TIME_OUT = 3000;
        static void Main(string[] args)
        {
            var crawler = new Core.Crawler()
                .SetRequest(new Downloader.Request
                {
                    OriginalUrl = ORIGINAL_URL,
                    Url = URL,
                    Regex= REGEX,
                    TimeOut = TIME_OUT
                })
                .SetDownloader(new Downloader.Downloader())
                .SetProcessor(new Processor.Processor())
                .SetPipeline(new Pipeline.Pipeline());

            crawler.StartCrawler().GetAwaiter().GetResult();
        }
    }
}
