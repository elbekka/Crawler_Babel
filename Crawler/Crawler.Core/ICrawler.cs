using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Core
{
    public interface ICrawler
    {
        Task Crawler();
    }
}
