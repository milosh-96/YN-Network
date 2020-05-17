using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YN_Network.Areas.Search.Models;

namespace YN_Network.Areas.Search.ViewModels
{
    public class ResultViewModel
    {
        public ICollection<Topic> RelatedTopics = new Collection<Topic>();
        public string Query = "Default";
        public ResultViewModel()
        {
        }
    }
}
