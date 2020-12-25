using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using YN_Network.Areas.Search.Models;

namespace YN_Network.Areas.Search.Services
{
    public class QueryService : IQueryService
    {

        private HttpClient _httpClient;

        public QueryService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
        }

        public async Task<ICollection<Topic>> GetTopics(string query)
        {
            
                string searchUrl = String.Format("https://api.duckduckgo.com/?q={0}&format=json&pretty=1", query);
                QueryResult queryResult = new QueryResult();
                HttpResponseMessage response =  await _httpClient.GetAsync(searchUrl);

            if(response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    queryResult = await JsonSerializer.DeserializeAsync<QueryResult>(responseStream, options);
                
            }
            
                return queryResult.Topics;
        }
        public async Task<ICollection<Topic>> GetRelatedTopics(string query)
        {
            string searchUrl = String.Format("https://api.duckduckgo.com/?q={0}&format=json&pretty=1", query);
            QueryResult queryResult = new QueryResult();
            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                queryResult = await JsonSerializer.DeserializeAsync<QueryResult>(responseStream, options);

            }

            return queryResult.RelatedTopics;
        }
    }
}
