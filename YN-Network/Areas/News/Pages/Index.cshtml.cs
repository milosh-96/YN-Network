using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YN_Network.Areas.Comics.Services;
using YN_Network.Areas.Jokes.Services;
using YN_Network.Areas.News.Services;
using YN_Network.Areas.News.ViewModels;
using YN_Network.Data;

namespace YN_Network.Areas.News.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly INewsService _newsService;
        private readonly IJokesService _jokesService;
        private readonly IComicService _comicService;
        public HomeViewModel ViewModel { get; set; }

        public IndexModel(ApplicationDbContext context, INewsService newsService, IJokesService jokesService, IComicService comicService)
        {
            _context = context;
            _newsService = newsService;
            _jokesService = jokesService;
            _comicService = comicService;
        }

        public void OnGet()
        {
            ViewModel = new ViewModels.HomeViewModel();
            ViewModel.Joke = _jokesService.GetJokes();
            ViewModel.Comic = _comicService.GetTodayComic();
            ViewModel.SourcesCountries = _context.NewsSources.Select(x => x.CountryCode).Distinct().ToList();
            string country = Request.Query["country"];
            if (country != null)
            {
                ViewModel.Articles = _newsService.GetTopHeadlines(country);
            }
            else
            {
                ViewModel.Articles = _newsService.GetTopHeadlines(10);
            }
        }


    }
}
