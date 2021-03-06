using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YN_Network.Areas.News.Services;
using YN_Network.Areas.News.ViewModels;
using YN_Network.Data;

namespace YN_Network.Areas.News.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly INewsService _newsService;
        public HomeViewModel ViewModel { get; set; }

        public IndexModel(ApplicationDbContext context, INewsService newsService)
        {
            _context = context;
            _newsService = newsService;

        }

        public void OnGet()
        {
            ViewModel = new ViewModels.HomeViewModel();
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
