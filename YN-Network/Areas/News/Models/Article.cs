using System;
using System.Collections.Generic;

namespace YN_Network.Areas.News.Models
{
    public class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }


    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NewsApiResult
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
