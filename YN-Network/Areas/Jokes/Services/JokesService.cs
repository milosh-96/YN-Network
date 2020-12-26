using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using YN_Network.Areas.Jokes.Models;

namespace YN_Network.Areas.Jokes.Services
{
    public class JokesService : IJokesService
    {
        private IHttpClientFactory _httpClientFactory;
        private string jokesUrl = "https://official-joke-api.appspot.com/jokes";

        public JokesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Joke>> GetJokes()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            string url = String.Format("{0}/{1}", this.jokesUrl, "ten");
            HttpRequestMessage httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);

            List<Joke> jokes = new List<Joke>();
            if(httpResponse.IsSuccessStatusCode)
            {
                using var responseStream = httpResponse.Content.ReadAsStringAsync();

                try
                {
                    jokes = JsonSerializer.Deserialize<List<Joke>>(
                        responseStream.Result,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return jokes;
        }

        // get 10 random jokes by type //
        public async Task<List<Joke>> GetJokes(string type)
        {

            List<Joke> jokes = await this.GetJokes();

            return jokes.FindAll((x)=>x.Type==type);
        }

        public async Task<Joke> GetRandomJoke()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            string url = String.Format("{0}/{1}", this.jokesUrl, "random");
            HttpRequestMessage httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);

            Joke joke = new Joke();
            if (httpResponse.IsSuccessStatusCode)
            {
                using var responseStream = httpResponse.Content.ReadAsStringAsync();

                try
                {
                    joke = JsonSerializer.Deserialize<Joke>(
                        responseStream.Result,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return joke;
        }
    }
}
