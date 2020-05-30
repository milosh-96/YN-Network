using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YN_Network.Areas.News.Services
{
    public interface INewsService
    {

        // us news will be served
        public ICollection<YN_Network.Areas.News.Models.Article> GetTopHeadlines();

        // if source is passed we will change the source country
        public ICollection<YN_Network.Areas.News.Models.Article> GetTopHeadlines(string country);
    }
}
