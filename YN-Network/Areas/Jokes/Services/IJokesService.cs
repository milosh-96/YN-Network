using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using YN_Network.Areas.Jokes.Models;

namespace YN_Network.Areas.Jokes.Services
{
    public interface IJokesService
    {
        public Task<List<Joke>> GetJokes();
        public Task<List<Joke>> GetJokes(string type);
        public Task<Joke> GetRandomJoke();

    }
}
