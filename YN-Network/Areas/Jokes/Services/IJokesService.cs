using System;
using System.Collections;
using System.Collections.Generic;
using YN_Network.Areas.Jokes.Models;

namespace YN_Network.Areas.Jokes.Services
{
    public interface IJokesService
    {
        public ICollection<Joke> GetJokes();
        public ICollection<Joke> GetJokes(string type);
        public Joke GetRandomJoke();

    }
}
