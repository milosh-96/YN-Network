using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YN_Network.Areas.Search.Models;
using YN_Network.Areas.Search.Services;
using YN_Network.Areas.Search.ViewModels;

namespace YN_Network.Areas.Search.Pages
{
    public class QueryModel : PageModel
    {
        private IQueryService _queryService;
        public ResultViewModel ViewModel;

        public QueryModel(IQueryService queryService)
        {
            _queryService = queryService;
        }


        public async Task OnGet(string query)
        {
            ViewModel = new ResultViewModel();
            if (query != "")
            {
                ViewModel.Query = query;
                ViewModel.RelatedTopics = await _queryService.GetRelatedTopics(query);
            }
        }
    }
}
