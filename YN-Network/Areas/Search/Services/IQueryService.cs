using System;
using System.Collections.Generic;
using YN_Network.Areas.Search.Models;

namespace YN_Network.Areas.Search.Services
{
    public interface IQueryService
    {

        public ICollection<Topic> GetTopics(string query);
        public ICollection<Topic> GetRelatedTopics(string query);

    }
}
