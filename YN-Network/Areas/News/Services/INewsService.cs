using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YN_Network.Areas.News.Services
{
    public interface INewsService
    {

        // us news will be served
        public Task<List<YN_Network.Areas.News.Models.Article>> GetTopHeadlinesAsync();
        public Task<List<YN_Network.Areas.News.Models.Article>> GetTopHeadlinesAsync(int limit);
        public Task<List<YN_Network.Areas.News.Models.Article>> GetTopHeadlinesAsync(string country);

        public List<YN_Network.Areas.News.Models.Article> GetTopHeadlines();


        // limit number of items in the list
        public List<YN_Network.Areas.News.Models.Article> GetTopHeadlines(int limit);


        // if source is passed we will change the source country
        public List<YN_Network.Areas.News.Models.Article> GetTopHeadlines(string country);


    }
}
