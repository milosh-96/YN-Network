using System;
using System.Collections;
using System.Collections.Generic;

namespace YN_Network.ViewModels
{
    public class HomeViewModel
    {
        public YN_Network.Areas.Comics.Models.Comic Comic { get; set; }
        public ICollection<YN_Network.Areas.News.Models.Article> Articles { get; set; }

        public HomeViewModel()
        {
        }
    }
}
