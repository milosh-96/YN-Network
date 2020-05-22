using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.News.Models;
using System.Web;
using System.Net;
using System.Text.Json;

namespace YN_Network.Areas.News.Services
{
    public class NewsService : INewsService
    {
        private string _apiUrl = "https://newsapi.org/v2/{0}&apiKey=05c8ba71a540410e8ce3e006cf6f73a2";
        private WebClient _webClient = new WebClient();
        public ICollection<Article> GetTopHeadlines()
        {
            string endpointUrl = String.Format(_apiUrl, "top-headlines?country=us");
            string resultJson = _webClient.DownloadString(endpointUrl);

            NewsApiModel newsApiModel = JsonSerializer.Deserialize<NewsApiModel>(resultJson,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return newsApiModel.Articles;
        }


       
        public ICollection<Article> GetTopHeadlines(string source)
        {
            throw new NotImplementedException();
        }
    }
}
