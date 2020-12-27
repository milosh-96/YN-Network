using System;
using YN_Network.Areas.Comics.Models;
using System.Text.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace YN_Network.Areas.Comics.Services
{
    public class ComicService : IComicService
    {
        private IHttpClientFactory _httpClientFactory;
        private string comicUrl = "https://xkcd.com";

        public ComicService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Comic> GetTodayComic()
        {

            HttpClient httpClient = _httpClientFactory.CreateClient();

            // get a daily comic //9
            var comicJson = await httpClient.GetAsync(String.Format("{0}/{1}",this.comicUrl, "info.0.json"));

            if (comicJson.IsSuccessStatusCode)
            {
                try
                {
                    using var response = comicJson.Content.ReadAsStringAsync();
                    return  JsonSerializer.Deserialize<Comic>(
                        response.Result,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                     );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return new Comic();
        }
    }
}
