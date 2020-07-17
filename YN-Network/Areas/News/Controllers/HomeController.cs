using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YN_Network.Areas.Comics.Services;
using YN_Network.Areas.Jokes.Services;
using YN_Network.Areas.News.Models;
using YN_Network.Areas.News.Services;
using YN_Network.Data;

namespace YN_Network.Areas.News.Controllers
{
    [Area("News")]

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INewsService _newsService;
        private readonly IJokesService _jokesService;
        private readonly IComicService _comicService;
        public HomeController(ApplicationDbContext context,INewsService newsService,IJokesService jokesService,IComicService comicService)
        {
            _context = context;
            _newsService = newsService;
            _jokesService = jokesService;
            _comicService = comicService;
        }

        public IActionResult Index()
        {
            ViewModels.HomeViewModel viewModel = new ViewModels.HomeViewModel();
            viewModel.Joke = _jokesService.GetJokes();
            viewModel.Comic = _comicService.GetTodayComic();
            viewModel.SourcesCountries = _context.NewsSources.Select(x => x.CountryCode).Distinct().ToList();
            string country = Request.Query["country"];
            if (country != null)
            {
                viewModel.Articles = _newsService.GetTopHeadlines(country);
            }
            else
            {
                viewModel.Articles = _newsService.GetTopHeadlines(10);
            }
            
            return View(viewModel);
        }
    }
}