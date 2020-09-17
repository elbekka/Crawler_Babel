using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crawler.Processor
{
    public class Processor : IProcessor
    {
        /// <summary>
        /// Crea un nuevo poco y selecciona la informacion que deseamos extraer.
        /// </summary>
        /// <param name="document">Recibe el documento de HAP</param>
        /// <returns></returns>
        public async Task<BabelPoco> Process(HtmlDocument document)
        {
            BabelPoco babelPoco = new BabelPoco();
            var titulo = document.DocumentNode.SelectSingleNode("//*[@class='c-focus__title']").InnerText.Trim();
            var resumen = document.DocumentNode.SelectSingleNode("//*[@class='c-focus__data-blog']").InnerText.Trim();
            var info = document.DocumentNode.SelectNodes("//*[@class='o-grid__row']/div/p").Select(item => item.InnerText).ToList();
            var infOfer = document.DocumentNode.SelectNodes("//*[@class='o-grid__row']/div/ul").Select(item => item.InnerText).ToList()[0];
            babelPoco.Titulo = titulo;
            babelPoco.Resumen = resumen;
            babelPoco.Info = info;
            babelPoco.InfoOffer = infOfer;
            return babelPoco;
        }
    }
}
