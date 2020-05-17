using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YN_Network.Areas.Jokes.Models;
using YN_Network.Areas.Jokes.Services;
using YN_Network.Areas.Jokes.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YN_Network.Areas.Jokes.Controllers
{
    [Area("Jokes")]

    public class HomeController : Controller
    {
        private readonly IJokesService _jokesServices;

        // GET: /<controller>/

        public HomeController(IJokesService jokesService)
        {
            _jokesServices = jokesService;
        }

        public IActionResult Index()
        {
            JokesIndexViewModel viewModel = new JokesIndexViewModel();
            viewModel.Jokes = _jokesServices.GetJokes();
            return View(viewModel);
        }
    }
}
