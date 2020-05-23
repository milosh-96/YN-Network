using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YN_Network.Areas.Comics.Services;
using YN_Network.Areas.News.Services;
using YN_Network.Models;

using YN_Network.ViewModels;

namespace YN_Network.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComicService _comicService;
        private readonly INewsService _newsService;
        public HomeController(ILogger<HomeController> logger,IComicService comicService,INewsService newsService)
        {
            _logger = logger;
            _comicService = comicService;
            _newsService = newsService;

        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Comic = _comicService.GetTodayComic();
            viewModel.Articles = _newsService.GetTopHeadlines();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
