using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YN_Network.Areas.Search.Services;
using YN_Network.Areas.Search.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YN_Network.Areas.Search.Controllers
{
    [Area("Search")]

    public class QueryController : Controller
    {

        private IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }
        // GET: //
        public IActionResult Index()
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            resultViewModel.Query = Request.Query["query"];
            resultViewModel.RelatedTopics = _queryService.GetRelatedTopics(resultViewModel.Query);
            ViewData["Query"] = Request.Query["query"];
            return View(resultViewModel);
        }
    }
}
