using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YN_Network.Areas.News.Models
{
    public class NewsApiModel
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
