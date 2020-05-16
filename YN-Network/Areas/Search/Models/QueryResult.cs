using System;
using System.Collections.Generic;

namespace YN_Network.Areas.Search.Models
{
    public class QueryResult
    {
        public ICollection<Topic> RelatedTopics { get; set; }
        public ICollection<Topic> Topics { get; set; }


    }
}
