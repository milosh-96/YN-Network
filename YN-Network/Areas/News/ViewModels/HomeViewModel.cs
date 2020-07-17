using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.News.Models;

namespace YN_Network.Areas.News.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Models.Article> Articles { get; set; }
        public ICollection<Areas.Jokes.Models.Joke> Joke { get; set; }
        public Areas.Comics.Models.Comic Comic { get; set; }

        public ICollection<string> SourcesCountries { get; set; }
    }
}
