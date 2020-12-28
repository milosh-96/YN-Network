using System;
using System.Collections;
using System.Collections.Generic;

namespace YN_Network.ViewModels
{
    public class HomeViewModel { 
        public ICollection<YN_Network.Areas.News.Models.Article> Articles { get; set; }

        public HomeViewModel()
        {
        }
    }
}
