﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using YN_Network.Areas.Search.Models;

namespace YN_Network.Areas.Search.Services
{
    public class QueryService : IQueryService
    {
        private QueryResult _queryResult = null;
        public QueryService()
        {
        }

        public ICollection<Topic> GetTopics(string query)
        {
            
                string searchUrl = String.Format("https://api.duckduckgo.com/?q={0}&format=json&pretty=1", query);
                var json = new WebClient().DownloadString(searchUrl);
                QueryResult queryResult = JsonSerializer.Deserialize<QueryResult>(json);
                _queryResult = queryResult;
            
               return _queryResult.Topics;
        }
        public ICollection<Topic> GetRelatedTopics(string query)
        {
           
                string searchUrl = String.Format("https://api.duckduckgo.com/?q={0}&format=json&pretty=1", query);
                var json = new WebClient().DownloadString(searchUrl);
                QueryResult queryResult = JsonSerializer.Deserialize<QueryResult>(json);
                _queryResult = queryResult;
         
            
                return _queryResult.RelatedTopics;
        }

       
    }
}
