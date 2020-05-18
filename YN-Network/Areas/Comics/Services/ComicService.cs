using System;
using YN_Network.Areas.Comics.Models;
using System.Text.Json;
using System.Net;

namespace YN_Network.Areas.Comics.Services
{
    public class ComicService : IComicService
    {
        private WebClient _webClient = new WebClient();
        private string comicUrl = "https://xkcd.com";

        public ComicService()
        {
        }

        public Comic GetTodayComic()
        {

            // get a daily comic //9
            var comicJson = _webClient.DownloadString(String.Format("{0}/{1}",this.comicUrl, "info.0.json"));
            return JsonSerializer.Deserialize<Comic>(
                comicJson,
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                }
             );
        }
    }
}
