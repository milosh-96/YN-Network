using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YN_Network.Areas.News.Services;

namespace YN_Network.Areas.News.Controllers
{
    [Area("News")]

    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewModels.HomeViewModel viewModel = new ViewModels.HomeViewModel();

            viewModel.Articles = _newsService.GetTopHeadlines();
            
            return View(viewModel);
        }
    }
}