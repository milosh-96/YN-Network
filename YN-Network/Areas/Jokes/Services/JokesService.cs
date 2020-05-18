using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;
using YN_Network.Areas.Jokes.Models;

namespace YN_Network.Areas.Jokes.Services
{
    public class JokesService : IJokesService
    {
        private WebClient _webClient = new WebClient();
        private string jokesUrl = "https://official-joke-api.appspot.com/jokes";

        public ICollection<Joke> GetJokes()
        {
            string jokesJson = _webClient.DownloadString(String.Format("{0}/{1}", this.jokesUrl, "ten"));
            return JsonSerializer.Deserialize<Collection<Joke>>(jokesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // get 10 random jokes by type //
        public ICollection<Joke> GetJokes(string type)
        {
            string jokesJson = _webClient.DownloadString(String.Format("{0}/{1}/ten", this.jokesUrl,type));
            return JsonSerializer.Deserialize<Collection<Joke>>(jokesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Joke GetRandomJoke()
        {
            string jokeJson = _webClient.DownloadString(String.Format("{0}/{1}", this.jokesUrl, "random"));
            return JsonSerializer.Deserialize<Joke>(jokeJson);
        }
    }
}
