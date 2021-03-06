﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string RssFeedUrl { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "text")]
        public string SourceLogoUrl { get; set; }
    }
}
