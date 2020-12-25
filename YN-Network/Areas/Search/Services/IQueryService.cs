using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YN_Network.Areas.Search.Models;

namespace YN_Network.Areas.Search.Services
{
    public interface IQueryService
    {

        public Task<ICollection<Topic>> GetTopics(string query);
        public Task<ICollection<Topic>> GetRelatedTopics(string query);

    }
}
