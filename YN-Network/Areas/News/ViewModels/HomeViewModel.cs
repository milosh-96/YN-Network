using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YN_Network.Areas.News.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Models.Article> Articles { get; set; }
    }
}
