using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.News.Models;
using Microsoft.Toolkit;
using System.Net.Http;
using Microsoft.Toolkit.Parsers.Rss;
using System.Collections.ObjectModel;
using YN_Network.Data;

namespace YN_Network.Areas.News.Services
{
    public class RssNewsService : INewsService
    {
        private readonly ApplicationDbContext _context;
        private IHttpClientFactory _httpClientFactory;
        public RssNewsService(ApplicationDbContext context,IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        public ICollection<Article> GetTopHeadlines()
        {

            List<Source> sources = _context.NewsSources.ToList();

            List<Article> articles = new List<Article>();
            foreach (Source source in sources)
            {
                var sourceResult = Task.Run(async () => await this.ParseRss(source));
                articles.AddRange(sourceResult.Result);
            }
            return articles.OrderByDescending(x => x.PublishedAt).ToList();
        }

        public ICollection<Article> GetTopHeadlines(int limit)
        {
            return this.GetTopHeadlines().Take(limit).ToList();
        }


        public ICollection<Article> GetTopHeadlines(string country)
        {
            return this.GetTopHeadlines().Where(x => x.Source.CountryCode == country).ToList();
        }

        public async Task<List<Article>> ParseRss(Source source)
        {
            string feed = null;
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(source.RssFeedUrl);

            if(response.IsSuccessStatusCode) {
                using var responseStream = response.Content.ReadAsStringAsync();
                try
                {
                    feed = responseStream.Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            List<Article> articles = new List<Article>();

            if (feed != null)
            {
                RssParser parser = new RssParser();
                List<RssSchema> rss = parser.Parse(feed).ToList();

                foreach (RssSchema element in rss)
                {
                    Article article = new Article()
                    {
                        Author = element.Author,
                        Title = element.Title,
                        Description = element.Summary,
                        Content = element.Content,
                        PublishedAt = element.PublishDate,
                        Source = source,
                        UrlToImage = element.ImageUrl,
                        Url = element.FeedUrl
                    };
                    articles.Add(article);
                }

            }
            return articles;
        }
    }
}
