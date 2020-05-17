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
        private string jokesUrl = "https://official-joke-api.appspot.com/jokes/";
        
        public ICollection<Joke> GetJokes()
        {
            string jokesJson = _webClient.DownloadString(String.Format("{0}{1}",this.jokesUrl,"ten"));
            return JsonSerializer.Deserialize<Collection<Joke>>(jokesJson);
        }

        public Joke GetRandomJoke()
        {
            string jokeJson = _webClient.DownloadString(String.Format("{0}{1}", this.jokesUrl, "random"));
            return JsonSerializer.Deserialize<Joke>(jokeJson);
        }
    }
}
