using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YN_Network.Areas.News.Models
{
    public class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        private string description;

        public string Description
        {
            get { return description; }
            set { if (value == null) { description = ""; } else { description = Regex.Replace(value, "<.*?>", String.Empty); } }
        }

        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }

        public Source Source { get; set; }
    }


    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
